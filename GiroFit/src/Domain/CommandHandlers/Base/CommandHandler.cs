using Domain.Core.Bus;
using Domain.Core.Models;
using Domain.Core.Notifications;

namespace Domain.CommandHandlers.Base {

    public class CommandHandler {

        private readonly IMediatorHandler _bus;

        public CommandHandler(IMediatorHandler bus) {
            _bus = bus;
        }

        protected void NotifyValidationErrors<TResponse>(Command<TResponse> message) {
            foreach(var error in message.ValidationResult.Errors) {
                _bus.RaiseEvent(new DomainNotification("FLUENT_VALIDATION", $"{message.MessageType} : {error.ErrorMessage}"));
            }
        }

        protected void NotifyValidationErrors(Command message) {
            foreach(var error in message.ValidationResult.Errors) {
                _bus.RaiseEvent(new DomainNotification("FLUENT_VALIDATION", $"{message.MessageType} : {error.ErrorMessage}"));
            }
        }

    }
}
