namespace EjercicioACA.Impuestos
{
    public abstract class ImpuestoAbstract : IImpuesto
    {
        public decimal Calculo(decimal porc, decimal monto)
        {
            throw new NotImplementedException("Esta implementación debe ser compartida entre todos los impuestos");
        }

        public abstract int Periodo();
        public abstract decimal PorcentajePorPeriodo();
        public abstract decimal PorcentajePorMonto();
    }
}
