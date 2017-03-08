package bookhut.repository;

import bookhut.entity.User;

import java.util.List;

public class UserRepositoryImpl implements UserRepository {

    private List<User> users;
    private static UserRepository userRepository;

    public static UserRepository getInstance() {
        if (userRepository == null) {
            userRepository = new UserRepositoryImpl();
        }

        return userRepository;
    }

    @Override
    public void createUser(User user) {
        this.users.add(user);
    }

    @Override
    public User findByUsernameAndPassword(String username, String password) {
        return users
                .stream()
                .filter(u ->
                        u.getUsername().equals(username)
                                && u.getPassword().equals(password))
                .findFirst()
                .orElse(null);
    }
}