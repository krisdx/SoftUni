package app.service;

import app.model.Author;
import app.model.Book;

public interface AuthorService {
    void save(Author author);

    void delete(Author author);

    void delete(Long id);

    Author findAuthor(Long id);

    Iterable<Author> findAuthors();
}