using System;
using Nancy.Hosting.Self;
using Nancy;
using System.Diagnostics;

namespace NancySelfHost
{
    public class Program
    {

        public class IndexModule : NancyModule
        {
            public IndexModule()
            {
                

                Get("/", _ =>
                { 
                    return Response.AsFile("index.html", "text/html");
                });


                Get("/quinev1", _ =>
                {
                    return Response.AsFile("quinev1.html", "text/html");
                });

                Get("/quinetestv1", _ =>
                {
                    return Response.AsFile("quinetestv1.html", "text/html");
                });

            }
        }

        static void Main(string[] args)
        {


            string _url = "http://localhost";
            int _port = 12345;
            var uri = new Uri($"{_url}:{_port}/");


            var configuration = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };

            var host = new NancyHost(configuration, uri); 
            host.Start(); // start hosting

            Console.WriteLine($"Started listennig port {_port}");
            Console.WriteLine($"URL {_url}:{_port}/");

            try
            {
                Process.Start("IExplore.exe", $"{_url}:{_port}/");
            }
            catch
            { }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            host.Stop();  // stop hosting
        }
    }
}
