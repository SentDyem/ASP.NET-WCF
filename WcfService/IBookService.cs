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
        [FaultContract(typeof(ValidationFault))]
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
        [StringLengthValidator(3, 50, MessageTemplate = "Поле должно содержать минимум 3 символа")]
        public string Name { get; set; }

        [DataMember]
        [EmailAddress]
        public string Email { get; set; }
    }
}
