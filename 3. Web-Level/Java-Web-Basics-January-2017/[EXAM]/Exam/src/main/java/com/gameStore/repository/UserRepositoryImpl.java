package com.gameStore.repository;

import com.gameStore.entity.user.User;

import javax.ejb.Local;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

@Stateless
@Local(UserRepository.class)
public class UserRepositoryImpl implements UserRepository {

    @PersistenceContext
    private EntityManager entityManager;

    @Override
    public void save(User user) {
        this.entityManager.persist(user);
    }

    @Override
    public User findByEmail(String email) {
        Query query = this.entityManager.createQuery("SELECT u FROM User AS u" +
                " WHERE u.email = :email");
        query.setParameter("email", email);
        List<User> result = query.getResultList();
        return result.isEmpty() ? null : result.get(0);
    }

    @Override
    public User findByEmailAndPassword(String email, String password) {
        Query query = this.entityManager.createQuery("SELECT u FROM User AS u" +
                " WHERE u.email = :email AND u.password = :password");
        query.setParameter("email", email);
        query.setParameter("password", password);
        List<User> result = query.getResultList();
        return result.isEmpty() ? null : result.get(0);
    }

    @Override
    public long getUsersCount() {
        Query query = this.entityManager.createQuery("SELECT COUNT(u) FROM User as u");
        return (long) query.getResultList().get(0);
    }
}