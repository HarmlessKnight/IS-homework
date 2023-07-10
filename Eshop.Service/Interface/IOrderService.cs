using Eshop.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Service.Interface
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderDetails(BaseEntity model);
    }
}
