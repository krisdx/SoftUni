package Problem13_DrawingTool;

public class Rectangle {
    private int width;
    private int height;

    public Rectangle(int height, int width) {
        this.height = height;
        this.width = width;
    }

    public void draw() {
        StringBuilder output = new StringBuilder();

        output.append("|").append(multiply("-", this.width)).append("|").append("\n");

        for (int i = 0; i < this.height - 2; i++) {
            output.append("|").append(multiply(" ", this.width)).append("|").append("\n");
        }

        if (this.height >= 2) {
            output.append("|").append(multiply("-", this.width)).append("|").append("\n");
        }

        System.out.println(output);
    }

    private String multiply(String str, int count) {
        String result = "";

        for (int i = 0; i < count; i++) {
            result += str;
        }

        return result;
    }
}
