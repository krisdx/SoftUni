package app.service;

import app.domain.dto.UserDto;
import app.domain.models.User;

public interface UserService {
    void create(UserDto userDto);

    void create(User user);

    User find(Long id);

    long getUsersCount();
}