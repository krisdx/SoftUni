package app.repository;

import app.model.Author;
import app.model.Book;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import javax.transaction.Transactional;

@Repository
@Transactional
public interface AuthorRepository extends CrudRepository<Author, Long> {
    Author findById(Long id);

    Iterable<Author> findAll();
}
