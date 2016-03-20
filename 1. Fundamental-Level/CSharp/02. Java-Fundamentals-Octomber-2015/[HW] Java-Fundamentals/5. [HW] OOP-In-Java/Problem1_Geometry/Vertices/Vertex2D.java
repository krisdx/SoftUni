package Problem1_Geometry.Vertices;

public class Vertex2D extends Vertex{
    public Vertex2D(int x, int y) {
        super(x, y);
    }

    @Override
    public String toString() {
        return String.format("{2D Vertex: x = %d, y = %d}", this.x, this.y);
    }
}