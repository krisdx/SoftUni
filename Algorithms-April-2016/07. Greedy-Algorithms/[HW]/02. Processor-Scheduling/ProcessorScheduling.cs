namespace ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProcessorScheduling
    {
        public static void Main()
        {
            var tasksByValue = new SortedSet<Task>();

            int maxDeadLine = 0;
            int tasksCount = int.Parse(Console.ReadLine().Split(':')[1].Trim());
            for (int taskNumber = 1; taskNumber <= tasksCount; taskNumber++)
            {
                string[] lineArgs = Console.ReadLine()
                  .Split(new string[] { " - " },
                  StringSplitOptions.RemoveEmptyEntries);

                int value = int.Parse(lineArgs[0]);
                int deadLine = int.Parse(lineArgs[1]);
                var task = new Task(taskNumber, deadLine, value);
                tasksByValue.Add(task);

                if (deadLine > maxDeadLine)
                {
                    maxDeadLine = deadLine;
                }
            }

            var resultTasks = new LinkedList<Task>();
            int totalValue = 0;
            for (int deadLine = maxDeadLine; deadLine >= 1; deadLine--)
            {
                Task bestTask = new Task(-1, -1, -1);
                foreach (var task in tasksByValue)
                {
                    if (task.DeadLine > bestTask.DeadLine)
                    {
                        bestTask = task;
                        totalValue += task.Value;
                        break;
                    }
                }

                tasksByValue.Remove(bestTask);
                resultTasks.AddFirst(bestTask);
            }

            var orderedTasks = resultTasks
                .OrderBy(t => t.DeadLine)
                .ThenByDescending(t => t.Value)
                .ToList();
            Console.WriteLine("Optimal schedule: {0}", string.Join(" -> ", orderedTasks));
            Console.WriteLine("Total value: " + totalValue);
        }
    }
}