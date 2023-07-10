using Eshop.Domain.Identity;
using Eshop.Repository.Interface;
using IEshop.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Eshop.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ShopUser> entities;
        string errorMsg = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<ShopUser>();

        }

        public void Delete(ShopUser entity)
        {
            if(entity == null) 
            {
                throw new ArgumentNullException("entity");
            }  
            entities.Remove(entity);
            context.SaveChanges();
        }

        public ShopUser Get(string id)
        {
            return entities.Include(z => z.UserShoppingCart).Include(u => u.UserShoppingCart)
                .ThenInclude(sc => sc.TicketsInSC)
                .ThenInclude(tis => tis.Ticket).SingleOrDefault(x => x.Id == id);

        }

        public IEnumerable<ShopUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(ShopUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();

        }

        public void Update(ShopUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
