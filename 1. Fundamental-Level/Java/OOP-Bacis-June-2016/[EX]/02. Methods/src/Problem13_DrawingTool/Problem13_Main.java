package Problem13_DrawingTool;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Problem13_Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        String figure = reader.readLine();
        CorDraw corDraw = null;
        if (figure.equals("Square")){
            int size = Integer.valueOf(reader.readLine());
            Square square = new Square(size);
            corDraw = new CorDraw(square);
            corDraw.draw();
        }else {
            int width = Integer.valueOf(reader.readLine());
            int height = Integer.valueOf(reader.readLine());
            Rectangle rectangle = new Rectangle(height, width);
            corDraw = new CorDraw(rectangle);
            corDraw.draw();
        }
    }
}
