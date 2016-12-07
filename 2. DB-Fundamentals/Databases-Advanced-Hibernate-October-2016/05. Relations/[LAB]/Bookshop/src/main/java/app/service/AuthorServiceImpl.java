package app.service;

import app.model.Author;
import app.repository.AuthorRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Service;

@Service
@Primary
public class AuthorServiceImpl implements AuthorService {

    @Autowired
    private AuthorRepository authorRepository;

    @Override
    public void save(Author author) {
        this.authorRepository.save(author);
    }

    @Override
    public void delete(Author author) {
        this.authorRepository.delete(author);
    }

    @Override
    public void delete(Long id) {
        this.authorRepository.delete(id);
    }

    @Override
    public Author findAuthor(Long id) {
        return this.authorRepository.findOne(id);
    }

    @Override
    public Iterable<Author> findAuthors() {
        return this.authorRepository.findAll();
    }
}
