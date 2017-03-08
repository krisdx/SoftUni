package com.gameStore.service;

import com.gameStore.entity.user.Role;
import com.gameStore.entity.user.User;
import com.gameStore.model.binding.LoginBindingModel;
import com.gameStore.model.binding.UserBindingModel;
import com.gameStore.repository.UserRepository;
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
    public void registerUser(UserBindingModel userModel) {
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
    public User find(String email) {
        return this.userRepository.findByEmail(email);
    }

    @Override
    public User find(LoginBindingModel loginBindingModel) {
        return this.userRepository.findByEmailAndPassword(loginBindingModel.getEmail(), loginBindingModel.getPassword());
    }
}