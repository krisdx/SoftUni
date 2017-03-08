package app.repository;

import app.model.User;
import app.model.cookie.Session;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;

public class SessionRepository {

    public Long createSession(Session session) {
        EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("pizzamore");
        EntityManager entityManager = entityManagerFactory.createEntityManager();

        entityManager.getTransaction().begin();
        entityManager.persist(session);
        Long id = session.getId();
        entityManager.getTransaction().commit();

        entityManager.close();
        entityManagerFactory.close();
        return id;
    }

    public Session findById(Long id) {
        EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("pizzamore");
        EntityManager entityManager = entityManagerFactory.createEntityManager();

        entityManager.getTransaction().begin();

        Query query = entityManager.createQuery("SELECT s FROM Session AS s" +
                " WHERE s.id= :id");
        query.setParameter("id", id);
        Session session = null;
        if (! query.getResultList().isEmpty()) {
            session = (Session) query.getSingleResult();
        }

        entityManager.getTransaction().commit();
        entityManager.close();
        entityManagerFactory.close();

        return session;
    }

    public void delete(Long id) {
        EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("pizzamore");
        EntityManager entityManager = entityManagerFactory.createEntityManager();

        entityManager.getTransaction().begin();
        Query query = entityManager.createQuery("DELETE FROM Session AS s" +
                " WHERE s.id= :id");
        query.setParameter("id", id);
        query.executeUpdate();

        entityManager.getTransaction().commit();
        entityManager.close();
        entityManagerFactory.close();
    }
}