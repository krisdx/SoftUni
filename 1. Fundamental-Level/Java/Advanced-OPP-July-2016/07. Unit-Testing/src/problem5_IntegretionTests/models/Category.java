package problem5_IntegretionTests.models;

import java.util.HashSet;
import java.util.Set;

public class Category extends AbstractModel {

    private Set<User> users;
    private Set<Category> childCategories;

    public Category(String name) {
        super(name);
        this.users = new HashSet<>();
        this.childCategories = new HashSet<>();
    }

    public Set<User> getUsers() {
        return this.users;
    }
}