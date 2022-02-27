using MediatR.NottificationHandler.Hubs;
using MediatR.NottificationHandler.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.NottificationHandler.Handlers.Queries.Products
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IHubContext<NotifyHub> hubContext;

        public GetProductByIdHandler(IHubContext<NotifyHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = SeedData.Products.FirstOrDefault(i => i.Id == request.Id);
            return product;
        }
    }
}
