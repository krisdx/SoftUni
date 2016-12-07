package app.terminal;

import app.domain.dto.CategoryDto;
import app.domain.dto.ProductDto;
import app.domain.dto.UserDto;
import app.domain.models.Category;
import app.domain.models.Product;
import app.domain.models.User;
import app.perser.JsonParser;
import app.perser.ModelParser;
import app.service.CategoryService;
import app.service.ProductService;
import app.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.IOException;
import java.util.Random;

@Component
public class ImportJsonTerminal implements CommandLineRunner {

    @Autowired
    private UserService userService;

    @Autowired
    private ProductService productService;

    @Autowired
    private CategoryService categoryService;

    @Autowired
    private JsonParser jsonParser;

    @Autowired
    private ModelParser modelParser;

    private static Random random = new Random();

    @Override
    public void run(String... strings) throws Exception {
        //importUsers();
        //importProducts();
        //importCategories();
        //
        //setCategories();
        //
        //makeFriends();
    }

    private void makeFriends() {
        int usersCount = (int) this.userService.getUsersCount();
        for (int id = 1; id < usersCount; id++) {
            User user = this.userService.find((long) id);
            User friend = this.userService.find((long) id + 1);

            user.getFriends().add(friend);
            this.userService.create(user);
        }
    }

    private void setCategories() {
        int productsCount = (int) this.productService.getProductsCount();
        int categoriesCount = (int) this.categoryService.getCategoriesCount();
        for (int id = 1; id < productsCount; id++) {
            Product product = this.productService.find((long) id);
            Category category = this.categoryService.find((long) random.nextInt(categoriesCount) + 1);

            product.getCategories().add(category);
            this.productService.create(product);
        }
    }

    private void importUsers() throws IOException {
        UserDto[] usersDtos = this.jsonParser.importFromJson(UserDto[].class,
                "src/main/resources/files/input/json/users.json");
        for (UserDto userDto : usersDtos) {
            this.userService.create(userDto);
        }
    }

    private void importProducts() throws IOException {
        ProductDto[] productDtos = this.jsonParser.importFromJson(ProductDto[].class,
                "src/main/resources/files/input/json/products.json");
        for (ProductDto productDto : productDtos) {
            Product product = this.modelParser.convert(productDto, Product.class);

            int usersCount = (int) this.userService.getUsersCount();
            // multiply the range by 2 because we want some of the users to be null.
            product.setBuyer(this.userService.find((long) random.nextInt(usersCount * 2)));
            product.setSeller(this.userService.find((long) random.nextInt(usersCount * 2)));

            this.productService.create(product);
        }
    }

    private void importCategories() throws IOException {
        CategoryDto[] categoryDtos = this.jsonParser.importFromJson(CategoryDto[].class,
                "src/main/resources/files/input/json/categories.json");
        for (CategoryDto categoryDto : categoryDtos) {
            this.categoryService.create(categoryDto);
        }
    }
}