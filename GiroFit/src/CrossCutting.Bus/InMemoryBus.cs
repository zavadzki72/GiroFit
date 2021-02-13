using Domain.Core.Bus;
using Domain.Core.Models;
using MediatR;
using System.Threading.Tasks;

namespace CrossCutting.Bus {

    public sealed class InMemoryBus : IMediatorHandler {

        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator) {
            _mediator = mediator;
        }

        public async Task<TResponse> SendCommand<T, TResponse>(T command) where T : Command<TResponse> {
            return await _mediator.Send<TResponse>(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event {
            return _mediator.Publish(@event);
        }

        public async Task SendCommand<TRequest>(TRequest command) where TRequest : Command {
            await _mediator.Send(command);
        }

    }
}
