package problem2_BookShop;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.reflect.Method;

public class Main {

    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String author = reader.readLine();
        String title = reader.readLine();
        double price = Double.valueOf(reader.readLine());

        try {
            Book book = new Book(author, title, price);
            GoldenEditionBook goldenBook = new GoldenEditionBook(author, title, price);

            Method[] bookDeclaredMethods = Book.class.getDeclaredMethods();
            Method[] goldenBookDeclaredMethods = GoldenEditionBook.class.getDeclaredMethods();
            if (goldenBookDeclaredMethods.length > 1){
                throw new IllegalArgumentException("Code duplication in GoldenEditionBook");
            }

            System.out.println(book);
            System.out.println(goldenBook);
        } catch (IllegalArgumentException ex){
            System.out.println(ex.getMessage());
        }
    }
}