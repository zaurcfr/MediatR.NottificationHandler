using MediatR.NottificationHandler.Handlers.Queries.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR.NottificationHandler.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> GetAll()
        {
            return View(await mediator.Send(new GetAllProductsQuery()));
        }

        public async Task<IActionResult> GetById(int id)
        {
            return View(await mediator.Send(new GetProductByIdQuery()
            {
                Id = id
            }));
        }
    }
}
