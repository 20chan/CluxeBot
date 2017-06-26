using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace CluxeBot
{
    public class Bot
    {
        public bool IsRunning { get; set; } = true;
        public TextReader In;
        public TextWriter Out;

        public Bot(TextReader input, TextWriter output)
        {
            In = input;
            Out = output;
        }

        public async void Run()
        {
            while (IsRunning)
            {
                Process(In.ReadLine());
            }
        }

        protected void Process(string message)
        {
            var methods = GetType().GetMethods();
            foreach (var method in methods)
            {
                var attrs = method.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    if (attr is CallbackAttr)
                    {
                        var at = attr as CallbackAttr;
                        if (at.IsCorrect(message))
                            method.Invoke(this, new[] { message });
                    }
                }
            }
        }

        [MeaningActCallback("알림")]
        public void Test(string message)
        {
            Out.WriteLine("Yeah Test!");
        }
    }
}
