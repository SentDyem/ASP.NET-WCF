using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IBookService
    {

        [OperationContract]
        List<Contacts> GetContacts();

        [OperationContract]
        int CreateContact(string name, string email);

        [OperationContract]
        void DeleteContact(int id);
    }
    [DataContract]
    public class Contact
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
