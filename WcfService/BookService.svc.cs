using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.ModelBinding;

namespace WcfService
{
    public class BookService : IBookService
    {
        public int CreateContact(string name, string email)
        {
                ContactEntities contactDB = new ContactEntities();
                Contacts dto = new Contacts();
            if (name == null || email == null)
            {
                throw new Exception("Валидность не прошла");
            }
            else
            {
                dto.Name = name;
                dto.Email = email;
                contactDB.Contacts.Add(dto);
                contactDB.SaveChanges();
                int id = dto.Id;
                return id;
            }
            }
                

        public void DeleteContact(int id)
        {
            ContactEntities contactDB = new ContactEntities();
            Contacts dto = new Contacts();
            dto.Id = id;
            //int? value = 0;
            //if (value == 0)
            //{
            //    value = null;
            //}

                contactDB.Entry(dto).State = EntityState.Deleted;
                contactDB.SaveChanges();
            



        }

        public List<Contacts> GetContacts()
        {
            List<Contacts> contactList = new List<Contacts>();
            ContactEntities contactDB = new ContactEntities();
            var list = contactDB.Contacts.Select(t => t);
            foreach (var item in list)
            {
                Contacts contact = new Contacts();
                contact.Id = item.Id;
                contact.Name = item.Name;
                contact.Email = item.Email;
                contactList.Add(contact);
            }
            return contactList;
        }
    }
}
