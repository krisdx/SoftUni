package app.service;

import app.model.Author;
import app.model.Book;
import app.model.Category;

public interface CategoryService {
    void save(Category category);

    void delete(Category category);

    void delete(Long id);

    Category findCategory(Long id);

    Iterable<Category> findCategories();
}