package Problem1_Geometry.PlaneShapes;

import Problem1_Geometry.Vertices.Vertex2D;

public class Rectangle extends PlaneShape{
    private double width;
    private double height;

    public Rectangle(Vertex2D vertex, double width, double height ) {
        super(vertex);
        this.width = width;
        this.height = height;
        this.area = calculateArea();
        this.perimeter = calculatePerimeter();

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
    public double calculateArea() {
        return this.width * this.height;
    }

    @Override
    public double calculatePerimeter() {
        return 2 * (this.width + this.height);
    }
}