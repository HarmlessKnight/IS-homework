using Eshop.Domain.Identity;
using Eshop.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IEshop.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ShopUser>
    {
        
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<TicketsInSC> TicketsInSC { get; set; }

        public virtual DbSet<ShopUser> ShopUser { get; set; }

        public virtual DbSet<Order>Orders{ get; set; }

        public virtual DbSet<TicketInOrder> TicketInOrders { get; set; }

        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TicketsInSC>().HasKey(c => new { c.ShoppingCartID, c.TicketID });
            builder.Entity<TicketInOrder>().HasKey(c => new { c.OrderId, c.TicketId});
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }
}