package com.gameStore.repository;

import com.gameStore.entity.Game;
import com.gameStore.entity.user.User;
import com.gameStore.model.view.GameViewModel;

import java.util.Set;

public interface GameRepository {
    void save(Game game);

    void update(Game game);

    Set<Game> findAll();

    Game findById(long id);

    void deleteById(long id);

    Set<GameViewModel> findGamesByuser(User currentUser);
}