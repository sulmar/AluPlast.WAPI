using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Service
{
    public class WebApiService
    {
        private IDisposable _webapp;

        private readonly string baseAddress;

        public WebApiService(string address)
        {
            this.baseAddress = address;
        }

        public void Start()
        {
            _webapp = WebApp.Start<Startup>(baseAddress);

            Console.WriteLine($"Service on {baseAddress} started.");
        }

        public void Stop()
        {
            _webapp.Dispose();
        }

    }
}
