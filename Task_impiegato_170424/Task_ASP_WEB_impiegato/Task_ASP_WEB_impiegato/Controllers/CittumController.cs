using Microsoft.AspNetCore.Mvc;
using Task_ASP_WEB_impiegato.Models;
using Task_ASP_WEB_impiegato.Services;

namespace Task_ASP_WEB_impiegato.Controllers
{
    public class CittumController : Controller
    {
        private readonly CittumService _service;
        public CittumController(CittumService service)
        {
            _service = service;
        }

        public IActionResult Lista()
        {
            List<Cittum> elenco = _service.ElencoTutteCitta();

            return View(elenco);
        }

        public IActionResult Inserimento()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Salvataggio(Cittum objCitta)
        {
            if (_service.InserisciCitta(objCitta))
                return Redirect("/Cittum/Lista");
            else
                return Redirect("/Cittum/Errore");
        }


        [HttpDelete]
        public IActionResult Elimina(int varID)
        {
            if (_service.EliminaCittaPerID(varID))
                return Ok();

            return BadRequest();
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}