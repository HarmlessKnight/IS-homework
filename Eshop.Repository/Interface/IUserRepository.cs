using Eshop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<ShopUser>GetAll();

        ShopUser Get(string id);

        void Insert(ShopUser entity);

        void Update(ShopUser entity);   

        void Delete(ShopUser entity);
    }
}
