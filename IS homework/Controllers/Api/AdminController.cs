using Eshop.Domain.Domain_Models;
using Eshop.Domain.Identity;
using Eshop.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace IS_homework.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<ShopUser> userManager;
        public AdminController(IOrderService orderService, UserManager<ShopUser> _userManager)
        {
            this._orderService = orderService;
            this.userManager = userManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetAllActiveOrders()
        {
            return this._orderService.GetAllOrders();
        }

        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity model)
        {
            return this._orderService.GetOrderDetails(model);
        }


        [HttpPost("[action]")]
        public bool ImportAllUsers(List<UserRegistrationDTO> model)
        {
            bool status = true;

            foreach(var user in model) 
            {
                var userCheck = userManager.FindByEmailAsync(user.Email).Result;

                if(userCheck == null)
                {
                    var newUser = new ShopUser
                    {
                        UserName = user.Email,
                        NormalizedEmail = user.Email,
                        Email = user.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        UserShoppingCart = new ShoppingCart()
                    };
                    var result = userManager.CreateAsync(newUser, user.Password).Result;
                    status = status && result.Succeeded;
                }
                else
                {
                    continue;
                }
            }

            return status;
        }

    }
}
