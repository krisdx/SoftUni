using System;
using System.Text.RegularExpressions;

class PINValidation
{
    static void Main()
    {
        string name = Console.ReadLine();
        string gender = Console.ReadLine();
        string PIN = Console.ReadLine();

        bool isNameCorrect = IsNameCorrect(name);
        bool isPINCorrent = IsPINCorrect(PIN, gender);

        if (isNameCorrect && isPINCorrent)
        {
            Console.WriteLine("{{\"name\":\"{0}\",\"gender\":\"{1}\",\"pin\":\"{2}\"}}", name, gender, PIN);
        }
        else
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
        }
    }

    public static bool IsPINCorrect(string PIN, string gender)
    {
        if (PIN.Length != 10)
        {
            return false;
        }

        int numForGender = int.Parse(PIN[8].ToString());
        if (numForGender % 2 == 1 && gender != "female")
        {
            return false;
        }

        return true;
    }

    public static bool IsNameCorrect(string name)
    {
        Regex regex = new Regex(@"^[A-Z][a-z]+\s+[A-Z][a-z]+$");
        if (regex.IsMatch(name))
        {
            return true;
        }

        return false;
    }
}