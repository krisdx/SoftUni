import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Problem1_Students {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        while (true) {
            String name = reader.readLine();
            if (name.equals("End")) {
                break;
            }

            Student student = new Student(name);
        }

        System.out.println(Student.numberOfInstances);
    }


}

class Student {
    public static int numberOfInstances;

    private String name;

    public Student(String name) {
        this.name = name;
        numberOfInstances++;
    }
}