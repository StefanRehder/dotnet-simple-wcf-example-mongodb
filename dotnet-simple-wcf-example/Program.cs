using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using HeroServiceContracts;

namespace SelfHostedWCFExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:8210");
            WebServiceHost host = new WebServiceHost(typeof(HeroService), uri);
            ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IHeroService), new WebHttpBinding(), "");
            ServiceDebugBehavior stp = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            stp.HttpHelpPageEnabled = false;
            HeroService.ConnectToDatabase();
            host.Open();
            Console.WriteLine($"The service is up and running on {uri.AbsoluteUri}");
            Console.WriteLine("Press [Enter] to close the host.");
            Console.ReadLine();
            host.Close();
        }
    }
}
