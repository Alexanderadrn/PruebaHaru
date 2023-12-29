using PruebaHaru.Models;
using PruebaHaru.Viewmodels;

namespace PruebaHaru.Service
{
    public class PersonasService: IPersona
    {
        private PruebaHaruContext _context;
        
        public PersonasService(PruebaHaruContext context)
        {
            this._context = context;
        }
        public List<PersonasVM> ObtenerPersonas()
        {
            List<PersonasVM> listaPersonas= new List<PersonasVM>();
            var personas = _context.Personas.ToList();
            foreach (var item in personas)
            {
                PersonasVM persona = new PersonasVM
                {
                    idPersonas = item.IdPersonas,
                    nombrePersona = item.NombrePersona,
                    direccionPersona = item.DireccionPersona,
                    cedulaPersona = item.CedulaPersona,
                    telefonoPersona = item.TelefonoPersona,
                    emailPersona = item.EmailPersona,
                };
                listaPersonas.Add(persona);
            }
            return listaPersonas;
        }
        public bool setPersonas(PersonasVM personas)
        {
            bool registrado = false;
            try
            {
                Persona personaBD = new Persona();
                personaBD.IdPersonas = personas.idPersonas;
                personaBD.NombrePersona = personas.nombrePersona;
                personaBD.CedulaPersona = personas.cedulaPersona;
                personaBD.TelefonoPersona = personas.telefonoPersona;
                personaBD.DireccionPersona = personas.direccionPersona;
                personaBD.EmailPersona = personas.emailPersona;

                _context.Personas.Add(personaBD);
                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado = false;
            }
            return registrado;
        }
        public bool putPersonas(PersonasVM personas)
        {
            bool registrado = false;
            try
            {
                var putPersonas = _context.Personas.Where(x => x.IdPersonas == personas.idPersonas).FirstOrDefault();
                putPersonas.NombrePersona = personas.nombrePersona;
                putPersonas.CedulaPersona = personas.cedulaPersona;
                putPersonas.DireccionPersona = personas.direccionPersona;
                putPersonas.TelefonoPersona = personas.telefonoPersona;
                putPersonas.EmailPersona = personas.emailPersona;
                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado = false;
            }
            return registrado;
        }
        public bool deletePersonas(int idPersonas)
        {
            bool registrado = false;
            var deletePersonas = _context.Personas.Where(X => X.IdPersonas == idPersonas).FirstOrDefault();
            try
            {
                _context.Personas.Remove(deletePersonas);
                _context.SaveChanges();
                registrado = true;
            }
            catch
            {
                registrado = false;
            }
            return registrado;
        }
    }
}
