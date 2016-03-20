package Problem1_Geometry.SpaceShapes;

import Problem1_Geometry.Vertices.Vertex3D;

public class Sphere extends SpaceShape {
    private double radius;

    public Sphere(Vertex3D vertex, double radius){
        super(vertex);
        this.radius  = radius;
        this.area = calculateArea();
        this.volume = calculateVolume();
    }

    public double getRadius() {
        return radius;
    }

    public void setRadius(double radius) {
        this.radius = radius;
    }

    @Override
    public double calculateArea() {
        return 4 * Math.PI * this.radius * this.radius;
    }

    @Override
    public double calculateVolume() {
        return 4 / 3 * Math.PI * this.radius * this.radius * this.radius;
    }
}