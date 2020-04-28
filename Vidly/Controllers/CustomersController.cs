using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //    If your result set returns 0 records:

            //        SingleOrDefault returns the default value for the type (e.g. default for int is 0)
            //        FirstOrDefault returns the default value for the type

            //    If you result set returns 1 record:

            //        SingleOrDefault returns that record

            //        FirstOrDefault returns that record

            //    If your result set returns many records:

            //        SingleOrDefault throws an exception

            //        FirstOrDefault returns the first record

            //Checks if customer exist in the list
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id=1 , Name = "Ali"},
                new Customer{Id=2 , Name = "Aamir"}
            };
        }
    }
}