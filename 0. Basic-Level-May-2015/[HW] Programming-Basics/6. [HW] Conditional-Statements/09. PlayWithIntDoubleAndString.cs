using System;

// Write a program that, depending on the user’s choice, inputs an int, double or string variable. If the variable is int or double, the program increases it by one. If the variable is a string, the program appends "*" at the end. Print the result at the console. Use switch statement. 
 

class PlayWithIntDoubleAndString
{
    static void Main()
    {
        Console.Write("Please, choose a type: \n1 ---> int\n2 ---> double\n3 ---> string\n\nI choose: ");
        int choice = int.Parse(Console.ReadLine());

        if (1 < choice && choice > 3)
        {
            Console.WriteLine("\nSorry, your choice didn't mach... \n");
        }
        else
        {
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.Write("Please, enter an integer: ");
                    int integer = int.Parse(Console.ReadLine());
                    integer = integer + 1;
                    Console.WriteLine("\nResult: {0}\n", integer);
                    break;
                case 2:
                    Console.Write("Please, enter a double: ");
                    double doubleNumber = double.Parse(Console.ReadLine());
                    doubleNumber = doubleNumber + 1;
                    Console.WriteLine("\nResult: {0}\n", doubleNumber);
                    break;
                case 3:
                    Console.Write("Please, enter a string: ");
                    string str = Console.ReadLine();
                    str = str + '*';
                    Console.WriteLine("\nResult: {0}\n", str);
                    break;
            }
        }    
    }
}