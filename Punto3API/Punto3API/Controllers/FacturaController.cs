using CoreAPIMYSQLData.Repositories;
using CoreAPIMYSQLModel;
using Microsoft.AspNetCore.Mvc;

namespace Punto3API.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class FacturaController : Controller
    {
        private readonly IFacturaRepository _facturaRepository;

        public FacturaController(IFacturaRepository facturaRepository)
        {
            _facturaRepository= facturaRepository;
        }

        [Route("all/")]
        [HttpGet]
        public async Task<IActionResult> getAllFacturas()
        {
            return Ok(await _facturaRepository.GetAllFacturas());
        }

        [Route("user/{id}")]
        [HttpGet]
        public async Task<IActionResult> getAllFacturasUser(int id)
        {
            return Ok(await _facturaRepository.GetAllFacturasUser(id));
        }

        [HttpGet("{numero}/")]
        public async Task<IActionResult> getFactura(int numero)
        {
            return Ok(await _facturaRepository.GetFacturaDetails(numero));
        }
        [Route("add/")]
        [HttpPost]
        public async Task<IActionResult> addFactura([FromBody] Factura factura)
        {
            if (factura== null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _facturaRepository.InsertFactura(factura);

            return Created("created", created);
        }
    }
}
