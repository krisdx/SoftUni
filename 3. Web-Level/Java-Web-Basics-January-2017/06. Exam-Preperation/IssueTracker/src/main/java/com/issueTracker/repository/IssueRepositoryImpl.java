package com.issueTracker.repository;

import com.issueTracker.entity.issue.Issue;
import com.issueTracker.entity.issue.Status;

import javax.ejb.Local;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

@Stateless
@Local(IssueRepository.class)
public class IssueRepositoryImpl implements IssueRepository {

    @PersistenceContext
    private EntityManager entityManager;

    @Override
    public void save(Issue issue) {
        this.entityManager.persist(issue);
    }

    @Override
    public void update(Issue issue) {
        this.entityManager.merge(issue);
    }

    @Override
    public Set<Issue> findAll() {
        Query query = this.entityManager.createQuery("SELECT i FROM Issue AS i");
        return new HashSet<>(query.getResultList());
    }

    @Override
    public Set<Issue> findAllByStatusAndName(String status, String name) {
        Query query = this.entityManager.createQuery("SELECT i FROM Issue AS i " +
                "WHERE i.status = :status " +
                "AND i.name LIKE :name");
        query.setParameter("name", "%" + name + "%");
        query.setParameter("status", Status.valueOf(status.toUpperCase()));
        return new HashSet<>(query.getResultList());
    }

    @Override
    public Set<Issue> findAllByStatus(String status) {
        Query query = this.entityManager.createQuery("SELECT i FROM Issue AS i " +
                "WHERE i.status = :status");
        query.setParameter("status", Status.valueOf(status.toUpperCase()));
        return new HashSet<>(query.getResultList());
    }

    @Override
    public Issue findById(long id) {
        Query query = this.entityManager.createQuery("SELECT i FROM Issue AS i WHERE i.id = :id");
        query.setParameter("id", id);
        List<Issue> result = query.getResultList();
        return result.isEmpty() ? null : result.get(0);
    }

    @Override
    public void deleteById(long id) {
        Query query = this.entityManager.createQuery("DELETE FROM Issue AS i WHERE i.id = :id");
        query.setParameter("id", id);
        query.executeUpdate();
    }
}