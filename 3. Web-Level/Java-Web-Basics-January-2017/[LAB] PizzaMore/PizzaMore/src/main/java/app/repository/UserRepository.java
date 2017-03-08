package app.repository;

import app.model.User;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;

public class UserRepository {

    public void createUser(User user) {
        EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("pizzamore");
        EntityManager entityManager = entityManagerFactory.createEntityManager();

        entityManager.getTransaction().begin();
        entityManager.persist(user);
        entityManager.getTransaction().commit();

        entityManager.close();
        entityManagerFactory.close();
    }

    public User findByUsernameAndPassword(String username, String password) {
        EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("pizzamore");
        EntityManager entityManager = entityManagerFactory.createEntityManager();

        entityManager.getTransaction().begin();

        Query query = entityManager.createQuery("SELECT u FROM User AS u" +
                " WHERE u.username = :username" +
                " AND u.password = :password");
        query.setParameter("username", username);
        query.setParameter("password", password);
        User user = null;
        if (! query.getResultList().isEmpty()) {
            user = (User) query.getSingleResult();
        }

        entityManager.getTransaction().commit();
        entityManager.close();
        entityManagerFactory.close();

        return user;
    }
}