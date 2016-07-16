package Problem13_DrawingTool;

public class Square {
    private int size;

    public Square(int size) {
        this.size = size;
    }

    public void draw() {
        StringBuilder output = new StringBuilder();

        output.append("|").append(multiply("-", this.size)).append("|").append("\n");

        for (int i = 0; i < this.size - 2; i++) {

            output.append("|").append(multiply(" ", this.size)).append("|").append("\n");
        }

        if (this.size >= 2){
            output.append("|").append(multiply("-", this.size)).append("|").append("\n");
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