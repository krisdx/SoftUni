using System;
using System.Collections.Generic;
using System.Linq;

// Write a program that receives some info from the console about people and their phone numbers.

// You are free to choose the manner in which the data is entered; each entry should have just one name and one number (both of them strings). 

// After filling this simple phonebook, upon receiving the command "search", your program should be able to perform a search of a contact by name and print her details in format "{name} -> {number}". In case the contact isn't found, print "Contact {name} does not exist."

// *Bonus: What happens if the user enters the same name twice in the phonebook? Modify your program to keep multiple phone numbers per contact.

class Phonebook
{
    static void Main()
    {
        Dictionary<string, List<string>> phoneBook = new Dictionary<string, List<string>>();

        string nameAndPhoneNumber = Console.ReadLine().Trim();
        while (nameAndPhoneNumber != "search")
        {
            List<string> phone = nameAndPhoneNumber.Split('-').ToList();
            string contactName = phone[0];
            string contactNumber = phone[1];
            if (phoneBook.ContainsKey(contactName))
            {
                phoneBook[contactName].Add(contactNumber);
            }
            else
            {
                phone.Remove(phone.First());
                phoneBook.Add(contactName, phone);
            }

            nameAndPhoneNumber = Console.ReadLine().Trim();
        }

        string targetName = Console.ReadLine().Trim();
        while (!string.IsNullOrEmpty(targetName))
        {
            if (phoneBook.ContainsKey(targetName))
            {
                Console.WriteLine("{0} -> {1}", targetName, string.Join(", ", phoneBook[targetName]));
            }
            else
            {
                Console.WriteLine("Contact \"{0}\" does not exist.", targetName);
            }

            targetName = Console.ReadLine().Trim();
        }
    }
}