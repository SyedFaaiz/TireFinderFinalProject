using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TireFinderFinalProject.Models;

namespace TireFinderFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static string saveUserInfo;

        private OrderDatabase _ordersDb;

        public HomeController(ILogger<HomeController> logger,OrderDatabase orderDatabase)
        {
            _logger = logger;
            _ordersDb = orderDatabase;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login(User user)
        {
            if (!ModelState.IsValid)
                return View();

            if (Repository.Users.Any(p => p.Email != user.Email) || Repository.Users.Any(p => p.Password != user.Password))
            {
                saveUserInfo = (user.Name);
                return View("Login");
            }
            return RedirectToAction("Dashboard", user);
        }

        [HttpPost]
        public IActionResult HomePage(User user)
        {
            if (!ModelState.IsValid)
                return View();

            if (Repository.Users.Any(p => p.Email == user.Email))
            {
                //return Content("A user with this email address already exists. Do you want to login?");
                return View("ErrorLogin");
            }

            Repository.AddUser(user);
            return View("Login", user);
        }


        [HttpGet]
        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult Dashboard(User user)
        {

            if (user.Email == null || user.Password == null)
                return RedirectToAction("Login");
            

            if (Repository.Users.Any(p => p.Email != user.Email) || Repository.Users.Any(p => p.Password != user.Password))
                return Content($"Hi {saveUserInfo}, your email and password don't match to the account you signed up for");

            return View("Dashboard", user);
        }

        public IActionResult UserList()
        {
            return View(Repository.Users);
        }

        public IActionResult OrderForm()
        {
            return View("OrderList");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult OrderList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveCustomer(Order order)
        {
            if (!ModelState.IsValid)
                return View("Homepage");

            if (order.Id == null)
                _ordersDb.Orders.Add(order);

            else
            {
                var orderInDb = _ordersDb.Orders.Find(order.Id);
                orderInDb.Quantity = order.Quantity;
                orderInDb.Price = order.Price;
    

            }

            _ordersDb.SaveChanges();
            return RedirectToAction("OrderList");
        }



    }
}
