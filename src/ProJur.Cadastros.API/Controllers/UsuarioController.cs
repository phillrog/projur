using Microsoft.AspNetCore.Mvc;
using ProJur.Cadastros.Aplication.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProJur.Cadastros.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return CustomResponse();
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {          
            return CustomResponse();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id)
        {
            return CustomResponse();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse();
        }

        private bool ValidarUsuario(AdicionarUsuarioCommand usuario)
        {
            if (usuario.EhValido()) return true;

            usuario.ValidationResult.Errors.ToList().ForEach(e => AdicionarErroProcessamento(e.ErrorMessage));
            return false;
        }
    }
}
