package app.service;

import app.model.Book;
import app.repository.BookRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Service;

import java.util.Date;

@Service
@Primary
public class BookServiceImpl implements BookService {

    @Autowired
    private BookRepository bookRepository;

    @Override
    public void save(Book book) {
        this.bookRepository.save(book);
    }

    @Override
    public void delete(Book book) {
        this.bookRepository.delete(book);
    }

    @Override
    public void delete(Long id) {
        this.bookRepository.delete(id);
    }

    @Override
    public Book findBook(Long id) {
        return this.bookRepository.findOne(id);
    }

    @Override
    public Iterable<Book> findBooks() {
        return this.bookRepository.findAll();
    }

    @Override
    public Iterable<Book> findByReleaseDateYearAfter(int year) {
        return this.bookRepository.findByReleaseDateYearAfter(year);
    }
}
