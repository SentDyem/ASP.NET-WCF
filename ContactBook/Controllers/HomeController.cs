using ContactBook.Models;
using ContactBook.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace ContactBook.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference.BookServiceClient ServiceClient = new ServiceReference.BookServiceClient();

        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(ServiceClient.GetContacts().ToPagedList(pageNumber, pageSize));
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
        //[HttpPost]
        //public JsonResult ValidateEmail(Contact contact) 
        //{
        //    Contact dto = new Contact()
        //        contact.Email = dto.Email;
        //    var testObj = dto.Email();

        //    return Json(testObj, JsonRequestBehavior.AllowGet);
        //}
    }
}