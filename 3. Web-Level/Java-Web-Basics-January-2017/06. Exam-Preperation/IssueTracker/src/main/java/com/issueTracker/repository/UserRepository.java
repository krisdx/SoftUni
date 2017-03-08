package com.issueTracker.repository;

import com.issueTracker.entity.user.User;

public interface UserRepository {
    void save(User user);

    User findByUsername(String username);

    User findByUsernameAndPassword(String username, String password);

    long getUsersCount();
}