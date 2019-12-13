using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceApp
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IContactService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IContactService
    {
        [OperationContract]
        List<Contact> GetContacts();
    }
}
