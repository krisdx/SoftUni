namespace Methods
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToLetters(5));

            Console.WriteLine(GetMaxNumber(5, -1, 3, 2, 14, 2, 3));

            PrintFormatNumber(1.3, "f");
            PrintFormatNumber(0.75, "%");
            PrintFormatNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalculateDistanceBetweenTwoPoints(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student()
            {
                FirstName = "Peter",
                LastName = "Ivanov"
            };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student()
            {
                FirstName = "Stella",
                LastName = "Markova"
            };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }

        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            // I didn't understand what is "s".
            double s = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));

            return area;
        }

        public static string NumberToLetters(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Unknown number - {0}", number));
            }
        }

        public static int GetMaxNumber(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException("The array is empty.");
            }

            int maxNumber = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }

            return maxNumber;
        }

        public static void PrintFormatNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }

        public static double CalculateDistanceBetweenTwoPoints(double x1, double y1, double x2, double y2, out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = y1 == y2;
            isVertical = x1 == x2;

            double distanceBetweenPoints = Math.Sqrt(
                (x2 - x1) * (x2 - x1) + 
                (y2 - y1) * (y2 - y1));
            return distanceBetweenPoints;
        }
    }
}