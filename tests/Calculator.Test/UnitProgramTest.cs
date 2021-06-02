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
            IConsoleWrapper consoleWrapper = new MockConsoleWrapper() { InputQueue = new Queue<string>(new[] { "5", "2", "m", "n" }) };
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
            MockConsoleWrapper mockConsoleWrpper = new MockConsoleWrapper() { InputQueue = new Queue<string>(new [] { "5", "2", "m", "n" })};
            Program.RunCalculator(mockConsoleWrpper);
            Assert.Equal("Your result: 10", mockConsoleWrpper.OutputList[10].Trim());
        }

        [Theory]
        [InlineData(new[] { "a", "5", "2", "m", "n" }, "Your result: 10", 11)]
        [InlineData(new[] { "5", "a", "2", "m", "n" }, "Your result: 10", 11)]
        [InlineData(new[] { "5", "0", "d", "n" }, "This operation will result in a mathematical error.", 10)]
        [InlineData(new[] { "5", "2", "k", "n" }, "Oh no! An exception occurred trying to do the math.\n - Details: Invalid operation.", 10)]
        public void ShouldGiveAppropriateMessage(string [] args, string message, int index)
        {
            MockConsoleWrapper mockConsoleWrpper = new MockConsoleWrapper() { InputQueue = new Queue<string>(args) };
            Program.RunCalculator(mockConsoleWrpper);
            Assert.Equal(message, mockConsoleWrpper.OutputList[index].Trim());
        }
    }

    public class MockConsoleWrapper : IConsoleWrapper
    {
        public Queue<string> InputQueue { get; set; } = new Queue<string>();
        public List<string> OutputList { get; set; } = new List<string>();
        public string Readline()
        {
            return InputQueue.Dequeue();
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
