package app.repository;

import app.model.Author;
import app.model.Category;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import javax.transaction.Transactional;

@Repository
@Transactional
public interface CategoryRepository extends CrudRepository<Category, Long> {
    Category findById(Long id);

    Iterable<Category> findAll();
}
