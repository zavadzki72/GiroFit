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
    public class TrainController : ApiController {

        public TrainController(
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler bus
        ) : base(notifications, bus) {
        }

        /// <summary>
        ///     Pega todos os treinos cadastrados na plataforma
        /// </summary>
        /// <returns>Lista dos treinos</returns>
        /// <response code="200">Resume was found</response>
        /// <response code="400">Error in process/response>
        /// <response code="404">There's no resume</response>
        /// <response code="500">Returned case internal error</response> 
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<TreinoResponseViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TreinoResponseViewModel>>> GetAll() {

            return Response();
        }

        /// <summary>
        ///     Pega um treino especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>objeto de treino</returns>
        /// <response code="200">Resume was found</response>
        /// <response code="400">Error in process/response>
        /// <response code="404">There's no resume</response>
        /// <response code="500">Returned case internal error</response> 
        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(typeof(TreinoResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TreinoResponseViewModel>> GetById(int id) {

            return Response();
        }
    }
}
