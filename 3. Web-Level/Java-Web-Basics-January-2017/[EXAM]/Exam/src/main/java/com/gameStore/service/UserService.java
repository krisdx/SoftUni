package com.gameStore.service;

import com.gameStore.entity.user.User;
import com.gameStore.model.binding.LoginBindingModel;
import com.gameStore.model.binding.UserBindingModel;

public interface UserService {
    void registerUser(UserBindingModel userModel);

    User find(String email);

    User find(LoginBindingModel loginBindingModel);
}