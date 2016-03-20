using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

class ChatLogger
{
    static void Main()
    {
        DateTime currentTime = DateTime.Parse(Console.ReadLine());

        Dictionary<string, DateTime> chatLog = new Dictionary<string, DateTime>();
        string messageAndDate = Console.ReadLine().Trim();
        while (messageAndDate != "END")
        {
            string[] messageDetails = messageAndDate.Split('/');
            string message = SecurityElement.Escape(messageDetails[0].Trim());
            DateTime date = DateTime.Parse(messageDetails[1].Trim());
                                                                 
            chatLog.Add(message, date);
            messageAndDate = Console.ReadLine().Trim();
        }

        var sordetChatLog = chatLog.OrderBy(date => date.Value);
        foreach (var message in sordetChatLog)
        {
            Console.WriteLine("<div>{0}</div>", message.Key);
        }

        if (currentTime.Day == sordetChatLog.Last().Value.Day + 1)
        {
            Console.WriteLine("<p>Last active: <time>yesterday</time></p>");
        }
        else
        {
            TimeSpan resultTime = currentTime - sordetChatLog.Last().Value;
            if (resultTime.Days == 0 &&
                resultTime.Hours == 0 &&
                resultTime.Minutes == 0)
            {
                Console.WriteLine("<p>Last active: <time>a few moments ago</time></p>");
            }
            else if (resultTime.Days == 0 &&
                     resultTime.Hours == 0 &&
                     resultTime.Minutes <= 59)
            {
                Console.WriteLine("<p>Last active: <time>{0} minute(s) ago</time></p>", resultTime.Minutes);
            }
            else if (resultTime.Days == 0 &&
                     resultTime.Hours > 1 &&
                     resultTime.Hours <= 24)
            {
                Console.WriteLine("<p>Last active: <time>{0} hour(s) ago</time></p>", resultTime.Hours);
            }
            else
            {
                Console.WriteLine("<p>Last active: <time>{0:dd-MM-yyyy}</time></p>", sordetChatLog.Last().Value);
            }
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security;
//using System.Text;

//class ChatLogger
//{
//    static void Main()
//    {
//        DateTime currentTime = DateTime.Parse(Console.ReadLine().Trim());

//        SortedDictionary<DateTime, string> chatLog = new SortedDictionary<DateTime, string>();
//        string messageAndDate = Console.ReadLine().Trim();
//        while (messageAndDate != "END")
//        {
//            string[] messageDetails = messageAndDate.Split('/');
//            string message = SecurityElement.Escape(messageDetails[0].Trim());
//            DateTime date = DateTime.Parse(messageDetails[1].Trim());

//            chatLog.Add(date, message);
//            messageAndDate = Console.ReadLine().Trim();
//        }

//        foreach (var message in chatLog)
//        {
//            Console.WriteLine("<div>{0}</div>", message.Value);
//        }

//        TimeSpan timeDifference = currentTime - chatLog.Last().Key;
//         if (timeDifference.Days == 1)
//        {
//            Console.WriteLine("<p>Last active: <time>yesterday</time></p>", timeDifference.TotalMinutes);
//        }
//        else if (timeDifference.TotalSeconds < 60)
//        {
//            Console.WriteLine("<p>Last active: <time>a few moments ago</time></p>");
//        }
//        else if (timeDifference.TotalMinutes < 60)
//        {
//            Console.WriteLine("<p>Last active: <time>{0} minute(s) ago</time></p>", timeDifference.TotalMinutes);
//        }
//        else if (timeDifference.TotalHours < 24)
//        {
//            Console.WriteLine("<p>Last active: <time>{0} hours(s) ago</time></p>", (int)timeDifference.TotalHours);
//        }
//        else
//        {
//            Console.WriteLine("<p>Last active: <time>{0:dd-MM-yyyy}</time></p>", chatLog.Last().Value);
//        }
//    }
//}