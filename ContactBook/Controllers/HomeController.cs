using ContactBook.Models;
using ContactBook.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Configuration;

namespace ContactBook.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference.BookServiceClient serviceClient = new ServiceReference.BookServiceClient();

        public ActionResult Index(int? page)
        {
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            int pageNumber = (page ?? 1);
            return View(serviceClient.GetContacts().ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult DeleteContact(Contacts contact)
        {
            return View(contact);
        }

        [HttpPost, ActionName("DeleteContact")]
        public ActionResult DeleteConfirmed(int id)
        {
            serviceClient.DeleteContact(id);
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
                serviceClient.CreateContact(dto.Name, dto.Email);
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