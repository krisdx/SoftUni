package com.gameStore.controller;

import com.gameStore.entity.user.Role;
import com.gameStore.entity.user.User;
import com.gameStore.service.GameService;
import com.mvcFramework.annotations.controller.Controller;
import com.mvcFramework.annotations.parameters.RequestParam;
import com.mvcFramework.annotations.request.GetMapping;
import com.mvcFramework.models.Model;

import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.servlet.http.HttpSession;

@Stateless
@Controller
public class HomeController {

    private final GameService gameService;

    @Inject
    public HomeController(GameService gameService) {
        this.gameService = gameService;
    }

    @GetMapping("/")
    public String getHomePage(@RequestParam("filter") String filter, Model model, HttpSession session) {
        User currentUser = (User) session.getAttribute("currentUser");
        if (currentUser == null) {
            model.addAttribute("games", this.gameService.findAll());
            return "templates/guest-home";
        }

        if (filter == null || filter.equalsIgnoreCase("all")) {
            model.addAttribute("games", this.gameService.findAll());
        } else {
            model.addAttribute("games", this.gameService.findGamesByUser(currentUser));
        }

        if (currentUser.getRole() == Role.ADMIN) {
            return "templates/admin-home";
        }

        return "/templates/user-home";
    }
}