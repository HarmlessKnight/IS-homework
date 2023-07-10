using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Domain_Models
{
    public class TicketInOrder:BaseEntity
    {
        [ForeignKey("TicketId")]
        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int Quantity { get; set; }
    }
}
