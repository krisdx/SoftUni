package bookhut.repository;

import bookhut.entity.Book;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

public class BookRepositoryImpl implements BookRepository {

    private List<Book> books;
    private static BookRepository bookRepository;

    private BookRepositoryImpl() {
        this.books = new ArrayList<>();
    }

    public static BookRepository getInstance() {
        if (bookRepository == null) {
            bookRepository = new BookRepositoryImpl();
        }

        return bookRepository;
    }

    @Override
    public void saveBook(Book book) {
        Book currentBook = this.books
            .stream()
            .filter(b -> b.getTitle().equals(book.getTitle()))
            .findFirst()
            .orElse(null);
        if (currentBook != null) {
            this.getAllBooks().remove(currentBook);
        }

        this.getAllBooks().add(book);
    }

    @Override
    public List<Book> getAllBooks() {
        return this.books;
    }

    @Override
    public void deleteBookByTitle(String title) {
        Book bookToRemove = this.findBookByTitle(title);
        if (bookToRemove != null) {
            this.getAllBooks().remove(bookToRemove);
        }
    }

    @Override
    public Book findBookByTitle(String title) {
        Optional<Book> book = this.getAllBooks()
                .stream()
                .filter(b -> b.getTitle().equals(title))
                .findFirst();
        return book.isPresent() ? book.get() : null;
    }
}