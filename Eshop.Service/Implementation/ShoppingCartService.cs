using Eshop.Domain.Domain_Models;
using Eshop.Domain.DTO;
using Eshop.Repository.Interface;
using Eshop.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Text;

namespace Eshop.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        public readonly IUserRepository _userRepository;
        public readonly IRepository<TicketInOrder> _ticketInOrderRepository;
        public readonly IRepository<ShoppingCart> _shoppingCartRepository;
        public readonly IRepository<Order> _orderRepository;
        public readonly IRepository<EmailMessage> _mailRepository;


        public ShoppingCartService(IUserRepository userRepository, IRepository<TicketInOrder> ticketInOrderRepository,
            IRepository<ShoppingCart> shoppingCartRepository, IRepository<Order> orderRepository, IRepository<EmailMessage> mailRepository)
        {
            _userRepository = userRepository;
            _ticketInOrderRepository = ticketInOrderRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _orderRepository = orderRepository;
            _mailRepository = mailRepository;
        }




        public bool deleteTicketFromShoppingCart(string userId, int ticketId)
        {
            if(!String.IsNullOrEmpty(userId)&& ticketId!= null)
            {
                var logInUser = _userRepository.Get(userId);
                var userShoppingCart = logInUser.UserShoppingCart;
                var itemToDelete = userShoppingCart.TicketsInSC.Where(z => z.TicketID == ticketId).FirstOrDefault();
                userShoppingCart.TicketsInSC.Remove(itemToDelete);
                _shoppingCartRepository.Update(userShoppingCart);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ShoppingCartDTO getShoppingCartInfo(string userId)
        {
            
            var user = _userRepository.Get(userId);

            var userShoppingCart = user.UserShoppingCart;

            var ticketlist = userShoppingCart.TicketsInSC.Select(z => new
            {

                Quantity = z.Quantity,
                TicketPrice = z.Ticket.Price
            });

            double totalPrice = 0;
            foreach (var item in ticketlist)
            {
                totalPrice += item.TicketPrice * item.Quantity;
            }
            ShoppingCartDTO model = new ShoppingCartDTO
            {
                TotalPrice = totalPrice,
                TicketsInShoppingCart = userShoppingCart.TicketsInSC.ToList()
            };

            return model;

        }

        public bool OrderNow(string userId)
        {
           
            var user = _userRepository.Get(userId);

            var userShoppingCart = user.UserShoppingCart;

            EmailMessage message = new EmailMessage();
            message.Mailto = user.Email;

            message.Subject = "Succ Created Order";
            message.Status = false;


            Order newOrder = new Order
            {
                UserID = userId,
                OrderedBy = user
            };

            _orderRepository.Insert(newOrder);

            List<TicketInOrder> ticketInOrder = userShoppingCart.TicketsInSC.Select(z => new TicketInOrder
            {
                Ticket = z.Ticket,
                TicketId = z.TicketID,
                Order = newOrder,
                OrderId = newOrder.Id,
                Quantity = z.Quantity
            }).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("your order is complete. Order contains:");
            var totalprice = 0.0;

            for(int i = 1; i <= ticketInOrder.Count(); i++)
            {
                var item = ticketInOrder[i-1];
                totalprice += item.Quantity * item.Ticket.Price;
                sb.AppendLine(i.ToString() + "." + item.Ticket.MovieTitle+"price: "+item.Ticket.Price+ "Quantity:" + item.Quantity);
            }
            sb.AppendLine("total price: " + totalprice.ToString());

            message.Content = sb.ToString();


            foreach (var item in ticketInOrder)
            {
               _ticketInOrderRepository.Insert(item);
            }

            this._mailRepository.Insert(message);

            user.UserShoppingCart.TicketsInSC.Clear();
            _userRepository.Update(user);
            return true;
        }
    }
}
