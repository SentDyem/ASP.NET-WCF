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
            ContactEntities obj = new ContactEntities();
            Contacts cobj = new Contacts();
            cobj.Name = name;
            cobj.Email = email;
            obj.Contacts.Add(cobj);
            obj.SaveChanges();
            int iden = cobj.Id;
            return iden;
        }

        public void DeleteContact(int id)
        {
            ContactEntities obj = new ContactEntities();
            Contacts cobj = new Contacts();
            cobj.Id = id;
            obj.Entry(cobj).State = EntityState.Deleted;
            obj.SaveChanges();
        }

        public List<Contacts> GetContacts()
        {
            List<Contacts> contactlist = new List<Contacts>();
            ContactEntities obj = new ContactEntities();
            var list = from k in obj.Contacts select k;
            foreach (var item in list)
            {
                Contacts contact = new Contacts();
                contact.Id = item.Id;
                contact.Name = item.Name;
                contact.Email = item.Email;
                contactlist.Add(contact);
            }
            return contactlist;
        }
    }
}
