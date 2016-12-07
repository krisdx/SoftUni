package app.service;

import app.model.Author;
import app.model.Book;

public interface BookService {
    void save(Book book);

    void delete(Book book);

    void delete(Long id);

    Book findBook(Long id);

    Iterable<Book> findBooks();

    Iterable<Book> findByReleaseDateYearAfter(int year);
}