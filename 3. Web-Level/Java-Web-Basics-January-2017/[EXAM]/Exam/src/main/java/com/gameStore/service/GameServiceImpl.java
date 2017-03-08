package com.gameStore.service;

import com.gameStore.entity.Game;
import com.gameStore.entity.user.User;
import com.gameStore.model.binding.GameBindingModel;
import com.gameStore.model.view.GameViewModel;
import com.gameStore.repository.GameRepository;
import org.modelmapper.ModelMapper;

import javax.ejb.Stateless;
import javax.inject.Inject;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.HashSet;
import java.util.Set;

@Stateless
public class GameServiceImpl implements GameService {

    private final GameRepository gameRepository;
    private final ModelMapper modelMapper;

    @Inject
    public GameServiceImpl(GameRepository gameRepository) {
        this.gameRepository = gameRepository;
        this.modelMapper = new ModelMapper();
    }

    @Override
    public void save(GameBindingModel gameBindingModel) {
        Game game = new Game();
        game.setId(gameBindingModel.getId());
        game.setTitle(gameBindingModel.getTitle());
        game.setDescription(gameBindingModel.getDescription());
        game.setImageThumbnail(gameBindingModel.getImageThumbnail());
        game.setPrice(new Double(gameBindingModel.getPrice()));
        game.setSize(new Double(gameBindingModel.getSize()));
        game.setTrailer(gameBindingModel.getTrailer());
        DateFormat formatter = new SimpleDateFormat("yyyy-MM-dd");
        try {
            game.setReleaseDate(formatter.parse(gameBindingModel.getReleaseDate()));
        } catch (ParseException e) {
            e.printStackTrace();
        }

        this.gameRepository.save(game);
    }

    @Override
    public void update(GameBindingModel gameBindingModel) {
        Game game = new Game();
        game.setId(gameBindingModel.getId());
        game.setTitle(gameBindingModel.getTitle());
        game.setDescription(gameBindingModel.getDescription());
        game.setImageThumbnail(gameBindingModel.getImageThumbnail());
        game.setPrice(new Double(gameBindingModel.getPrice()));
        game.setSize(new Double(gameBindingModel.getSize()));
        game.setTrailer(gameBindingModel.getTrailer());
        DateFormat formatter = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss.S");
        try {
            game.setReleaseDate(formatter.parse(gameBindingModel.getReleaseDate()));
        } catch (ParseException e) {
            e.printStackTrace();
        }

        this.gameRepository.update(game);
    }

    @Override
    public Set<GameViewModel> findAll() {
        Set<Game> games = this.gameRepository.findAll();
        Set<GameViewModel> gameViewModels = new HashSet<>();
        for (Game game : games) {
            gameViewModels.add(this.modelMapper.map(game, GameViewModel.class));
        }

        return gameViewModels;
    }

    @Override
    public GameBindingModel findById(long id) {
        Game game = this.gameRepository.findById(id);
        return this.modelMapper.map(game, GameBindingModel.class);
    }

    @Override
    public Game findGame(long id) {
        return this.gameRepository.findById(id);
    }

    @Override
    public void deleteById(long id) {
        this.gameRepository.deleteById(id);
    }

    @Override
    public Set<GameViewModel> findGamesByUser(User currentUser) {
        return this.gameRepository.findGamesByuser(currentUser);
    }
}