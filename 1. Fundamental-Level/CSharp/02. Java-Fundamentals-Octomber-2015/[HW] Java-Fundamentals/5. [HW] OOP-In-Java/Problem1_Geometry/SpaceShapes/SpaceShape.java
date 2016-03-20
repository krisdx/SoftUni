package Problem1_Geometry.SpaceShapes;

import Problem1_Geometry.Interfaces.AreaMeasurable;
import Problem1_Geometry.Interfaces.VolumeMeasurable;
import Problem1_Geometry.Shape;
import Problem1_Geometry.Vertices.Vertex3D;

public abstract class SpaceShape extends Shape implements AreaMeasurable, VolumeMeasurable{
    protected double area;
    protected double volume;

    protected SpaceShape(Vertex3D vertex3D){
        super(vertex3D);
    }

    public double calculateArea() {
        return area;
    }

    public double calculateVolume() {
        return volume;
    }

    @Override
    public String toString() {
        return "SpaceShape{" +
                "area=" + area +
                ", volume=" + volume +
                '}';
    }
}