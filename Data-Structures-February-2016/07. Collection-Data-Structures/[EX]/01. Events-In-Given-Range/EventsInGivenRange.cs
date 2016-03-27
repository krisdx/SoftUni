namespace EventsInGivenRange
{
    using System;
    using Wintellect.PowerCollections;

    public class EventsInGivenRange
    {
        public static void Main()
        {
            var orderedMultiDictionary = new OrderedMultiDictionary<DateTime, string>(true);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputParams = Console.ReadLine().Split('|');

                string @event = inputParams[0].Trim();
                DateTime date = DateTime.Parse(inputParams[1].Trim());

                orderedMultiDictionary[date].Add(@event);
            }
            
            int numberOfRanges = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfRanges; i++)
            {
                string[] rangeParams = Console.ReadLine().Split('|');
                DateTime startRange = DateTime.Parse(rangeParams[0].Trim());
                DateTime endRange = DateTime.Parse(rangeParams[1].Trim());

                var eventsInRange = orderedMultiDictionary.Range(startRange, true, endRange, true);

                Console.WriteLine(eventsInRange.KeyValuePairs.Count);
                foreach (var @event in eventsInRange)
                {
                    foreach (var ev in @event.Value)
                    {
                        Console.WriteLine("{0} | {1}", ev, @event.Key);
                    }
                }
            }
        }
    }
}