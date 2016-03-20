using System;
using System.Collections.Generic;
using System.Linq;

class Weightlifting
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        SortedDictionary<string, SortedDictionary<string, long>> athletesTrainingLog = new SortedDictionary<string, SortedDictionary<string, long>>();
        for (int i = 0; i < n; i++)
        {
            string[] athleteTrainingDetails = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string athleteName = athleteTrainingDetails[0];
            string exercise = athleteTrainingDetails[1];
            long weigthLifted = long.Parse(athleteTrainingDetails[2]);

            if (athletesTrainingLog.ContainsKey(athleteName))
            {
                if (athletesTrainingLog[athleteName].ContainsKey(exercise))
                {
                    athletesTrainingLog[athleteName][exercise] += weigthLifted;
                }
                else
                {
                    athletesTrainingLog[athleteName].Add(exercise, weigthLifted);
                }
            }
            else
            {
                SortedDictionary<string, long> exerciseAndWeigthLifted = new SortedDictionary<string, long>(){
                        {exercise, weigthLifted}
                    };
                athletesTrainingLog.Add(athleteName, exerciseAndWeigthLifted);
            }
        }

        PrintLog(athletesTrainingLog);
    }

    static void PrintLog(SortedDictionary<string, SortedDictionary<string, long>> athletesTrainingLog)
    {
        foreach (var athleteLog in athletesTrainingLog)
        {
            Console.Write("{0} : ", athleteLog.Key);
            int length = athleteLog.Value.Count;
            int counter = 0;
            foreach (var exerciseAndWeightLifted in athleteLog.Value)
            {
                counter++;
                if (counter != length)
                {
                    Console.Write("{0} - {1} kg, ", exerciseAndWeightLifted.Key, exerciseAndWeightLifted.Value);
                }
                else
                {
                    Console.Write("{0} - {1} kg", exerciseAndWeightLifted.Key, exerciseAndWeightLifted.Value);
                }
            }
            Console.WriteLine();
        }
    }
}