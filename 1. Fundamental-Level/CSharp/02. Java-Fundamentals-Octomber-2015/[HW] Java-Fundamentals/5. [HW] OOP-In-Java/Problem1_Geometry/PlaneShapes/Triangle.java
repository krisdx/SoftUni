package Problem1_Geometry.PlaneShapes;

import Problem1_Geometry.Vertices.Vertex2D;

public class Triangle extends PlaneShape{
    private Vertex2D a;
    private Vertex2D b;
    private Vertex2D c;

    public Triangle(Vertex2D a, Vertex2D b, Vertex2D c ) {
        super(a, b, c);
        this.a = a;
        this.b = b;
        this.c = c;
        this.area = calculateArea();
        this.perimeter = calculatePerimeter();
    }

    @Override
    public double calculateArea() {
        return Math.abs(((this.a.getX() * (this.b.getY() - this.c.getY()))
                + (this.b.getX() * (this.c.getY() - this.a.getY()))
                + (this.c.getX() * (this.a.getY() - this.b.getY()))) / 2);
    }

    @Override
    public double calculatePerimeter() {
        double sideAB = Math.sqrt(((this.b.getX() - this.a.getX()) * (this.b.getX() - this.a.getX())) + ((this.b.getY() - this.a.getY()) * (this.b.getY() - this.a.getY())));
        double sideBC = Math.sqrt(((this.c.getX() - this.b.getX()) * (this.c.getX() - this.b.getX())) + ((this.c.getY() - this.b.getY()) * (this.c.getY() - this.b.getY())));
        double sideAC = Math.sqrt(((this.c.getX() - this.a.getX()) * (this.c.getX() - this.a.getX())) + ((this.c.getY() - this.a.getY()) * (this.c.getY() - this.a.getY())));
        return sideAB + sideBC + sideAC;
    }

    @Override
    public String toString() {
        return "Triangle{" +
                "a=" + a +
                ", b=" + b +
                ", c=" + c +
                '}';
    }
}