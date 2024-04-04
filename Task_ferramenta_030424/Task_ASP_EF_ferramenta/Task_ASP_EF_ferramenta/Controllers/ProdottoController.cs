using Microsoft.AspNetCore.Mvc;
using Task_ASP_EF_ferramenta.Models;
using Task_ASP_EF_ferramenta.Repositories;

namespace Task_ASP_EF_ferramenta.Controllers
{
    [ApiController]
    [Route("api/prodotti")]
    public class ProdottoController : Controller
    {

        [HttpGet] //ok
        public IActionResult ElencoLibri()          //https://localhost:7106/api/prodotti type get
        {
            return Ok(ProdottoRepo.getInstance().GetAll());
        }

        [HttpGet("{valCodice}")] // ok
        public IActionResult DettaglioProdotto(string varCodice)        // https://localhost:7106/api/prodotti/valcodice
        {
            Prodotto? prod = ProdottoRepo.getInstance().GetByCodice(varCodice);
            if (prod is not null)
                return Ok(prod);

            return NotFound();
        }

        [HttpPost] // ok
        public IActionResult InserisciProdotto(Prodotto objProd)        //https://localhost:7106/api/prodotti type post
        {
            if (ProdottoRepo.getInstance().Insert(objProd))
                return Ok(objProd);

            return BadRequest();
        }

        private IActionResult EliminaProdotto(int varId)
        {
            if (ProdottoRepo.getInstance().Delete(varId))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("codice/{varCodice}"), HttpPost("codice/{varCodice}")] // ok
        public IActionResult EliminaProdottoPerCodice(string varCodice)             //https://localhost:7106/api/prodotti/codice/varcodice type post
        {
            Prodotto? prod = ProdottoRepo.getInstance().GetByCodice(varCodice);
            if (prod is null)
                return BadRequest();

            // invoco il metodo private elimina per id
            return EliminaProdotto(prod.ProdottoId);

        }

        [HttpPut] // ok
        public IActionResult ModificaProdotto(Prodotto objProd)             //https://localhost:7106/api/prodotti type put
        {
            if (ProdottoRepo.getInstance().Update(objProd))
                return Ok();

            return BadRequest();
        }
    }
}
