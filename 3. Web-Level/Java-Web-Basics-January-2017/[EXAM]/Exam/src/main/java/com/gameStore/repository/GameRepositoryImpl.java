package com.gameStore.repository;

import com.gameStore.entity.Game;
import com.gameStore.entity.user.User;
import com.gameStore.model.view.GameViewModel;

import javax.ejb.Local;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

@Stateless
@Local(GameRepository.class)
public class GameRepositoryImpl implements GameRepository {

    @PersistenceContext
    private EntityManager entityManager;

    @Override
    public void save(Game game) {
        this.entityManager.persist(game);
    }

    @Override
    public void update(Game game) {
        this.entityManager.merge(game);
    }

    @Override
    public Set<Game> findAll() {
        Query query = this.entityManager.createQuery("SELECT g FROM Game AS g");
        return new HashSet<>(query.getResultList());
    }

    @Override
    public Game findById(long id) {
        Query query = this.entityManager.createQuery("SELECT g FROM Game AS g" +
                " WHERE g.id = :id");
        query.setParameter("id", id);
        List<Game> result = query.getResultList();
        return result.isEmpty() ? null : result.get(0);
    }

    @Override
    public void deleteById(long id) {
        Query query = this.entityManager.createQuery("DELETE FROM Game AS g " +
                "WHERE g.id = :id");
        query.setParameter("id", id);
        query.executeUpdate();
    }

    public Set<GameViewModel> findGamesByuser(User currentUser) {
        Query query = this.entityManager.createNativeQuery(
                "SELECT g.id FROM games AS g" +
                        " JOIN users_games AS ug ON ug.games_id = g.id" +
                        " WHERE ug.User_id = :id");
        query.setParameter("id", currentUser.getId());
        return new HashSet<>(query.getResultList());
    }
}