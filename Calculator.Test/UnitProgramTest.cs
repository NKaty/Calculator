using System;
using System.Collections.Generic;
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
            Program.RunCalculator(new MockConsoleWrapper());
        }
    }

public class MockConsoleWrapper : IConsoleWrapper
    {
        Queue<string> input = new Queue<string>(new[] {"5", "2", "m", "n"});
        public string Readline()
        {
            return input.Dequeue();
        }
    }
}
