using Microsoft.AspNetCore.Mvc;
using task_torneoMK_120424.DTO;
using task_torneoMK_120424.Services;

namespace task_torneoMK_120424.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtenteController : Controller
    {
        // INJECTION DEL SERVICE DENTRO A CONTROLLER
        private readonly UtenteService _service;
        public UtenteController(UtenteService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<UtenteDto>> ElencoUtenti()
        {
            return _service.RestituisciTutti();
        }

        

    }
}
