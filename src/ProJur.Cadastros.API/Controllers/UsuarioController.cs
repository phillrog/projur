using Microsoft.AspNetCore.Mvc;
using ProJur.Cadastros.Aplication.Commands;
using ProJur.Cadastros.Aplication.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProJur.Cadastros.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        #region GET        
        /// <summary>
        /// Busca todos os usuários
        /// </summary>
        /// <returns>Lista de usuários cadastrados</returns>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     GET /Todo
        ///     {
        ///     }
        ///     
        /// </remarks>
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse();
        }

        #region GET{Id}
        /// <summary>
        /// Busca um usuário por id
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <returns>
        /// Retorna os dados do usuário
        /// </returns>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     GET /Todo
        ///     {
        ///        "id": "B99184E2-B819-4F37-83C0-5BA9ADAF0BAB"
        ///     }
        ///     
        /// </remarks>
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return CustomResponse();
        }

        #region POST
        /// <summary>
        /// Grava um novo usuário
        /// </summary>
        /// <param name="usuarioViewModel">Dados do usuário</param>
        /// <returns>200</returns>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     POST /Todo
        ///     
        ///     {
        ///         "nome": "Teste",
        ///         "sobrenome" : "Teste",
        ///         "email":"teste@teste.com",
        ///         "datanascimento": "2021-07-29",
        ///         "escolaridade": 1
        ///     }
        ///     
        /// </remarks> 
        #endregion
        [HttpPost]
        public async Task<IActionResult> Post(UsuarioViewModel usuarioViewModel)
        {          
            return CustomResponse();
        }

        #region PUT
        /// <summary>
        /// Atualiza os dados de um usuário
        /// </summary>
        /// <param  name="usuarioViewModel">Dados do usuário</param>
        /// 
        /// <returns>200</returns>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     PUT /Todo
        ///     
        ///     {
        ///         "id": "B99184E2-B819-4F37-83C0-5BA9ADAF0BAB"
        ///         "nome": "Teste",
        ///         "sobrenome" : "Teste",
        ///         "email":"teste@teste.com",
        ///         "datanascimento": "2021-07-29",
        ///         "escolaridade": 1
        ///     }
        ///     
        /// </remarks> 
        #endregion
        [HttpPut]
        public async Task<IActionResult> Put( UsuarioViewModel usuarioViewModel)
        {
            return CustomResponse();
        }

        #region GET{Id}
        /// <summary>
        /// Deleta um usuário por id
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <returns>
        /// 200
        /// </returns>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     DELETE /Todo
        ///     {
        ///        "id": "B99184E2-B819-4F37-83C0-5BA9ADAF0BAB"
        ///     }
        ///     
        /// </remarks>
        #endregion
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
