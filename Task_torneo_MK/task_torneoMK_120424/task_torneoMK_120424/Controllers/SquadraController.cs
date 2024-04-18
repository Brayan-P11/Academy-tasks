using Microsoft.AspNetCore.Mvc;
using task_torneoMK_120424.DTO;
using task_torneoMK_120424.Services;

namespace task_torneoMK_120424.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SquadraController : Controller
    {
        private readonly SquadraService _service;
        public SquadraController(SquadraService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<SquadraDto>> ElencoSquadre()
        {
            return _service.RestituisciTutti();
        }

    }
}
