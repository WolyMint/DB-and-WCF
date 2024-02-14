using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var host = new ServiceHost(typeof(WCF.ServiceGame)))
            {
                host.Open();
                Console.WriteLine("Сервер запущен!");
                Console.ReadLine();
            }
        }
    }
}
