using MediatR.NottificationHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR.NottificationHandler
{
    public static class SeedData
    {
        public static List<Product> Products { get; set; }

        public static List<Product> FillProducts()
        {
            Products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Shalvar"
                },
                new Product
                {
                    Id = 2,
                    Name = "Kitab"
                },
                new Product
                {
                    Id = 3,
                    Name = "Turnik"
                },
                new Product
                {
                    Id = 4,
                    Name = "Komputer"
                }
            };
            return Products;
        }
    }
}
