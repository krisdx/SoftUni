import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Nested_Rectangles {

    private static List<Rect> rectangles = new ArrayList<>();

    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

        String line = reader.readLine();
        while (!line.equals("End")) {
            String[] lineArgs = line.split(":");
            String rectName = lineArgs[0].trim();
            String[] coordinates = lineArgs[1].trim().split("\\s+");
            int minX = Integer.valueOf(coordinates[0]);
            int maxY = Integer.valueOf(coordinates[1]);
            int maxX = Integer.valueOf(coordinates[2]);
            int minY = Integer.valueOf(coordinates[3]);

            Rect rect = new Rect(rectName, minX, minY, maxX, maxY);
            rectangles.add(rect);

            line = reader.readLine();
        }

        Rect bestRect = solve();

        StringBuilder output = new StringBuilder();
        while (bestRect != null) {
            if (bestRect.bestNestedRect == null) {
                output.append(bestRect.name);
            } else {
                output.append(bestRect.name).append(" < ");
            }

            bestRect = bestRect.bestNestedRect;
        }

        System.out.println(output);
    }

    private static Rect solve() {
        Rect bestRect = rectangles.get(0);
        for (Rect rectangle : rectangles) {
            getNestedRectanglesCount(rectangle);
            if (rectangle.depth > bestRect.depth ||
                    (rectangle.depth == bestRect.depth && rectangle.name.compareTo(bestRect.name) < 0)) {
                bestRect = rectangle;
            }
        }

        return bestRect;
    }

    private static void getNestedRectanglesCount(Rect rect) {

        if (rect.depth > 0) {
            return;
        }

        rect.depth = 1;
        Rect bestNestedRect = null;
        for (Rect other : rectangles) {
            if (rect != other && other.isInside(rect)) {
                getNestedRectanglesCount(other);
                if (bestNestedRect == null || other.depth > bestNestedRect.depth ||
                        (other.depth == bestNestedRect.depth && other.name.compareTo(bestNestedRect.name) < 0)) {
                    bestNestedRect = other;
                }
            }
        }

        if (bestNestedRect != null) {
            rect.bestNestedRect = bestNestedRect;
            rect.depth += bestNestedRect.depth;
        }
    }
}

class Rect {
    public String name;
    public int minX;
    public int minY;
    public int maxX;
    public int maxY;
    public int depth;
    public Rect bestNestedRect;

    public Rect(String name, int minX, int minY, int maxX, int maxY) {
        this.name = name;
        this.minX = minX;
        this.minY = minY;
        this.maxX = maxX;
        this.maxY = maxY;
    }

    public boolean isInside(Rect other) {
        return this.minX >= other.minX && this.maxX <= other.maxX &&
                this.minY >= other.minY && this.maxY <= other.maxY;
    }
}