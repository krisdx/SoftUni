package Problem1_Geometry.SpaceShapes;

import Problem1_Geometry.Vertices.Vertex3D;

public class SquarePyramid extends SpaceShape{
    private double width;
    private double height;

    public SquarePyramid(Vertex3D vertex3D, double width, double height) {
        super(vertex3D);
        this.width = width;
        this.height = height;
        this.area = calculateArea();
        this.volume= calculateVolume();
    }

    public double getWidth() {
        return width;
    }

    public void setWidth(double width) {
        this.width = width;
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        this.height = height;
    }

    @Override
    public double calculateVolume() {
        return this.width * this.width * (this.height / 3);
    }

    @Override
    public double calculateArea() {
        return this.width * this.width + 2 * this.width * Math.sqrt((this.width*this.width / 4) + this.height * this.height);
    }
}
