using Eshop.Domain.Domain_Models;
using Eshop.Domain.Identity;
using Eshop.Repository.Interface;
using IEshop.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eshop.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMsg = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();

        }
        public List<Order> getAllOrders()
        {
            return entities.Include(z => z.OrderedBy).Include(z => z.Tickets).Include("Tickets.Ticket").ToList();
        }

        public Order GetOrderDetails(BaseEntity model)
        {
            return entities.Include(z => z.OrderedBy).Include(z => z.Tickets).Include("Tickets.Ticket").SingleOrDefault(z => z.Id == model.Id);
        }
    }
}
