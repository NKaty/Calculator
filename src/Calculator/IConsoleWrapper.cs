using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public interface IConsoleWrapper
    {
        string Readline();

        void WriteLine(string output1, object output2);

        void WriteLine(string output);

        void Write(string output);
    }
}
