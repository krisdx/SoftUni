package Problem1_Geometry.PlaneShapes;

import Problem1_Geometry.Interfaces.AreaMeasurable;
import Problem1_Geometry.Interfaces.PerimeterMeasurable;
import Problem1_Geometry.Shape;
import Problem1_Geometry.Vertices.Vertex2D;

public abstract class PlaneShape extends Shape implements AreaMeasurable , PerimeterMeasurable{
    protected double area;
    protected double perimeter;

    public PlaneShape(Vertex2D... vertex) {
        super(vertex);
    }

    public double getArea() {
        return area;
    }

    public double getPerimeter() {
        return perimeter;
    }

    public abstract double calculateArea();
    public abstract double calculatePerimeter();

    @Override
    public String toString() {
        return "PlaneShape{" +
                "area=" + area +
                ", perimeter=" + perimeter +
                '}';
    }
}