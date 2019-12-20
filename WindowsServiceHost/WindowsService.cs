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
        ServiceHost host = null;
        public WindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (host != null)
            {
                host.Close();
            }
            Uri httpUrl = new Uri("http://localhost:5689/BookService.svc");
            host = new ServiceHost(typeof(WcfService.BookService), httpUrl);
            host.AddServiceEndpoint(typeof(WcfService.IBookService), new WSHttpBinding(), "");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;

            host.Description.Behaviors.Add(smb);
            host.Open();
        }

        protected override void OnStop()
        {
            if (host != null)
            {
                host.Close();
                host = null;
            }
        }
    }
}
