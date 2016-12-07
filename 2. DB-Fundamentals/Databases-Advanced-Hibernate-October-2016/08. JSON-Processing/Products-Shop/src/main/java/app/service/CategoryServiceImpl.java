package app.service;

import app.domain.dto.CategoryDto;
import app.domain.models.Category;
import app.perser.ModelParser;
import app.repository.CategoryRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CategoryServiceImpl implements CategoryService {

    @Autowired
    private CategoryRepository categoryRepository;

    @Autowired
    private ModelParser modelParser;


    @Override
    public void create(CategoryDto categoryDto) {
        Category category = this.modelParser.convert(categoryDto, Category.class);
        this.categoryRepository.saveAndFlush(category);
    }

    @Override
    public void create(Category category) {
        this.categoryRepository.save(category);
    }

    @Override
    public Category find(Long id) {
        return this.categoryRepository.findOne(id);
    }

    @Override
    public long getCategoriesCount() {
        return this.categoryRepository.count();
    }
}
