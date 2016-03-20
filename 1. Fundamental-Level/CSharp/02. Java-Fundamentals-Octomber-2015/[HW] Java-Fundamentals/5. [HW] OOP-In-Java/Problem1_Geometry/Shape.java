package Problem1_Geometry;

import Problem1_Geometry.Vertices.Vertex;

import java.util.ArrayList;
import java.util.List;

public abstract class Shape {
    private List<Vertex> vertices;

    protected Shape(Vertex... vertices){
        this.vertices = new ArrayList();
        this.addVertices(vertices);
    }

    public List<Vertex> getVertices() {
        return vertices;
    }

    public void addVertices(Vertex[] vertices){
        for (int i = 0; i < vertices.length; i++) {
            this.vertices.add(vertices[i]);
        }
    }

    @Override
    public String toString() {
        return "Shape{" +
                "vertices=" + vertices +
                '}';
    }
}