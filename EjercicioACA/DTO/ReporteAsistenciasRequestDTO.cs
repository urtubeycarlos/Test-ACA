using System.ComponentModel.DataAnnotations;

namespace EjercicioACA.DTO
{
    public class ReporteAsistenciasRequestDTO
    {
        public string NombreEmpleado { get; set; }

        [MaxLength(365)]
        public string InfoCalendario { get; set; }
    }
}
