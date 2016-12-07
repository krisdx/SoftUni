package app.domain.models;

import javax.persistence.*;
import java.math.BigDecimal;

@Entity
@Table(name = "categories")
public class Category {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Basic
    private String name;

    public Category() {
    }

    public Category(String name) {
        this.setName(name);
    }

    public Long getId() {
        return this.id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        if (name == null || name.length() < 3 || name.length() > 15) {
            throw new IllegalArgumentException(
                    "The last name must be in range [3...15].");
        }

        this.name = name;
    }
}