using Domain.Core.Bus;
using Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers.Base {

    public class ApiController : ControllerBase {

        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _bus;

        public ApiController(INotificationHandler<DomainNotification> notifications, IMediatorHandler bus) {
            _notifications = (DomainNotificationHandler) notifications;
            _bus = bus;
        }

        protected List<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation() {
            return (!_notifications.HasNotifications());
        }

        protected new ActionResult Response() {

            if(IsValidOperation())
                return Ok(new { success = true });

            return BadRequest(new {
                success = false,
                errors = _notifications.GetNotifications().Select(n => new { n.Code, n.Message })
            });

        }

        protected new ActionResult Response<T>(T result) {

            if(IsValidOperation()) {

                if(result == null) {
                    return NotFound(new {
                        success = false,
                        data = "Object not found"
                    });
                } else {
                    return Ok(new {
                        success = true,
                        data = result
                    });
                }
            }

            return BadRequest(new {
                success = false,
                errors = _notifications.GetNotifications().Select(n => new { n.Code, n.Message })
            });
        }

        protected void NotifyError(string code, string message) {
            _bus.RaiseEvent(new DomainNotification(code, message));
        }
    }
}
