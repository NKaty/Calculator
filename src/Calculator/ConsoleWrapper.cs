using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public string Readline()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string output1, object output2)
        {
            Console.WriteLine(output1, output2);
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public void Write(string output)
        {
            Console.Write(output);
        }
    }
}
