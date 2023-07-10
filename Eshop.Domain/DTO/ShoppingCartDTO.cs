
using Eshop.Domain.Domain_Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace Eshop.Domain.DTO
{
    public class ShoppingCartDTO
    {
        public List<TicketsInSC> TicketsInShoppingCart { get; set; }

        public double TotalPrice { get; set; }
    }
}
