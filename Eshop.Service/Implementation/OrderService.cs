using Eshop.Domain.Domain_Models;
using Eshop.Repository.Interface;
using Eshop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository ;   
        }

        public List<Order> GetAllOrders()
        {
            return this._orderRepository.getAllOrders();
        }

        public Order GetOrderDetails(BaseEntity model)
        {
            return this._orderRepository.GetOrderDetails(model);
        }
    }
}
