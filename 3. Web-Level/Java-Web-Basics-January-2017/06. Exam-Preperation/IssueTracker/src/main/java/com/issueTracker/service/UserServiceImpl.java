package com.issueTracker.service;

import com.issueTracker.entity.user.Role;
import com.issueTracker.entity.user.User;
import com.issueTracker.model.binding.LoginModel;
import com.issueTracker.model.binding.UserModel;
import com.issueTracker.repository.UserRepository;
import org.modelmapper.ModelMapper;

import javax.ejb.Stateless;
import javax.inject.Inject;

@Stateless
public class UserServiceImpl implements UserService {

    private final UserRepository userRepository;
    private final ModelMapper modelMapper;

    @Inject
    public UserServiceImpl(UserRepository userRepository) {
        this.userRepository = userRepository;
        this.modelMapper = new ModelMapper();
    }

    @Override
    public void registerUser(UserModel userModel) {
        User user = this.modelMapper.map(userModel, User.class);
        long usersCount = this.userRepository.getUsersCount();
        if (usersCount == 0) {
            user.setRole(Role.ADMIN);
        } else {
            user.setRole(Role.USER);
        }

        this.userRepository.save(user);
    }

    @Override
    public User find(String username) {
        return this.userRepository.findByUsername(username);
    }

    @Override
    public User find(LoginModel loginModel) {
        return this.userRepository.findByUsernameAndPassword(loginModel.getUsername(), loginModel.getPassword());
    }
}