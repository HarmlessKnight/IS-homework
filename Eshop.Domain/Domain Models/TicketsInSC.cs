using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Domain.Domain_Models
{
    public class TicketsInSC:BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public int TicketID { get; set; }

        public int ShoppingCartID { get; set; }

        [ForeignKey("TicketID")]
        public Ticket Ticket { get; set; }

        [ForeignKey("ShoppingCartID")]
        public ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }
    }
}
