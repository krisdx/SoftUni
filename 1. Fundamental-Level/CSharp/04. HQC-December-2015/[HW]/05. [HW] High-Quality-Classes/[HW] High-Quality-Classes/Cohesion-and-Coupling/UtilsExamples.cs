namespace CohesionAndCoupling
{
    using System;
    using CohesionAndCoupling.Shapes;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(StringExtentions.GetFileExtension("example"));
            Console.WriteLine(StringExtentions.GetFileExtension("example.pdf"));
            Console.WriteLine(StringExtentions.GetFileExtension("example.new.pdf"));

            Console.WriteLine(StringExtentions.GetFileNameWithoutExtension("example"));
            Console.WriteLine(StringExtentions.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(StringExtentions.GetFileNameWithoutExtension("example.new.pdf"));

            Shape2D shape2D = new Shape2D(1, 2);
            Console.WriteLine("Distance in the 2D space = {0:f2}",
                shape2D.CalculateDistance2D(1, -2, 3, 4));

            Shape3D shape3D = new Shape3D(1, 2, 3);
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                shape3D.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            shape3D.Width = 3;
            shape3D.Height = 4;
            shape3D.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", shape3D.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", shape3D.CalculateDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", shape3D.CalculateDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", shape3D.CalculateDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", shape3D.CalculateDiagonalYZ());
        }
    }
}