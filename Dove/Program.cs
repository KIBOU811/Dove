using System;

namespace Dove
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Dove Script!");

            var repl = new Repl();
            repl.Start();
        }
    }
}
