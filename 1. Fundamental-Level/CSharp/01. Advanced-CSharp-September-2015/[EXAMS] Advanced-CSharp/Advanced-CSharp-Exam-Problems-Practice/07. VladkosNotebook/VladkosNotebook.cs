using System;
using System.Collections.Generic;
using System.Linq;

class VladkosNotebook
{
    static void Main()
    {
        SortedDictionary<string, Values> notebook = new SortedDictionary<string, Values>();

        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            string[] inputLineDetails = inputLine.Split('|');
            string color = inputLineDetails[0];
            string winOrLossOrNameOrAge = inputLineDetails[1];
            string nameOrAgeOrOponent = inputLineDetails[2];

            int typeOfInput = GetTypeOfInput(winOrLossOrNameOrAge);

            if (notebook.ContainsKey(color))
            {
                if (typeOfInput == 1)
                {
                    notebook[color].oponents.Add(nameOrAgeOrOponent);
                    switch (winOrLossOrNameOrAge)
                    {
                        case "loss": notebook[color].losses++; break;
                        case "win": notebook[color].wins++; break;
                    }
                }
                else if (typeOfInput == 2)
                {
                    notebook[color].name = nameOrAgeOrOponent;
                }
                else
                {
                    notebook[color].age = nameOrAgeOrOponent;
                }
            }
            else
            {
                Values values = new Values();
                if (typeOfInput == 1)
                {
                    values.oponents.Add(nameOrAgeOrOponent);
                    switch (winOrLossOrNameOrAge)
                    {
                        case "loss": values.losses++; break;
                        case "win": values.wins++; break;
                    }
                }
                else if (typeOfInput == 2)
                {
                    values.name = nameOrAgeOrOponent;
                }
                else
                {
                    values.age = nameOrAgeOrOponent;
                }

                notebook.Add(color, values);
            }

            inputLine = Console.ReadLine();
        }

        bool hasAnyDataRecieved = Check(notebook);
        if (!hasAnyDataRecieved)
        {
            Console.WriteLine("No data recovered.");
        }

        Print(notebook);
    }

    private static bool Check(SortedDictionary<string, Values> notebook)
    {
        bool hasAnyData = false;
        foreach (var color in notebook)
        {
            if (color.Value.name != null &&
                color.Value.age != null)
            {
                hasAnyData = true;
            }
        }

        return hasAnyData;
    }

    private static void Print(SortedDictionary<string, Values> notebook)
    {
        foreach (var colorAndValues in notebook)
        {
            bool hasAllData = CheckForData(colorAndValues.Value);
            if (!hasAllData)
            {
                continue;
            }

            Console.WriteLine("Color: {0}", colorAndValues.Key);
            Console.WriteLine("-age: {0}", colorAndValues.Value.age);
            Console.WriteLine("-name: {0}", colorAndValues.Value.name);

            if (colorAndValues.Value.oponents.Count == 0)
            {
                Console.WriteLine("-opponents: (empty)");
            }
            else
            {
                colorAndValues.Value.oponents.Sort(StringComparer.Ordinal);
                Console.WriteLine("-opponents: {0}", string.Join(", ", colorAndValues.Value.oponents));
            }

            decimal rank = colorAndValues.Value.wins / colorAndValues.Value.losses;
            Console.WriteLine("-rank: {0:f2}", rank);
        }
    }

    private static bool CheckForData(Values values)
    {
        if (values.age == null ||
            values.name == null)
        {
            return false;
        }

        return true;
    }

    private static int GetTypeOfInput(string winOrLossOrNameOrAge)
    {
        if (winOrLossOrNameOrAge == "win" ||
            winOrLossOrNameOrAge == "loss")
        {
            return 1;
        }
        else if (winOrLossOrNameOrAge == "name")
        {
            return 2;
        }
        else 
        {
            return 3;
        }
    }

    private class Values
    {
        public string age;
        public string name;
        public List<string> oponents = new List<string>();
        public decimal wins = 1;
        public decimal losses = 1;
    }
}