namespace EjercicioACA.Services
{
    public class JuezService
    {
        public JuezService()
        {
        }

        public int BuscarPosicion(int ciudadano, List<int> ciudadanos, List<Tuple<int, int>> confidencial)
        {
            const int NoEncontrado = -1;

            Tuple<int, int> datoConfindencial;

            try
            {
                datoConfindencial = confidencial[ciudadano];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentException("Lista inconsistente");
            }


            if (datoConfindencial.Item1 == 1 && datoConfindencial.Item2 == 2)
            {
                int posicionesCiudadano = ciudadanos.Count(c => c == ciudadano);
                if (posicionesCiudadano == 1)
                    return ciudadanos.IndexOf(ciudadano);
                else if (posicionesCiudadano > 1)
                    throw new ArgumentException("Lista inconsistente");
                else
                    return NoEncontrado;
            }

            return NoEncontrado;
        }
    }
}
