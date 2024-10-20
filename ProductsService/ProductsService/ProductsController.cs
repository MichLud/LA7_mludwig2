using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ProductsService {
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Product A", Price = 10.0m },
            new Product { ProductId = 2, ProductName = "Product B", Price = 20.0m }
        };

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = Products.Find(p => p.ProductId == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            Products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }
    }
}
    
