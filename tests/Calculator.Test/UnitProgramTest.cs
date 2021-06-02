using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Calculator.Test
{
    public class UnitProgramTest
    {
        [Fact]
        public void ShouldReceiveUserInput()
        {
            IConsoleWrapper consoleWrapper = new MockConsoleWrapper();
            string userInput1 = consoleWrapper.Readline();
            Assert.Equal("5", userInput1);
            string userInput2 = consoleWrapper.Readline();
            Assert.Equal("2", userInput2);
            string userInput3 = consoleWrapper.Readline();
            Assert.Equal("m", userInput3);
            string userInput4 = consoleWrapper.Readline();
            Assert.Equal("n", userInput4);
        }
        [Fact]
        public void ShouldMultiplyFiveAndTwo()
        {
            MockConsoleWrapper mockConsoleWrpper = new MockConsoleWrapper();
            Program.RunCalculator(mockConsoleWrpper);
            Assert.Equal("Your result: 10", mockConsoleWrpper.OutputList[10].Trim());
        }
    }

    public class MockConsoleWrapper : IConsoleWrapper
    {
        Queue<string> inputQueue = new Queue<string>(new[] {"5", "2", "m", "n"});
        public List<string> OutputList { get; set; } = new List<string>();
        public string Readline()
        {
            return inputQueue.Dequeue();
        }

        public void Write(string output)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                Console.Write(output);
                OutputList.Add(stringWriter.ToString());
            }
        }

        public void WriteLine(string output)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                Console.WriteLine(output);
                OutputList.Add(stringWriter.ToString());
            }
        }

        public void WriteLine(string output1, object output2)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                Console.WriteLine(output1, output2);
                
                OutputList.Add(stringWriter.ToString());
            }
        }
    }
}
