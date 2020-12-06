using MediatR;

namespace Domain.Core.Models {

    public abstract class Message : IRequest {

        public string MessageType { get; protected set; }

        protected Message() {
            MessageType = GetType().Name;
        }

    }

}
