using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WcfService.BookService)))
            {
                host.Open();
                Console.WriteLine("Хост WCF сервиса запущен в " + " " + DateTime.Now.ToString());
                Console.WriteLine("Доступ к серверу - localhost:5689");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Чтобы закрыть соединение, нажмите Enter");
                Console.WriteLine("-----------------------------------------");
                Console.ReadLine();
                host.Close();

            }
        }
    }
}
