using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        //ctor + tab shortcut for consturcture
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //_context is type disposible object so it need to be dispose properly
        //here we override the base dispose method to dispose our _context
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult CustomerForm()
        {
            var MembershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = MembershipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerinDb = _context.Customers.Single(c => c.Id == customer.Id);
                //Use this to update all property of the model
                //UpdateModel(customerinDb);

                //Use auto mapper
                // automapper(customerinDb,customer);

                //better approch to specify the property need to update
                customerinDb.Name = customer.Name;
                customerinDb.Birthdate = customer.Birthdate;
                customerinDb.MembershipTypeId = customer.MembershipTypeId;
                customerinDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {
            //via hardcode data
            //var customers = GetCustomers();

            //Here the entity framwork will only excute qurrey
            //While iterating it will not qurrey it like this
            //It is called deferred Execution
            //var customers = _context.Customers;

            //here tolist make it to execute qurrey
            //otherwise when data needed to be fetch it will querry at that time
            //using System.Data.Entity; add this to use beacuse include is an extention method
            // and it is define in a different name space
            //we need to load the MembershipType along with customer so do this
            //other wise entity framwork will only load the customers
            //This is called Eager loading
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

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
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer{Id=1 , Name = "Ali"},
        //        new Customer{Id=2 , Name = "Aamir"}
        //    };
        //}
    }
}