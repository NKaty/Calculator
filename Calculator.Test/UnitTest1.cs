using System;
using Xunit;

namespace Calculator.Test
{
    public class CalculatorTests
    {
        [Fact]
        public void ShouldAdd()
        {
            Assert.Equal(100 + 23, Calculator.DoOperation(100, 23, "a"));
        }
        [Fact]
        public void ShouldSubtract()
        {
            Assert.Equal(100 - 23.18, Calculator.DoOperation(100, 23.18, "s"));
        }
        [Fact]
        public void ShouldMultiply()
        {
            Assert.Equal(100 * 23.18, Calculator.DoOperation(100, 23.18, "m"));
        }
        [Fact]
        public void ShouldDivide()
        {
            Assert.Equal(100 / 23.18, Calculator.DoOperation(100, 23.18, "d"));
        }
        [Fact]
        public void ShouldNotDivideByZero()
        {
            Assert.Equal(double.NaN, Calculator.DoOperation(100, 0, "d"));
        }
        [Fact]
        public void ShouldNotDoUnknownOperation()
        {
            Assert.Equal(double.NaN, Calculator.DoOperation(100, 10, "k"));
        }
    }
}
