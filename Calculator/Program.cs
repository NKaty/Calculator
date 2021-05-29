using System;

namespace Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunCalculator(new ConsoleWrapper());
        }

        public static void RunCalculator(IConsoleWrapper consoleWrapper)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            consoleWrapper.WriteLine("Console Calculator in C#\r");
            consoleWrapper.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Ask the user to type the first number.
                consoleWrapper.Write("Type a number, and then press Enter: ");
                numInput1 = consoleWrapper.Readline();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    consoleWrapper.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = consoleWrapper.Readline();
                }

                // Ask the user to type the second number.
                consoleWrapper.Write("Type another number, and then press Enter: ");
                numInput2 = consoleWrapper.Readline();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    consoleWrapper.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = consoleWrapper.Readline();
                }

                // Ask the user to choose an operator.
                consoleWrapper.WriteLine("Choose an operator from the following list:");
                consoleWrapper.WriteLine("\ta - Add");
                consoleWrapper.WriteLine("\ts - Subtract");
                consoleWrapper.WriteLine("\tm - Multiply");
                consoleWrapper.WriteLine("\td - Divide");
                consoleWrapper.Write("Your option? ");

                string op = consoleWrapper.Readline();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        consoleWrapper.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else consoleWrapper.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    consoleWrapper.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                consoleWrapper.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                consoleWrapper.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (consoleWrapper.Readline() == "n") endApp = true;

                consoleWrapper.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }
}
