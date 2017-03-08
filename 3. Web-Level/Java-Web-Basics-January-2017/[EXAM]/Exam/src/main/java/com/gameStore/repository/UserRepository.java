package com.gameStore.repository;

import com.gameStore.entity.user.User;

public interface UserRepository {
    void save(User user);

    User findByEmail(String email);

    User findByEmailAndPassword(String email, String password);

    long getUsersCount();
}