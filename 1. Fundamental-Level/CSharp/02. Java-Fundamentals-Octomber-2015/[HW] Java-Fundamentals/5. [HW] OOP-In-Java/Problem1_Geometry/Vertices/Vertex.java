package Problem1_Geometry.Vertices;

public class Vertex {
    protected int x;
    protected int y;

    public Vertex(int x, int y){
        this.x = x;
        this.y = y;
    }

    public int getY() {
        return y;
    }

    public void setY(int y) {
        this.y = y;
    }

    public int getX() {
        return x;
    }

    public void setX(int x) {
        this.x = x;
    }

    @Override
    public String toString() {
        return String.format("{Vertex: x = %d, y = %d}", this.x, this.y);
    }
}