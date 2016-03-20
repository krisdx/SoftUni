using System;

class LabyrinthDash
{
    static int n = int.Parse(Console.ReadLine());
    static char[][] labyrinth = new char[n][];
    static int row = 0;
    static int col = 0;
    static int lives = 3;

    static void Main()
    {
        for (int i = 0; i < n; i++)
        {
            labyrinth[i] = Console.ReadLine().ToCharArray();
        }
        char[] comands = Console.ReadLine().ToCharArray();

        int totalMovesMade = 0;
        for (int i = 0; i < comands.Length; i++)
        {
            char direction = comands[i];
            totalMovesMade++;

            if (direction == '^')
            {
                bool isOutsideOfLabyrinth = IsOutsideOfLabyrinth(row - 1, col);
                if (isOutsideOfLabyrinth)
                {
                    Console.WriteLine("Fell off a cliff! Game Over!");
                    break;
                }
                else
                {
                    row--;
                    if (labyrinth[row][col] == '|' || labyrinth[row][col] == '_')
                    {
                        Console.WriteLine("Bumped a wall.");
                        row++;
                        totalMovesMade--;
                    }
                    else if (labyrinth[row][col] == '@' || labyrinth[row][col] == '#' || labyrinth[row][col] == '*')
                    {
                        lives--;
                        Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                        if (lives == 0)
                        {
                            Console.WriteLine("No lives left! Game Over!");
                            break;
                        }
                    }
                    else if (labyrinth[row][col] == '$')
                    {
                        lives++;
                        Console.WriteLine("Awesome! Lives left: {0}", lives);
                        labyrinth[row][col] = '.';
                    }
                    else if (char.IsWhiteSpace(labyrinth[row][col]))
                    {
                        Console.WriteLine("Fell off a cliff! Game Over!");
                        break;
                    }
                    else if (labyrinth[row][col] == '.')
                    {
                        Console.WriteLine("Made a move!");
                    }
                }
            }
            else if (direction == 'v')
            {
                bool isOutsideOfLabyrinth = IsOutsideOfLabyrinth(row + 1, col);
                if (isOutsideOfLabyrinth)
                {
                    Console.WriteLine("Fell off a cliff! Game Over!");
                    break;
                }
                else
                {
                    row++;
                    if (labyrinth[row][col] == '|' || labyrinth[row][col] == '_')
                    {
                        Console.WriteLine("Bumped a wall.");
                        row--;
                        totalMovesMade--;
                    }
                    else if (labyrinth[row][col] == '@' || labyrinth[row][col] == '#' || labyrinth[row][col] == '*')
                    {
                        lives--;
                        Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                        if (lives == 0)
                        {
                            Console.WriteLine("No lives left! Game Over!");
                            break;
                        }
                    }
                    else if (labyrinth[row][col] == '$')
                    {
                        lives++;
                        Console.WriteLine("Awesome! Lives left: {0}", lives);
                        labyrinth[row][col] = '.';
                    }
                    else if (char.IsWhiteSpace(labyrinth[row][col]))
                    {
                        Console.WriteLine("Fell off a cliff! Game Over!");
                        break;
                    }
                    else if (labyrinth[row][col] == '.')
                    {
                        Console.WriteLine("Made a move!");
                    }
                }
            }
            else if (direction == '<')
            {
                bool isOutsideOfLabyrinth = IsOutsideOfLabyrinth(row, col - 1);
                if (isOutsideOfLabyrinth)
                {
                    Console.WriteLine("Fell off a cliff! Game Over!");
                    break;
                }
                else
                {
                    col--;
                    if (labyrinth[row][col] == '|' || labyrinth[row][col] == '_')
                    {
                        Console.WriteLine("Bumped a wall.");
                        col++;
                        totalMovesMade--;
                    }
                    else if (labyrinth[row][col] == '@' || labyrinth[row][col] == '#' || labyrinth[row][col] == '*')
                    {
                        lives--;
                        Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                        if (lives == 0)
                        {
                            Console.WriteLine("No lives left! Game Over!");
                            break;
                        }
                    }
                    else if (labyrinth[row][col] == '$')
                    {
                        lives++;
                        Console.WriteLine("Awesome! Lives left: {0}", lives);
                        labyrinth[row][col] = '.';
                    }
                    else if (char.IsWhiteSpace(labyrinth[row][col]))
                    {
                        Console.WriteLine("Fell off a cliff! Game Over!");
                        break;
                    }
                    else if (labyrinth[row][col] == '.')
                    {
                        Console.WriteLine("Made a move!");
                    }
                }
            }
            else if (direction == '>')
            {
                bool isOutsideOfLabyrinth = IsOutsideOfLabyrinth(row, col + 1);
                if (isOutsideOfLabyrinth)
                {
                    Console.WriteLine("Fell off a cliff! Game Over!");
                    break;
                }
                else
                {
                    col++;
                    if (labyrinth[row][col] == '|' || labyrinth[row][col] == '_')
                    {
                        Console.WriteLine("Bumped a wall.");
                        col--;
                        totalMovesMade--;
                    }
                    else if (labyrinth[row][col] == '@' || labyrinth[row][col] == '#' || labyrinth[row][col] == '*')
                    {
                        lives--;
                        Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                        if (lives == 0)
                        {
                            Console.WriteLine("No lives left! Game Over!");
                            break;
                        }
                    }
                    else if (labyrinth[row][col] == '$')
                    {
                        lives++;
                        Console.WriteLine("Awesome! Lives left: {0}", lives);
                        labyrinth[row][col] = '.';
                    }
                    else if (char.IsWhiteSpace(labyrinth[row][col]))
                    {
                        Console.WriteLine("Fell off a cliff! Game Over!");
                        break;
                    }
                    else if (labyrinth[row][col] == '.')
                    {
                        Console.WriteLine("Made a move!");
                    }
                }
            }
        }

        Console.WriteLine("Total moves made: {0}", totalMovesMade);
    }

    static bool IsOutsideOfLabyrinth(int row, int col)
    {
        if (row > labyrinth.GetLength(0) - 1 || row < 0)
        {
            return true;
        }
        if (col > labyrinth[row].GetLength(0) - 1 || col < 0)
        {
            return true;
        }

        return false;
    }
}