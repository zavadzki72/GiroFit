using ApplicationService.Interfaces;
using ApplicationService.ViewModels.Request.User;
using ApplicationService.ViewModels.Response;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApi.Controllers.Base;

namespace WebApi.Controllers {

    [Route("[controller]")]
    public class UserController : ApiController {

        private readonly IUserApplicationService _userApplicationService;

        public UserController(
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler bus,
            IUserApplicationService userApplicationService
        ) : base(notifications, bus) {
            _userApplicationService = userApplicationService;
        }

        /// <summary>
        ///     Verificar se um usuario está autenticado
        /// </summary>
        /// <response code="202">Usuario está autenticado</response>
        /// <response code="401">Usuario não está autenticado</response>
        [HttpGet]
        [Authorize]
        [Route("IsAuth")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult IsAuth()
        {
            return Accepted();
        }

        /// <summary>
        ///     Pega a informação de um usuario a partir do Token dele
        /// </summary>
        /// <response code="200">Usuario está autenticado</response>
        /// <response code="401">Usuario não está autenticado</response>
        [HttpGet]
        [Authorize]
        [Route("GetUserInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetUserInfo()
        {
            var firebase = User.Claims.FirstOrDefault(x => x.Type == "firebase").Value;

            //REFATORA ISSO PFVR
            var regexMatch = Regex.Match(firebase, "email.{4}(?<email>.*?\\\")");
            string email = regexMatch.Groups["email"].Value.Replace("\"", "");

            return Ok(new {
                Id = User.Claims.FirstOrDefault(x => x.Type == "user_id").Value,
                Name = User.Claims.FirstOrDefault(x => x.Type == "name").Value,
                Picture = User.Claims.FirstOrDefault(x => x.Type == "picture").Value,
                Email = email
            });
        }

        /// <summary>
        ///     Pega um usuario pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario</returns>
        /// <response code="200">Objeto de retorno</response>
        /// <response code="400">Algum campo está invalido ou nullo</response>
        /// <response code="404">Objeto nao encontrado</response>
        /// <response code="500">Ocorreu algum erro interno</response> 
        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(typeof(UserResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserResponseViewModel>> GetById(int id) {

            var response = await _userApplicationService.GetById(id);

            return Response(response);
        }

        /// <summary>
        ///     Pega um usuario pelo ID trazendo tbm a estrutura de modulos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario</returns>
        /// <response code="200">Objeto de retorno</response>
        /// <response code="400">Algum campo está invalido ou nullo</response>
        /// <response code="404">Objeto nao encontrado</response>
        /// <response code="500">Ocorreu algum erro interno</response> 
        [HttpGet]
        [Route("GetByIdWithModules/{id}")]
        [ProducesResponseType(typeof(UserResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserResponseViewModel>> GetByIdWithModules(int id) {

            var response = await _userApplicationService.GetByIdWithModules(id);

            return Response(response);
        }

        /// <summary>
        ///     Cria um novo usuario
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns>Usuario</returns>
        /// <response code="200">Objeto de retorno</response>
        /// <response code="400">Algum campo está invalido ou nullo</response>
        /// <response code="500">Ocorreu algum erro interno</response> 
        [HttpPost]
        [ProducesResponseType(typeof(UserResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserResponseViewModel>> Create([FromBody] CreateUserViewModel userViewModel) {

            var response = await _userApplicationService.Create(userViewModel);

            return Response(response);
        }

    }
}
