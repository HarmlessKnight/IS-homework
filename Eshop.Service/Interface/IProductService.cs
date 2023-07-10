using Eshop.Domain.Domain_Models;
using Eshop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Service.Interface
{
    public interface IProductService
    {
        List<Ticket> GetAllTickets();

        Ticket getDetailsForTicket(int id);

        void CreateNewTicket(Ticket t);

        void UpdateExistingTicket(Ticket t);

        AddToShoppingCartDTO GetShoppingCartInfo(int id);

        void DeleteTicket(int id);

        bool AddToShoppingCart(AddToShoppingCartDTO item, string userID);

    }
}
