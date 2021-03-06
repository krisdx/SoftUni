﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class SimpleExpression
{
    static Regex numPattern = new Regex(@"[\d.]*\d+");
    static Regex operatorsPattern = new Regex(@"-|\+");

    static Stack<string> stack = new Stack<string>();
    static Queue<string> queue = new Queue<string>();

    static decimal n;

    static void Main()
    {
        string expression = Console.ReadLine();
        List<string> seperatedExpression = SeparateExpression(expression);

        ShuntingYardAlgorithm(seperatedExpression);

        ReversePolishNotation();

        Console.WriteLine(stack.Peek());
    }

    static List<string> SeparateExpression(string input)
    {
        StringBuilder trimmedInput = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != ' ')
            {
                trimmedInput.Append(input[i]);
            }
        }
        input = trimmedInput.ToString();

        List<string> separatedExpression = new List<string>();

        int index = -1;
        while (input.Length > 0)
        {
            index++;
            separatedExpression.Add(numPattern.Match(input).ToString());
            input = input.Remove(0, separatedExpression[index].Length);
            if (input.Length <= 0)
            {
                break;
            }

            index++;
            separatedExpression.Add(operatorsPattern.Match(input).ToString());
            input = input.Remove(0, separatedExpression[index].Length);
            if (input.Length <= 0)
            {
                break;
            }
        }

        return separatedExpression;
    }

    static void ShuntingYardAlgorithm(List<string> seperatedExpression)
    {
        decimal n;
        for (int i = seperatedExpression.Count - 1; i >= 0; i--)
        {
            if (decimal.TryParse(seperatedExpression[i], out n))
            {
                queue.Enqueue(seperatedExpression[i]);
            }
            else
            {
                stack.Push(seperatedExpression[i]);
            }
        }

        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
        }
    }

    static void ReversePolishNotation()
    {
        while (queue.Count > 0)
        {
            if (decimal.TryParse(queue.Peek(), out n))
            {
                stack.Push(queue.Dequeue());
            }
            else
            {
                decimal operandOne = decimal.Parse(stack.Pop());
                decimal operandTwo = decimal.Parse(stack.Pop());
                decimal result;
                if (queue.Peek() == "+")
                {
                    result = operandOne + operandTwo;
                }
                else
                {
                    result = operandOne - operandTwo;
                }

                stack.Push(result.ToString());
                queue.Dequeue();
            }
        }
    }
}