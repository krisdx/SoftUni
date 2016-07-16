package problem8_ShapesVolume;

public class VolumeCalculator {
    public static double calcVolume(Cube cube) {
        return cube.getSideLength() * cube.getSideLength() * cube.getSideLength();
    }

    public static double calcVolume(Cylinder cylinder) {
        return Math.PI * (cylinder.getRadius() * cylinder.getRadius()) * cylinder.getHeigth();
    }

    public static  double calcVolume(TriangularPrism triangularPrism) {
        return 0.5 * triangularPrism.getBaseSide() * triangularPrism.getHeight() * triangularPrism.getLength();
    }
}