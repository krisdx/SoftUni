package com.gameStore.controller;

import com.gameStore.entity.Game;
import com.gameStore.entity.user.User;
import com.gameStore.model.binding.GameBindingModel;
import com.gameStore.model.view.GameViewModel;
import com.gameStore.service.GameService;
import com.mvcFramework.annotations.controller.Controller;
import com.mvcFramework.annotations.parameters.ModelAttribute;
import com.mvcFramework.annotations.parameters.PathVariable;
import com.mvcFramework.annotations.request.GetMapping;
import com.mvcFramework.annotations.request.PostMapping;
import com.mvcFramework.models.Model;

import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.servlet.http.HttpSession;
import java.util.Set;

@Stateless
@Controller
public class GameController {

    private final GameService gameService;

    @Inject
    public GameController(GameService gameService) {
        this.gameService = gameService;
    }

    @GetMapping("/chart")
    public String showChart(Model model, HttpSession session) {
        User currentUser = (User) session.getAttribute("currentUser");
        model.addAttribute("orders", currentUser.getOrder().getOrders());
        return "templates/cart";
    }

    @GetMapping("/games")
    public String showAdminGames(HttpSession session, Model model) {
        Set<GameViewModel> gameViewModels = this.gameService.findAll();
        model.addAttribute("gameViewModels", gameViewModels);
        return "templates/admin-games";
    }

    @GetMapping("/games/add")
    public String showAddGamePage() {
        return "templates/add-game";
    }

    @PostMapping("/games/add")
    public String addGame(@ModelAttribute GameBindingModel gameBindingModel) {
        this.gameService.save(gameBindingModel);
        return "redirect:/games";
    }

    @GetMapping("/games/info/{gameId}")
    public String showGame(Model model, @PathVariable("gameId") long gameId) {
        GameBindingModel gameBindingModel = this.gameService.findById(gameId);
        model.addAttribute("gameBindingModel", gameBindingModel);
        return "templates/game-details";
    }

    @GetMapping("/games/edit/{gameId}")
    public String showEditPage(@PathVariable("gameId") long gameId, Model model) {
        GameBindingModel gameBindingModel = this.gameService.findById(gameId);
        model.addAttribute("gameBindingModel", gameBindingModel);
        return "templates/edit-game";
    }

    @PostMapping("/games/edit/{gameId}")
    public String editGame(@PathVariable("gameId") long gameId, @ModelAttribute GameBindingModel gameBindingModel) {
        gameBindingModel.setId(gameId);
        this.gameService.update(gameBindingModel);
        return "redirect:/games";
    }

    @GetMapping("/games/buy/{gameId}")
    public String buyGame(@PathVariable("gameId") long gameId, HttpSession session) {
        User currentUser = (User) session.getAttribute("currentUser");
        Game game = this.gameService.findGame(gameId);
        currentUser.getOrder().getOrders().add(game);

        return "redirect:/chart";
    }

    @GetMapping("/games/delete/{gameId}")
    public String showDeleteGamePage(@PathVariable("gameId") long gameId, Model model) {
        GameBindingModel gameBindingModel = this.gameService.findById(gameId);
        model.addAttribute("gameBindingModel", gameBindingModel);
        return "templates/delete-game";
    }

    @PostMapping("/games/delete/{gameId}")
    public String deleteGame(@PathVariable("gameId") long gameId) {
        this.gameService.deleteById(gameId);
        return "redirect:/games";
    }
}