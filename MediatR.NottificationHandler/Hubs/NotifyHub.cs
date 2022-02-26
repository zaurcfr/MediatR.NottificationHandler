using MediatR.NottificationHandler.Commons;
using MediatR.NottificationHandler.EventHandlers;
using MediatR.NottificationHandler.Handlers.Commands.Products;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR.NottificationHandler.Hubs
{
    public class NotifyHub : Hub
    {
        private readonly IMediator mediator;

        public NotifyHub(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task AddProduct(string productName)
        {
            await mediator.Send(new AddProductCommand()
            {
                Name = productName
            });
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
