import java.util.Scanner;

public class Problem2_TriangleArea {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        double aX = Double.parseDouble(input.next());
        double aY = Double.parseDouble(input.next());
        double bX = Double.parseDouble(input.next());
        double bY = Double.parseDouble(input.next());
        double cX = Double.parseDouble(input.next());
        double cY = Double.parseDouble(input.next());

        double area = Math.abs(aX * (bY - cY) +
                      bX * (cY - aY) +
                      cX * (aY - bY)) / 2;
        System.out.println((int)area);
    }
}