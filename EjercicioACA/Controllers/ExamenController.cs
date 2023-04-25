using EjercicioACA.DTO;
using EjercicioACA.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EjercicioACA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExamenController : ControllerBase
    {
        private JuezService _juezService;

        public ExamenController(JuezService juezService)
        {
            _juezService = juezService;
        }

        [HttpPost("FaltasCalendario")]
        public ActionResult<List<ReporteAsistenciasDTO>> FaltasCalendario(List<ReporteAsistenciasRequestDTO> faltasEmpleados)
        {
            List<ReporteAsistenciasDTO> calculoFaltas = new List<ReporteAsistenciasDTO>();
            foreach (var empleado in faltasEmpleados)
            {
                int feriados = empleado.InfoCalendario.ToUpper().Count(c => c == 'F');
                int ausencias = empleado.InfoCalendario.ToUpper().Count(c => c == 'A');
                int presencias = empleado.InfoCalendario.ToUpper().Count(c => c != 'A');
                float porcentajeAsistencia = (presencias * 100.0f) / empleado.InfoCalendario.Count();

                ReporteAsistenciasDTO reporteAsistencias = new ReporteAsistenciasDTO()
                {
                    NombreEmpleado = empleado.NombreEmpleado,
                    Feriados = feriados,
                    Ausencias = ausencias,
                    PorcentajeAsistencia = porcentajeAsistencia
                };

                calculoFaltas.Add(reporteAsistencias);
            }

            return Ok(calculoFaltas);
        }

        [HttpPost("EncontrarJuez/{ciudadano}")]
        public ActionResult<List<ReporteAsistenciasDTO>> EncontrarJuez(int ciudadano, [FromBody] JuezRequestDTO juezRequest)
        {
            try
            {
                int posicionJuez = _juezService.BuscarPosicion(ciudadano, juezRequest.Ciudadanos, juezRequest.MatrizConfidencial);
                return Ok(posicionJuez);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}