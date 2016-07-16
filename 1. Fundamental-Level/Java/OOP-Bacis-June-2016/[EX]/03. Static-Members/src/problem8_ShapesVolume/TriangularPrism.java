package problem8_ShapesVolume;

public class TriangularPrism {
    private double baseSide;
    private double height;
    private double length;

    public TriangularPrism(double baseSide, double height, double length) {
        this.baseSide = baseSide;
        this.height = height;
        this.length = length;
    }

    public double getBaseSide() {
        return this.baseSide;
    }

    public double getHeight() {
        return this.height;
    }

    public double getLength() {
        return this.length;
    }
}