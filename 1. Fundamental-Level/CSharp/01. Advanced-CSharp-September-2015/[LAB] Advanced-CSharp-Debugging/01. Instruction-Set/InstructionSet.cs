using System;

class InstructionSet
{
    static void Main()
    {
        string command = Console.ReadLine();

        long result = 0;
        while (command != "END")
        {
            string[] commandDetails = command.Split();
            string action = commandDetails[0];

            switch (action)
            {
                case "INC":
                    {
                        long operand = long.Parse(commandDetails[1]);
                        result = operand + 1;
                        break;
                    }
                case "DEC":
                    {
                        long operand = long.Parse(commandDetails[1]);
                        result = operand - 1;
                        break;
                    }
                case "ADD":
                    {
                        long operandOne = long.Parse(commandDetails[1]);
                        long operandTwo = long.Parse(commandDetails[2]);
                        result = operandOne + operandTwo;
                        break;
                    }
                case "MLA":
                    {
                        long operandOne = long.Parse(commandDetails[1]);
                        long operandTwo = long.Parse(commandDetails[2]);
                        result = operandOne * operandTwo;
                        break;
                    }
            }

            Console.WriteLine(result);

            command = Console.ReadLine();
        }
    }
}