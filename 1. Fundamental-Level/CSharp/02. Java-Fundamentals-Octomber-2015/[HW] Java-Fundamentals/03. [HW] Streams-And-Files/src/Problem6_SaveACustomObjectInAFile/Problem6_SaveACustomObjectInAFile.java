package Problem6_SaveACustomObjectInAFile;

import java.io.*;

public class Problem6_SaveACustomObjectInAFile {
    public static void main(String[] args) {
        Course course = new Course("Java Fundamentals", 350);

        saveCourse(course);
        Course course1 = loadCourse();
        System.out.println(course1);
    }

    private static Course loadCourse() {
        Course course = new Course();
        try (ObjectInputStream objectInputStream = new ObjectInputStream(new FileInputStream("resources/course.save"))) {
            course = (Course) objectInputStream.readObject();
            return course;
        } catch (FileNotFoundException fileNotFoundException) {
            System.out.println("File not found.");
        } catch (IOException exception) {
            System.out.println("Cannot read the file.");
        } catch (ClassNotFoundException classNotFoundException) {
            classNotFoundException.printStackTrace();
        }

        return course;
    }

    private static void saveCourse(Course course) {
        try (ObjectOutputStream objectInputStream = new ObjectOutputStream(new FileOutputStream("resources/course.save"))) {
            objectInputStream.writeObject(course);
        } catch (FileNotFoundException fileNotFoundException) {
            System.out.println("File not found.");
        } catch (IOException exception) {
            System.out.println("Cannot read the file.");
        }
    }
}