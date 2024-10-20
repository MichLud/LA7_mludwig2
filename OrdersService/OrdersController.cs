using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProductsService;

namespace OrdersService {
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly List<Order> Orders = new List<Order>
        {
            new Order
            {
                OrderId = 1,
                OrderDate = DateTime.UtcNow,
                CustomerName = "John Doe",
                Products = new List<Product>
                {
                    new Product { ProductId = 1, ProductName = "Product A", Price = 10.0m }
                }
            }
        };

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(Orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = Orders.Find(o => o.OrderId == id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] Order order)
        {
            Orders.Add(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }
    }
}

    
