package com.issueTracker.service;

import com.issueTracker.entity.user.User;
import com.issueTracker.model.binding.LoginModel;
import com.issueTracker.model.binding.UserModel;

public interface UserService {
    void registerUser(UserModel userModel);

    User find(String username);

    User find(LoginModel loginModel);
}