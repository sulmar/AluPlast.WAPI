using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000";

            WebApiService service = new WebApiService(baseAddress);
            service.Start();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

            service.Stop();


        }
    }
}
