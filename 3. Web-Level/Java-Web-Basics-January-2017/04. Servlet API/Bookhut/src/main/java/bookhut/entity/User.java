package bookhut.entity;

public class User {

    private Long id;
    private String username;
    private String password;

    public User(String username, String password) {
        this.setUsername(username);
        this.setPassword(password);
    }

    public Long getId() {
        return this.id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getUsername() {
        return this.username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return this.password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}