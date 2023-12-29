using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaHaru.Service;
using PruebaHaru.Viewmodels;

namespace PruebaHaru.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        public IPersona persona;
        public PersonasController(IPersona _persona)
        {
            this.persona = _persona;
        }
        [HttpGet("ObtenerPersonas")]
        public ActionResult ObtenerPersonas()
        {
            return new JsonResult(persona.ObtenerPersonas());
        }
        [HttpPost("setPersonas")]
        public bool setEmpleado(PersonasVM personas)
        {
            return persona.setPersonas(personas);
        }
        [HttpPost("putPersonas")]
        public bool putPersonas(PersonasVM personas)
        {
            return persona.putPersonas(personas);
        }
        [HttpPost("deletPersona")]
        public bool deletPersona(int id)
        {
            return persona.deletePersonas(id);
        }
    }
}
