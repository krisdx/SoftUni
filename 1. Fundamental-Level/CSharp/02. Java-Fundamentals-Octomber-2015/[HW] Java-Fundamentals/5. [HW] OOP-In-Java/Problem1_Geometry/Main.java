package Problem1_Geometry;

import Problem1_Geometry.Interfaces.PerimeterMeasurable;
import Problem1_Geometry.Interfaces.VolumeMeasurable;
import Problem1_Geometry.PlaneShapes.Circle;
import Problem1_Geometry.PlaneShapes.PlaneShape;
import Problem1_Geometry.PlaneShapes.Rectangle;
import Problem1_Geometry.PlaneShapes.Triangle;
import Problem1_Geometry.SpaceShapes.Cuboid;
import Problem1_Geometry.SpaceShapes.Sphere;
import Problem1_Geometry.SpaceShapes.SquarePyramid;
import Problem1_Geometry.Vertices.Vertex2D;
import Problem1_Geometry.Vertices.Vertex3D;

import java.util.*;

public class Main {
    public static void main(String[] args) {
        List<Shape> shapes = new ArrayList<>();
        shapes.add(new Triangle(new Vertex2D(60, 15), new Vertex2D(10, 17), new Vertex2D(30, 15)));
        shapes.add(new Cuboid(new  Vertex3D(15 , 16, 17)));
        shapes.add(new Sphere(new Vertex3D(12, -6, 5), 13.0));
        shapes.add(new SquarePyramid(new Vertex3D(12, -6, 5), 41, 14.5));
        shapes.add(new Circle(new Vertex2D(15, 15), 14.5));
        shapes.add(new Rectangle(new Vertex2D(15, 15), 15, 20));

        /*for (int i = 0; i < shapes.size(); i++) {
            System.out.println(shapes.get(i));
        }*/

        shapes.stream()
                .filter(shape -> shape instanceof VolumeMeasurable)
                .map(shape1 -> (VolumeMeasurable) shape1)
                .filter(spaceShape -> spaceShape.calculateVolume() >= 40)
                .forEach(shape -> System.out.println(shape));

        System.out.println();

        shapes.stream()
                .filter(shape -> shape instanceof PerimeterMeasurable)
                .map(shape -> (PerimeterMeasurable) shape)
                .sorted((shape1, shape2) -> Double.compare(shape1.calculatePerimeter(), shape2.calculatePerimeter()))
                .forEach(shape -> System.out.println(shape));
    }
}