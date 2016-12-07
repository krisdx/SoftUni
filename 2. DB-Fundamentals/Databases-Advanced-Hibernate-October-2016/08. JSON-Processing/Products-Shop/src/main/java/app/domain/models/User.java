package app.domain.models;

import javax.jws.soap.SOAPBinding;
import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name = "users")
public class User {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Basic
    private String firstName;

    @Basic
    private String lastName;

    @Basic
    private Integer age;

    @OneToMany(mappedBy = "buyer")
    private Set<Product> buyedProducts;

    @OneToMany(mappedBy = "seller")
    private Set<Product> selledProducts;

    @ManyToMany(fetch = FetchType.EAGER)
    @JoinTable(name = "users_friends",
            joinColumns = @JoinColumn(name = "user_id", referencedColumnName = "id"),
            inverseJoinColumns = @JoinColumn(name = "friend_id", referencedColumnName = "id"))
    private Set<User> friends;

    public User() {
        this.setBuyedProducts(new HashSet<>());
        this.setSelledProducts(new HashSet<>());
        this.setFriends(new HashSet<>());
    }

    public User(String firstName, String lastName, Integer age) {
        this();
        this.setFirstName(firstName);
        this.setLastName(lastName);
        this.setAge(age);
    }

    public Long getId() {
        return this.id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getFirstName() {
        return this.firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return this.lastName;
    }

    public void setLastName(String lastName) {
        if (lastName == null || lastName.length() < 3) {
            throw new IllegalArgumentException(
                    "The last name must be at least 3 symbols long.");
        }

        this.lastName = lastName;
    }

    public Integer getAge() {
        return this.age;
    }

    public void setAge(Integer age) {
        this.age = age;
    }

    public Set<Product> getBuyedProducts() {
        return this.buyedProducts;
    }

    public void setBuyedProducts(Set<Product> buyedProducts) {
        this.buyedProducts = buyedProducts;
    }

    public Set<Product> getSelledProducts() {
        return this.selledProducts;
    }

    public void setSelledProducts(Set<Product> selledProducts) {
        this.selledProducts = selledProducts;
    }

    public Set<User> getFriends() {
        return this.friends;
    }

    public void setFriends(Set<User> friends) {
        this.friends = friends;
    }

    public String getFullName() {
        return this.getFirstName() + " " + this.getLastName();
    }
}