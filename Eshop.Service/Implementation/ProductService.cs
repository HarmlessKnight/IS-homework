using Eshop.Domain.Domain_Models;
using Eshop.Domain.DTO;
using Eshop.Repository.Implementation;
using Eshop.Repository.Interface;
using Eshop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eshop.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<TicketsInSC> _productInShoppingCartRepository;
        private readonly IRepository<Ticket> _ticketRepository;

        public ProductService(IRepository<Ticket> ticketRepository, IUserRepository userRepository, IRepository<TicketsInSC> productInShoppingCartRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
        }



        public bool AddToShoppingCart(AddToShoppingCartDTO item, string userId)
        {
            var user = this._userRepository.Get(userId);
            var userShoppingCart = user.UserShoppingCart;

            if (userShoppingCart != null)
            {
                var ticket = this.getDetailsForTicket(item.TicketId);
                if (ticket != null)
                {
                    
                    TicketsInSC itemToAdd = new TicketsInSC
                    {
                        Ticket = ticket,
                        TicketID = ticket.Id,
                        ShoppingCart = userShoppingCart,
                        ShoppingCartID = userShoppingCart.Id,
                        Quantity = item.Quantity
                    };
                
                    
                   
                    this._productInShoppingCartRepository.Insert(itemToAdd);
                    return true;
                }
            }
            return false;
        }


        public void CreateNewTicket(Ticket t)
        {
            _ticketRepository.Insert(t);
        }

        public void DeleteTicket(int id)
        {
            var ticket = _ticketRepository.Get(id);
            _ticketRepository.Delete(ticket);
        }

        public void DeleteTicket(Ticket t)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAll().ToList();
        }

        public Ticket getDetailsForTicket(int id)
        {
            return _ticketRepository.Get(id);
        }

        public AddToShoppingCartDTO GetShoppingCartInfo(int id)
        {
            var product = this.getDetailsForTicket(id);
            AddToShoppingCartDTO model = new AddToShoppingCartDTO
            {
                SelectedTicket = product,
                TicketId = product?.Id ?? 0,
                Quantity = 1
            };

            return model;
        }

        public void UpdateExistingTicket(Ticket t)
        {
            _ticketRepository.Update(t);
        }
    }
}
