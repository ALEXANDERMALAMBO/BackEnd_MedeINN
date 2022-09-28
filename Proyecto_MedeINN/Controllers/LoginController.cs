using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repertorio;
using NetCoreAPIMySQL.Model;

namespace Proyecto_MedeINN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginRepo _loginRepository;

        public LoginController(ILoginRepo loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDataUsuario()
        {
            return Ok(await _loginRepository.GetAllDataUsuario());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDataUsuarioDetails(int id)
        {
            return Ok(await _loginRepository.GetDataUsuarioDetails(id));

        }

        [HttpPost]
        public async Task<IActionResult> CreateDataUsuario([FromBody] DataUsuario DataUsuario)
        {
            if (DataUsuario == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _loginRepository.InsertDataUsuario(DataUsuario);

            return Created("created", created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDataUsuario(int id, [FromBody] DataUsuario DataUsuario)
        {/*
            if (DataUsuario == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _loginRepository.UpdateDataUsuario(DataUsuario);

            return NoContent();*/
            try
            {

                if (id != DataUsuario.Id)
                {
                    return NotFound();
                }
                
                await _loginRepository.UpdateDataUsuario(DataUsuario);
                return Ok(new
                {
                    message = "La tarjeta fue actulizada con exito"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeteleDataUsuario(int id)
        {

            await _loginRepository.DeleteDataUsuario(new DataUsuario() { Id = id });

            return NoContent();
        }
    }
}
