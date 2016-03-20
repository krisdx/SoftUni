using System;
using System.Linq;

class TextBombardment
{
    static void Main()
    {
        string inputText = Console.ReadLine();
        int width = int.Parse(Console.ReadLine());
        string columns = Console.ReadLine();

        int[] bombs = columns.Split(' ').Select(int.Parse).ToArray();
        char[] text = inputText.ToCharArray();

        for (int bombCol = 0; bombCol < bombs.Length; bombCol++)
        {
            for (int col = 0; col < text.Length; col++)
            {
                if (col == bombs[bombCol])
                {
                    int currentColBomb = bombs[bombCol];
                    do
                    {
                        text[currentColBomb] = ' ';
                        currentColBomb += width;
                        if (currentColBomb >= text.Length)
                        {
                            break;
                        }
                    } while (text[currentColBomb] != ' ');
                }
            }
        }

        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
        }
    }
}