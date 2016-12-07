package app.service;

import app.domain.dto.UserDto;
import app.domain.models.User;
import app.perser.ModelParser;
import app.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class UserServiceImpl implements UserService {

    @Autowired
    private UserRepository userRepository;

    @Autowired
    private ModelParser modelParser;

    @Override
    public void create(UserDto userDto) {
        User user = this.modelParser.convert(userDto, User.class);
        this.userRepository.saveAndFlush(user);
    }

    @Override
    public void create(User user) {
        this.userRepository.saveAndFlush(user);
    }

    @Override
    public User find(Long id) {
        return this.userRepository.findOne(id);
    }

    @Override
    public long getUsersCount() {
        return this.userRepository.count();
    }
}