using Eshop.Domain.Domain_Models;

namespace Eshop.Domain.DTO

{
    public class AddToShoppingCartDTO
    {
        public Ticket SelectedTicket { get; set; }

        public int TicketId { get; set; }

        public int Quantity { get; set; }
    }
}
