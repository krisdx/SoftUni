package problem5_IntegretionTests.models;

import java.util.HashSet;
import java.util.Set;

public class User extends AbstractModel{

    private Set<Category> categories;

    public User(String name) {
        super(name);
        this.categories = new HashSet<>();
    }

    public Set<Category> getCategories() {
        return this.categories;
    }
}