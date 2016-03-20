package Problem1_Geometry.PlaneShapes;

import Problem1_Geometry.Vertices.Vertex2D;

public class Circle extends PlaneShape{
    private double radius;

    public Circle(Vertex2D vertex2D, double radius){
        super(vertex2D);
        this.radius = radius;
        this.perimeter = calculatePerimeter();
        this.area = calculateArea();
    }

    @Override
    public double calculateArea() {
        return Math.PI * this.radius * this.radius;
    }

    @Override
    public double calculatePerimeter() {
        return 2 * Math.PI * this.radius;
    }

    public double getRadius() {
        return radius;
    }

    public void setRadius(double radius) {
        this.radius = radius;
    }
}
