using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfService;

namespace WindowsServiceHost
{
    public partial class WindowsService : ServiceBase
    {
        public WindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Uri httpUrl = new Uri("http://localhost:5689/BookService.svc/");
            ServiceHost host = new ServiceHost(typeof(WcfService.BookService), httpUrl);
            host.AddServiceEndpoint(typeof(WcfService.IBookService), new BasicHttpBinding(), "");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;

            host.Description.Behaviors.Add(smb);
            host.Open();
        }
    }
}
