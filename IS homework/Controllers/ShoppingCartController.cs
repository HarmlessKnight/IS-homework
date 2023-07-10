using Eshop.Domain.Domain_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Eshop.Service.Interface;
using IEshop.Repository;

namespace IS_homework.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            var model = _shoppingCartService.getShoppingCartInfo(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(model);
        }

        public IActionResult DeleteFromShoppingCart(int id)
        {

            _shoppingCartService.deleteTicketFromShoppingCart(User.FindFirstValue(ClaimTypes.NameIdentifier), id);
            return RedirectToAction("Index");
        }


        public IActionResult OrderNow()
        {
            _shoppingCartService.OrderNow(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return RedirectToAction("Index");

        }

    }


}
