using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CluxeBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new Bot(Console.In, Console.Out);
            bot.Run();
            
        }
    }
}
