using Eshop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Domain.Domain_Models
{
    public class ShoppingCart : BaseEntity
    {
        public string AppUserID { get; set; }
        public ICollection<TicketsInSC> TicketsInSC { get; set; }
    }
}
