using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormMultiInsert.Models;

namespace FormMultiInsert.Controllers
{
    public class VMUserController : Controller
    {
        // GET: VMUser
        [HttpGet]
        public ActionResult AddUser(int id = 0)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(VMUser vMUser)
        {
            using (DBModelApp MyDbModel = new DBModelApp())
            {
                if (MyDbModel.Users.Any(x => x.Username == vMUser.Username))
                {
                    ViewBag.DuplicateMessage = "Username already exist";
                    return View("AddUser", vMUser);
                }

                User usuario = new User()
                {
                    Username = vMUser.Username,
                    Password = vMUser.Password,
                    IsAdmin = vMUser.IsAdmin
                };

                MyDbModel.Users.Add(usuario);
                MyDbModel.SaveChanges();

                User IdUser = MyDbModel.Users.FirstOrDefault(x => x.Username == vMUser.Username);

                Email email = new Email()
                {
                    UserId = IdUser.Id,
                    EmailAddress = vMUser.EmailAddress
                };

                MyDbModel.Emails.Add(email);
                MyDbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("AddUser", new VMUser());
        }
    }
}