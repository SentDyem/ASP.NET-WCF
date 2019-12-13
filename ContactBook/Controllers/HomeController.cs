using ContactBook.Models;
using ContactBook.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactBook.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference.BookServiceClient obj = new ServiceReference.BookServiceClient();

        public ActionResult Index()
        {
            Response.AddHeader("Refresh", "5");
            return View(obj.GetContacts());
        }

        [HttpGet]
        public ActionResult DeleteContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteContact(int id)
        {
            obj.DeleteContact(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                Contacts con = new Contacts();
                con.Name = contact.Name;
                con.Email = contact.Email;
                obj.CreateContact(con.Name, con.Email);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}