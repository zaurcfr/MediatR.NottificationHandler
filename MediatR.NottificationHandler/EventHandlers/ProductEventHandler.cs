using MediatR.NottificationHandler.Commons;
using MediatR.NottificationHandler.Hubs;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.NottificationHandler.EventHandlers
{
    public class ProductNotification : INotification
    {
        public Notification Notification { get; set; }
        public string Message { get; set; }
    }

    public class ProductEventHandler : INotificationHandler<ProductNotification>
    {
        private readonly IHubContext<NotifyHub> hubContext;

        public ProductEventHandler(IHubContext<NotifyHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        public async Task Handle(ProductNotification notification, CancellationToken cancellationToken)
        {
            var notificationJson = JsonConvert.SerializeObject(notification.Notification);
            await hubContext.Clients.All.SendAsync("ReceiveNotification", notificationJson);
        }
    }
}
