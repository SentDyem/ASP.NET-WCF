using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WcfService
{
    public class BookService : IBookService
    {
        public int CreateContact(string name, string email)
        {
            ContactEntities contactDb = new ContactEntities();
            Contacts dto = new Contacts();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email)) // неоптимальная конструкция, нужно отрефакторить
            {
                throw new Exception("Ошибка добавления! Поля не прошли валидацию");
            }

            else
            {
                dto.Name = name;
                dto.Email = email;
                contactDb.Contacts.Add(dto);
                contactDb.SaveChanges();
                int id = dto.Id;
                return id;
            }
        }
                
        public void DeleteContact(int id)
        {
            ContactEntities contactDB = new ContactEntities();
            Contacts dto = new Contacts();

            dto.Id = id;
            contactDB.Entry(dto).State = EntityState.Deleted;
            contactDB.SaveChanges();
        }

        public List<Contacts> GetContacts()
        {
            List<Contacts> contactList = new List<Contacts>();
            ContactEntities contactDb = new ContactEntities();
            var list = contactDb.Contacts.Select(t => t);

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
