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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _ordersDb = new OrderDatabase();
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
            {
                return View();
            }

            if (Repository.Users.Any(p => p.Email != user.Email))
            {
                saveUserInfo = (user.Name);
                return View("Login");
            }

            else
            {

                return RedirectToAction("Dashboard", user);
            }
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
            {
                return RedirectToAction("Login");
            }

            if (Repository.Users.Any(p => p.Email != user.Email) || Repository.Users.Any(p => p.Password != user.Password))
            {
                return Content($"Hi {saveUserInfo}, your email and password don't match to the account you signed up for");
            }

            else
            {
                return View("Dashboard", user);
            }
        }


        public IActionResult UserList()
        {
            return View(Repository.Users);
        }



        public IActionResult OrderForm()
        {
            return View();
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

        [HttpGet]
        public IActionResult SaveOrder(Order order)
        {
            //if (!ModelState.IsValid)
              //  return View("Homepage");

            if(order.Id == 0)
            {
                _ordersDb.Orders.Add(order);  
            }

            else
            {
                var orderInDb = _ordersDb.Orders.Find(order.Id);
                orderInDb.Quantity = order.Quantity;
                orderInDb.Price = order.Price;
            }
            _ordersDb.SaveChanges();
            var allOrders = _ordersDb.Orders.ToList();
            // return View("OrderList");
            //var myOrder = _ordersDb.Orders.OrderBy(s => s.Id).FirstOrDefault();
            return View(allOrders);
        }
        [Route("home/orders/delete/{id}")]
        public IActionResult Delete(int Id)
        {
            var orderToBeDeleted = _ordersDb.Orders.Find(Id);

            if (orderToBeDeleted == null)
                return NotFound();

            _ordersDb.Orders.Remove(orderToBeDeleted);
            _ordersDb.SaveChanges();

            return RedirectToAction("SaveOrder");
            //return RedirectToAction("Home", "SaveOrder", orderToBeDeleted);
        }


        [Route("home/orders/edit/{id}")]
        public IActionResult Edit(int Id)
        {
            var orderToBeEdited = _ordersDb.Orders.Find(Id);

            if (orderToBeEdited == null)
                return NotFound();

            return View("OrderForm", orderToBeEdited);
        }



    }
}
