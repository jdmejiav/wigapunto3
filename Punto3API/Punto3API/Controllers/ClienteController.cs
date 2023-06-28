using CoreAPIMYSQLData.Repositories;
using CoreAPIMYSQLModel;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPIMYSQLData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Clientecontroller : ControllerBase
    {
    private readonly IClienteRepository _clienteRepository;

    public Clientecontroller(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    [Route("all/")]
    [HttpGet]
    public async Task<IActionResult> getAllClientes()
    {
        return Ok(await _clienteRepository.GetAllClientes());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getCliente(int id)
    {
        return Ok(await _clienteRepository.GetClienteDetails(id));
    }
        [Route("add/")]
        [HttpPost]
        public async Task<IActionResult> addCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var created = await _clienteRepository.InsertCliente(cliente);

            return Created("created", created);
        }
        [Route("update/")]
        [HttpPut]
        public async Task<IActionResult> updateCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            await _clienteRepository.updateCliente(cliente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteCliente(int id)
        {
            await _clienteRepository.DeleteClient(id);
            return NoContent();
        }



    }
}