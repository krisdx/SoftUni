package app.entities;

import app.persistence.Column;
import app.persistence.Entity;
import app.persistence.Id;

import java.util.Date;

@Entity(name = "users")
public class User {

    @Id
    private long id;

    @Column(name = "password")
    private String password;

    @Column(name = "age")
    private int age;

    @Column(name = "registration_date")
    private Date registrationDate;

    public User() {
    }

    public User(String password, int age, Date registrationDate) {
        this.setPassword(password);
        this.setAge(age);
        this.setRegistrationDate(registrationDate);
    }

    public long getId() {
        return this.id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getPassword() {
        return this.password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public int getAge() {
        return this.age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public Date getRegistrationDate() {
        return this.registrationDate;
    }

    public void setRegistrationDate(Date registrationDate) {
        this.registrationDate = registrationDate;
    }
}