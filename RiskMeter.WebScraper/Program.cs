using System;

namespace RiskMeter.WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new Service();
            service.Start();

            Console.ReadLine();
        }
    }
}
