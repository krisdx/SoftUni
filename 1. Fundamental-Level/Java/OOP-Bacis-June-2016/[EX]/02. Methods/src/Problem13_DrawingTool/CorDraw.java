package Problem13_DrawingTool;

public class CorDraw {
    private Rectangle rectangle;
    private Square square;

    public CorDraw(Rectangle rectangle) {
        this.rectangle = rectangle;
    }

    public CorDraw(Square square) {
        this.square = square;
    }

    public void draw() {
        if (this.rectangle == null) {
            this.square.draw();
        } else {
            this.rectangle.draw();
        }
    }
}