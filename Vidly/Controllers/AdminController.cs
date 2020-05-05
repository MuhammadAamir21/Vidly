using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Vidly.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin
        public ActionResult Users()
        {
            var usersWithRoles = (from user in _context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in _context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new UsersViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames).Replace(";", "")
                                  });

            return View(usersWithRoles);
        }

        public async Task<ActionResult> CreateUserRoles(string RoleName)
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            await roleManager.CreateAsync(new IdentityRole(RoleName));

            return RedirectToAction("UserRoles", "Admin");
        }

        public ActionResult UserRoles()
        {
            var Roles = _context.Roles.ToList();
            return View(Roles);
        }

        public ActionResult Indesx()
        {
            _context.Users.Include(u => u.Roles).ToList();

            var viewModel = new AdminViewModel
            {
                Roles = _context.Roles.ToList(),
            };

            return View();
        }
    }
}