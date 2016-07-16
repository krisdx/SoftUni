import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;

public class Problem11_RectangleIntersection {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        Map<String, Rectangle> rectangles = new HashMap<>();

        String[] inputLine = reader.readLine().split("\\s+");
        int rectanglesCount = Integer.valueOf(inputLine[0]);
        for (int i = 0; i < rectanglesCount; i++) {
            String[] lineArgs = reader.readLine().split("\\s+");
            String id = lineArgs[0];
            double width = Double.valueOf(lineArgs[1]);
            double height = Double.valueOf(lineArgs[2]);
            double y = Double.valueOf(lineArgs[3]);
            double x = Double.valueOf(lineArgs[4]);
            Rectangle rect = new Rectangle(id, width, height, y, x);
            rectangles.put(id, rect);
        }

        int intersectionsCount = Integer.valueOf(inputLine[1]);
        for (int i = 0; i < intersectionsCount; i++) {
            String[] lineArgs = reader.readLine().split("\\s+");
            Rectangle firstRect = rectangles.get(lineArgs[0]);
            Rectangle secondRect = rectangles.get(lineArgs[1]);

            System.out.println(firstRect.intersects(secondRect));
        }
    }
}

class Rectangle {
    private String id;
    private double width;
    private double height;
    private double x;
    private double y;

    public Rectangle(String id, double width, double height, double y, double x) {
        this.id = id;
        this.y = y;
        this.x = x;
        this.width = width;
        this.height = height;
    }

    public boolean intersects(Rectangle other) {
        boolean xIntersection = xIntersection(other);
        boolean yIntersection = yIntersection(other);

        return xIntersection && yIntersection;
    }

    private boolean yIntersection(Rectangle other) {
        boolean lowerLeftBound =
                (this.y + this.height <= other.getY() + other.getHeight() &&
                        this.y + this.height >= other.getY());
        boolean leftLowerBound =
                (this.y >= other.getY() &&
                        this.y <= other.getY() + other.getHeight());
        return lowerLeftBound || leftLowerBound;
    }

    private boolean xIntersection(Rectangle other) {
        boolean leftIntersection =
                this.x <= other.getX() + other.getWidth() &&
                        this.x >= other.getX();
        boolean rightIntersection =
                this.x + this.width >= other.getX() &&
                        this.x + this.width <= other.getX() + other.getWidth();
        return leftIntersection || rightIntersection;
    }

    public double getWidth() {
        return width;
    }

    public double getHeight() {
        return height;
    }

    public double getX() {
        return x;
    }

    public double getY() {
        return y;
    }
}