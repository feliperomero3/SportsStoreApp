﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data;
using SportsStore.Entities;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IEnumerable<OrderModel> GetOrders()
        {
            var orders = _applicationDbContext.Orders
                .Include(o => o.Products)
                .Include(o => o.Payment)
                .ToArray();

            var orderModels = orders.Select(OrderModel.FromOrder);

            return orderModels;
        }

        [HttpGet("{id}")]
        public OrderModel GetOrder(long id)
        {
            var order = _applicationDbContext.Orders
                .Include(o => o.Products)
                .Include(o => o.Payment)
                .FirstOrDefault(o => o.OrderId == id);

            var orderModel = OrderModel.FromOrder(order);

            return orderModel;
        }

        [HttpPost("{id}")]
        public void MarkShipped(long id)
        {
            Order order = _applicationDbContext.Orders.Find(id);

            if (order != null)
            {
                order.MarkShipped();

                _applicationDbContext.SaveChanges();
            }
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderInputModel orderModel)
        {
            var order = orderModel.ToOrder();

            order.Payment.Total = GetTotal(order.Products);

            ProcessPayment(order.Payment);

            if (order.Payment.AuthCode != null)
            {
                _applicationDbContext.Add(order);
                _applicationDbContext.SaveChanges();

                return Ok(new
                {
                    orderId = order.OrderId,
                    authCode = order.Payment.AuthCode,
                    amount = order.Payment.Total
                });
            }
            else
            {
                return BadRequest("Payment rejected");
            }
        }

        private decimal GetTotal(IEnumerable<CartLine> lines)
        {
            IEnumerable<long> ids = lines.Select(l => l.ProductId);

            return _applicationDbContext.Products
                .Where(p => ids.Contains(p.ProductId))
                .AsEnumerable()
                .Select(p => lines.First(l => l.ProductId == p.ProductId).Quantity * p.Price)
                .Sum();
        }

        private void ProcessPayment(Payment payment)
        {
            // Integrate your payment system here
            payment.AuthCode = "12345";
        }
    }
}
