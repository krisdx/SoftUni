package app.service;

import app.domain.dto.CategoryDto;
import app.domain.models.Category;

public interface CategoryService {
    void create(CategoryDto categoryDto);

    void create(Category category);

    Category find(Long id);

    long getCategoriesCount();
}