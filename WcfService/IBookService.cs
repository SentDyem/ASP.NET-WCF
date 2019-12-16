using CustomValidations;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
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
    [ValidationBehavior]
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
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}
