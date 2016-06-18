import IO.InputReader;

public class Launcher {
    public static void main(String[] args) {
        try {
            InputReader.readCommands();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}