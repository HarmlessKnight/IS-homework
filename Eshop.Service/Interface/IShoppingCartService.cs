using Eshop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDTO getShoppingCartInfo(string userId);

        bool deleteTicketFromShoppingCart(string userId,int ticketId);

        bool OrderNow(string userId);
    }
}
