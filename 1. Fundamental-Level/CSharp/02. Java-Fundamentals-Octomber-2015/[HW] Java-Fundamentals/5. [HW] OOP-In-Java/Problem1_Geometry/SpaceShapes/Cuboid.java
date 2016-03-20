package Problem1_Geometry.SpaceShapes;

import Problem1_Geometry.Vertices.Vertex3D;

public class Cuboid extends SpaceShape{
    private double width;
    private double height;
    private double depth;

    public Cuboid(Vertex3D vertex3D) {
        super(vertex3D);
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

    public double getDepth() {
        return depth;
    }

    public void setDepth(double depth) {
        this.depth = depth;
    }

    @Override
    public double calculateVolume() {
        return this.width * this.depth * this.height;
    }

    @Override
    public double calculateArea() {
        return this.width * 2 + this.depth * 2 + this.height * 2;
    }
}