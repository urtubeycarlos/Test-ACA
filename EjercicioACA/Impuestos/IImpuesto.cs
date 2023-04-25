namespace EjercicioACA.Impuestos
{
    public interface IImpuesto
    {
        int Periodo();
        decimal PorcentajePorPeriodo();
        decimal PorcentajePorMonto();
        decimal Calculo(decimal porc, decimal monto);
    }
}
