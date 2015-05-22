using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blatt2;

namespace Blatt2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a numeric equation or a file with numeric equations.");

            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a numeric equation or a file with numeric equations.");
            }
            else
            {
                Parser parser = new Parser();
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] != null && args[i] != "")
                    {
                        System.Console.WriteLine(parser.parse(args[i]));
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
