using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskMeter.WebScraper
{
    public class Logger
    {
        public static bool IsDebug = true;

        public static void Log(string message)
        {
            if (IsDebug)
            {
                Console.WriteLine(message);
            }
        }
    }
}
