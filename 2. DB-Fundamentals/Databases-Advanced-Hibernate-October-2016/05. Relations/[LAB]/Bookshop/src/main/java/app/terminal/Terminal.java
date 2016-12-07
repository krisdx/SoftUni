package app.terminal;

import app.model.Author;
import app.model.Book;
import app.model.Category;
import app.model.enums.AgeRestriction;
import app.model.enums.EditionType;
import app.service.AuthorService;
import app.service.BookService;
import app.service.CategoryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.*;
import java.math.BigDecimal;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;

@Component
public class Terminal implements CommandLineRunner {

    @Autowired
    private AuthorService authorService;

    @Autowired
    private BookService bookService;

    @Autowired
    private CategoryService categoryService;

    private static int authorsCount;
    private static int categoriesCount;

    @Override
    public void run(String... strings) throws Exception {
        //seedAuthors("data/authors.txt");
        //seedCategories("data/categories.txt");
        //seedBooks("data/books.txt");

        //List<Book> books = (List<Book>) bookService.findBooks();
        //List<Book> threeBooks = books.subList(0, 3);
        //
        //threeBooks.get(0).getRelatedBooks().add(threeBooks.get(1));
        //threeBooks.get(1).getRelatedBooks().add(threeBooks.get(0));
        //threeBooks.get(0).getRelatedBooks().add(threeBooks.get(2));
        //threeBooks.get(2).getRelatedBooks().add(threeBooks.get(0));
        //
        //for (Book book : threeBooks) {
        //    this.bookService.save(book);
        //}
        //
        //for (Book book : threeBooks) {
        //    System.out.printf("--%s%n", book.getTitle());
        //    for (Book relatedBook : book.getRelatedBooks()) {
        //        System.out.println(relatedBook.getTitle());
        //    }
        //}

        List<Book> books = (List<Book>) this.bookService.findByReleaseDateYearAfter(2000);
        System.out.println(books.size());
        for (Book book : books) {
            System.out.println(book.getTitle());
        }
    }

    private void seedCategories(String filePath) throws IOException {
        BufferedReader reader = new BufferedReader(new FileReader(filePath));

        String categoryName = null;
        while ((categoryName = reader.readLine()) != null) {
            Category category = new Category(categoryName);
            this.categoryService.save(category);
            categoriesCount++;
        }
    }

    private void seedAuthors(String filePath) throws IOException {
        BufferedReader reader = new BufferedReader(new FileReader(filePath));

        String line = reader.readLine();
        while ((line = reader.readLine()) != null) {
            String[] args = line.split("\\s+");
            String firstName = args[0];
            String lastName = args[1];

            Author author = new Author(firstName, lastName);
            authorsCount++;
            this.authorService.save(author);
        }
    }

    private void seedBooks(String filePath) throws IOException, ParseException {
        BufferedReader reader = new BufferedReader(new FileReader(filePath));

        Random random = new Random();

        String line = reader.readLine();
        while ((line = reader.readLine()) != null) {
            String[] args = line.split("\\s+");

            long authorId = (long) (random.nextInt(authorsCount) + 1);
            Author author = this.authorService.findAuthor(authorId);
            EditionType editionType = EditionType.values()[Integer.valueOf(args[0])];
            Date releaseDate = new SimpleDateFormat("d/M/yyyy").parse(args[1]);
            long copiesCount = Integer.valueOf(args[2]);
            BigDecimal price = new BigDecimal(args[3]);
            AgeRestriction ageRestriction = AgeRestriction.values()[Integer.parseInt(args[4])];

            StringBuilder titleBuilder = new StringBuilder();
            for (int i = 5; i < args.length; i++) {
                titleBuilder.append(args[i]).append(" ");
            }
            String title = titleBuilder.toString().trim();

            Set<Long> categoryIds = new HashSet<>();
            Set<Category> categories = new HashSet<>();
            for (int i = 1; i <= 2; i++) {
                Long id = i + (long) random.nextInt(categoriesCount) / 2;
                while (categoryIds.contains(id)) {
                    id = i + (long) random.nextInt(categoriesCount) / 2;
                }

                categoryIds.add(id);
                Category category = this.categoryService.findCategory(id);
                categories.add(category);
            }

            Book book = new Book(title, editionType,
                    ageRestriction, price,
                    copiesCount, releaseDate, author, categories);
            this.bookService.save(book);
        }
    }
}