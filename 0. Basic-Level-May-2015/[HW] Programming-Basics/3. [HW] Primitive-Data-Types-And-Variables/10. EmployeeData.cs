using System;

// A marketing company wants to keep record of its employees. Each record would have the following characteristics:

// •	First name
//•	Last name
//•	Age (0...100)
//•	Gender (m or f)
//•	Personal ID number (e.g. 8306112507)
//•	Unique employee number (27560000…27569999)

//Declare the variables needed to keep the information for a single employee using appropriate primitive data types. Use descriptive names. Print the data at the console.


class EmployeeData
{
    static void Main()
    {
        string firstName = "Kristiyan";
        Console.WriteLine("First name: {0}", firstName);

        string lastName = "Duba";
        Console.WriteLine("Last name: {0}", lastName);

        int age = 19;
        Console.WriteLine("Age: {0}", age);

        string gender = "M";
        Console.WriteLine("Genedr: {0}", gender);

        long PersonalIDNumber = 9311913021;
        Console.WriteLine("Personal ID number : {0}", PersonalIDNumber);

        long UniqueEmployeeNumber = 21160571;
        Console.WriteLine("Unique employee number: {0}", UniqueEmployeeNumber);

        Console.WriteLine();
    }
}