using System;
using System.Collections.Generic;
using System.Linq;

public class ArrayManipulator
{
    public static void Main()
    {
        long[] numbers = Console.ReadLine().Trim().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

        string command = Console.ReadLine();
        while (command != "end")
        {
            string[] commandDetails = command.Split();
            if (commandDetails[0] == "exchange")
            {
                long index = long.Parse(commandDetails[1]);
                if (index < 0 || index >= numbers.Length)
                {
                    Console.WriteLine("Invalid index");
                    command = Console.ReadLine();
                    continue;
                }

                List<long> subArray = new List<long>();
                for (long i = index + 1; i < numbers.Length; i++)
                {
                    subArray.Add(numbers[i]);
                }

                for (long i = 0; i <= index; i++)
                {
                    subArray.Add(numbers[i]);
                }

                numbers = subArray.ToArray();
            }
            else if (commandDetails[0] == "max")
            {
                long max = long.MinValue;
                long index = 0;
                bool hasNumber = false;
                for (long i = 0; i < numbers.Length; i++)
                {
                    if (max <= numbers[i] && numbers[i] % 2 == 1 && commandDetails[1] == "odd")
                    {
                        max = numbers[i];
                        index = i;
                        hasNumber = true;
                    }
                    else if (max <= numbers[i] && numbers[i] % 2 == 0 && commandDetails[1] == "even")
                    {
                        max = numbers[i];
                        index = i;
                        hasNumber = true;
                    }
                }

                if (hasNumber)
                {
                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine("No matches");
                }

            }
            else if (commandDetails[0] == "min")
            {
                long min = long.MaxValue;
                long index = 0;
                bool hasMinNumber = false;
                for (long i = 0; i < numbers.Length; i++)
                {
                    if (min >= numbers[i] && numbers[i] % 2 == 0 && commandDetails[1] == "even")
                    {
                        min = numbers[i];
                        index = i;
                        hasMinNumber = true;
                    }
                    else if (min >= numbers[i] && numbers[i] % 2 == 1 && commandDetails[1] == "odd")
                    {
                        min = numbers[i];
                        index = i;
                        hasMinNumber = true;
                    }
                }

                if (hasMinNumber)
                {
                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
            else if (commandDetails[0] == "first")
            {
                List<long> elements = new List<long>();

                long count = long.Parse(commandDetails[1]);
                if (count > numbers.Length)
                {
                    Console.WriteLine("Invalid count");
                }
                else
                {
                    if (commandDetails[2] == "odd")
                    {
                        for (long i = 0; i < numbers.Length; i++)
                        {
                            if (numbers[i] % 2 == 1)
                            {
                                elements.Add(numbers[i]);
                            }

                            if (elements.Count == count)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (long i = 0; i < numbers.Length; i++)
                        {
                            if (numbers[i] % 2 == 0)
                            {
                                elements.Add(numbers[i]);
                            }

                            if (elements.Count == count)
                            {
                                break;
                            }
                        }
                    }

                    Console.WriteLine("[{0}]", string.Join(", ", elements));
                }

            }
            else if (commandDetails[0] == "last")
            {
                long count = long.Parse(commandDetails[1]);
                if (count > numbers.Length)
                {
                    Console.WriteLine("Invalid count");
                }
                else
                {
                    List<long> elements = new List<long>();
                    for (long i = numbers.Length - 1; i >= 0; i--)
                    {
                        if (numbers[i] % 2 == 1 && commandDetails[2] == "odd")
                        {
                            elements.Add(numbers[i]);
                            if (elements.Count == count)
                            {
                                break;
                            }
                        }
                        else if (numbers[i] % 2 == 0 && commandDetails[2] == "even")
                        {
                            elements.Add(numbers[i]);
                            if (elements.Count == count)
                            {
                                break;
                            }
                        }
                    }

                    if (elements.Count == 0)
                    {
                        Console.WriteLine("[]");
                    }
                    else
                    {
                        elements.Reverse();
                        Console.WriteLine("[{0}]", string.Join(", ", elements));
                    }
                }
            }

            command = Console.ReadLine();
        }

        Console.WriteLine("[{0}]", string.Join(", ", numbers));
    }
}