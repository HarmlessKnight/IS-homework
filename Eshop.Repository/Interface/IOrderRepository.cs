using Eshop.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> getAllOrders();

        Order GetOrderDetails(BaseEntity model);
    }
}
