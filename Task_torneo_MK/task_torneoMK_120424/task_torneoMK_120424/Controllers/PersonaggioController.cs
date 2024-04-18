using Microsoft.AspNetCore.Mvc;
using task_torneoMK_120424.DTO;
using task_torneoMK_120424.Services;

namespace task_torneoMK_120424.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaggioController : Controller
    {
        private readonly PersonaggioService _service;
        public PersonaggioController(PersonaggioService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<PersonaggioDto>> ElencoPersonaggi()
        {
            return _service.RestituisciTutti();
        }

        [HttpPost("inserisci")]
        public IActionResult InserisciPersonaggio(PersonaggioDto perDto)
        {
            if (perDto.Nom is not null && perDto.Nom.Trim().Equals(""))
                return BadRequest();
            if (perDto.Cos < 0)
                return BadRequest();
            if (perDto.Cat <0)
                return BadRequest();

            if(_service.InserisciPersonagggio(perDto))
            {
                return Ok();
            }
            return BadRequest();

        }
    }
}
