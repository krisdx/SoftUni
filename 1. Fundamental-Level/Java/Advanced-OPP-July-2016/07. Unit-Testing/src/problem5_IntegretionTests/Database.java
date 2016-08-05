package problem5_IntegretionTests;

import problem5_IntegretionTests.models.Category;
import problem5_IntegretionTests.models.User;

import java.util.Set;

public class Database {

    private Set<User> users;
    private Set<Category> categories;

    public void addCategory(Category category){
        this.categories.add(category);
    }

    public void removeCategory(Category category){
        this.categories.remove(category);
    }
}