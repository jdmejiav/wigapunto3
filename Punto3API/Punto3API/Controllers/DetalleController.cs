using CoreAPIMYSQLData.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Punto3API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetalleController : Controller
    {
        private readonly IDetalleFacturaRepository _detalleFacturaRepository;

        public DetalleController(IDetalleFacturaRepository detalleFacturaRepository)
        {
            _detalleFacturaRepository = detalleFacturaRepository;
        }
        [Route("{numero}")]
        [HttpGet]
        public async Task<IActionResult> getAllProductsInFactura(int numero)
        {
            return Ok(await _detalleFacturaRepository.GetAllProductsInFactura(numero));
        }


    }
}
