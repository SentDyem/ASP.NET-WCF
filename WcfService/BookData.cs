using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService
{
    public class BookData
    {
        [DataContract]
        public class Contact
        {
            [DataMember]
            public string Id { get; set; }

            [DataMember(IsRequired = true, Name = "ФИО")]
            public string Name { get; set; }

            [DataMember(IsRequired = true, Name = "Электронная почта")]
            [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
            public string Email { get; set; }
        }
    }
}