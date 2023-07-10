using Eshop.Domain.Domain_Models;
using Microsoft.AspNetCore.Identity;

namespace Eshop.Domain.Identity
{
    public class ShopUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Address { get; set; }

        public virtual ShoppingCart UserShoppingCart { get; set; }

    }
}
