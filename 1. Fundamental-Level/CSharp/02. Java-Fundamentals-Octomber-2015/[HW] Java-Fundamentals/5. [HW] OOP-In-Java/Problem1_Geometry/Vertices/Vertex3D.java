package Problem1_Geometry.Vertices;

public class Vertex3D extends Vertex{
    private int z;

    public Vertex3D(int x, int y, int z) {
        super(x, y);
        this.z = z;
    }

    public int getZ() {
        return z;
    }

    public void setZ(int z) {
        this.z = z;
    }

    @Override
    public String toString() {
        return String.format("{3D Vertex: x = %d, y = %d, z = %d}", this.x, this.y, this.z);
    }
}