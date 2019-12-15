using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    public class BookService : IBookService
    {
        

        public int CreateContact(string name, string email)
        {
            ContactEntities dto = new ContactEntities();
            Contacts cObj = new Contacts();
            cObj.Name = name;
            cObj.Email = email;
            dto.Contacts.Add(cObj);
            dto.SaveChanges();
            int iden = cObj.Id;
            return iden;
        }

        public void DeleteContact(int id)
        {
            ContactEntities dto = new ContactEntities();
            Contacts cObj = new Contacts();
            cObj.Id = id;
            dto.Entry(cObj).State = EntityState.Deleted;
            dto.SaveChanges();
        }

        public List<Contacts> GetContacts()
        {
            List<Contacts> contactList = new List<Contacts>();
            ContactEntities dto = new ContactEntities();
            var list = from k in dto.Contacts select k;
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
