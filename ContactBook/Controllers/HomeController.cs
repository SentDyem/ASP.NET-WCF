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
        ServiceReference.BookServiceClient ServiceClient = new ServiceReference.BookServiceClient();

        public ActionResult Index()
        {
            return View(ServiceClient.GetContacts());
        }

        [HttpGet]
        public ActionResult DeleteContact(Contacts contact)
        {
            return View(contact);
        }

        [HttpPost, ActionName("DeleteContact")]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceClient.DeleteContact(id);
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
                Contacts dto = new Contacts();
                dto.Name = contact.Name;
                dto.Email = contact.Email;
                ServiceClient.CreateContact(dto.Name, dto.Email);
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