using CustomValidations;
using System.Collections.Generic;
using System.ServiceModel;


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
}
