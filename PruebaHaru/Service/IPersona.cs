using PruebaHaru.Viewmodels;

namespace PruebaHaru.Service
{
    public interface IPersona
    {
        public List<PersonasVM> ObtenerPersonas();
        public bool setPersonas(PersonasVM personas);
        public bool putPersonas(PersonasVM personas);

        public bool deletePersonas(int idPersonas);

    }
}
