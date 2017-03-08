package com.gameStore.service;

import com.gameStore.entity.Game;
import com.gameStore.entity.user.User;
import com.gameStore.model.binding.GameBindingModel;
import com.gameStore.model.view.GameViewModel;

import java.util.Set;

public interface GameService {

    void save(GameBindingModel gameBindingModel);

    void update(GameBindingModel gameBindingModel);

    Set<GameViewModel> findAll();

    GameBindingModel findById(long id);

    Game findGame(long id);

    void deleteById(long id);

    Set<GameViewModel> findGamesByUser(User currentUser);
}