using MediatR.NottificationHandler.Commons;
using MediatR.NottificationHandler.EventHandlers;
using MediatR.NottificationHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.NottificationHandler.Handlers.Commands.Products
{
    public class AddProductCommand : IRequest<Guid>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        public AddProductCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        private List<Product> _products = new List<Product>();
        private readonly IMediator mediator;

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            Notification notification = new Notification();
            try
            {
                Product p = new Product
                {
                    Id = request.Id,
                    Name = request.Name
                };
                _products.Add(p);
                notification.Message = "New product added: " + request.Name
            }
            catch (Exception)
            {
                notification.Message = "Error occured";
            }

            await mediator.Publish(new ProductNotification()
            {
                Notification = notification
            });

            return Guid.NewGuid();
        }
    }
}
