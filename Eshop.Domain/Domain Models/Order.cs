using Eshop.Domain.Identity;
using System.Collections.Generic;

namespace Eshop.Domain.Domain_Models
{
    public class Order: BaseEntity
    {
        public string UserID { get; set; }

        public ShopUser OrderedBy { get; set; }

        public List<TicketInOrder> Tickets { get; set; }
    }
}
