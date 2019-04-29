using Microsoft.AspNetCore.Mvc;
using TaxCalc.Core;
using TaxCalc.Api.Model;

namespace TaxCalc.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private CalculadoraJuros _calculadoraJuros;

        public CalculaJurosController(CalculadoraJuros calculadoraJuros)
        {
            _calculadoraJuros = calculadoraJuros;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]CalculoJurosModel model)
        {
            var jurosCalculado = _calculadoraJuros.Calcular(model.ValorInicial, model.Meses);
            return Ok(jurosCalculado);
        }
    }
}
