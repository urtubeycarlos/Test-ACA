namespace EjercicioACA.DTO
{
    public class JuezRequestDTO
    {
        public List<int> Ciudadanos { get; set; }
        public List<Tuple<int, int>> MatrizConfidencial { get; set; }
    }
}
