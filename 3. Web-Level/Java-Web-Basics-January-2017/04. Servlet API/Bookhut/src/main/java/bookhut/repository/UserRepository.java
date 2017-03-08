package bookhut.repository;

import bookhut.entity.User;

public interface UserRepository {
    void createUser(User user);

    User findByUsernameAndPassword(String username, String password);
}