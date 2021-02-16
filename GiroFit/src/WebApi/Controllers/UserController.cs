using ApplicationService.Interfaces;
using ApplicationService.ViewModels.Request.User;
using ApplicationService.ViewModels.Response;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
