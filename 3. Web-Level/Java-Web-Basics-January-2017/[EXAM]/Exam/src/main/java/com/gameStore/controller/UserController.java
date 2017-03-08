package com.gameStore.controller;

import com.gameStore.entity.user.User;
import com.gameStore.model.binding.LoginBindingModel;
import com.gameStore.model.binding.UserBindingModel;
import com.gameStore.service.UserService;
import com.mvcFramework.annotations.controller.Controller;
import com.mvcFramework.annotations.parameters.ModelAttribute;
import com.mvcFramework.annotations.request.GetMapping;
import com.mvcFramework.annotations.request.PostMapping;
import com.mvcFramework.models.Model;

import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.servlet.http.HttpSession;

@Stateless
@Controller
public class UserController {

    private final UserService userService;

    @Inject
    public UserController(UserService userService) {
        this.userService = userService;
    }

    @GetMapping("/register")
    public String showRegisterPage() {
        return "/templates/register";
    }

    @PostMapping("/register")
    public String registerUser(@ModelAttribute UserBindingModel userBindingModel, Model model) {
//        Validator validator = Validation.buildDefaultValidatorFactory().getValidator();
//        Set<ConstraintViolation<UserBindingModel>> constraintViolations = validator.validate(userBindingModel);
//        if (!constraintViolations.isEmpty()) {
//            model.addAttribute("constraintViolations", constraintViolations);
//            return "/templates/register";
//        }

        if (!userBindingModel.getPassword().equals(userBindingModel.getConfirmPassword())) {
            model.addAttribute("passwordMismatch", "passwordMismatch");
            return "/templates/register";
        }

        User user = this.userService.find(userBindingModel.getEmail());
        if (user != null) {
            model.addAttribute("duplicateEmail", userBindingModel.getEmail());
            return "/templates/register";
        }

        this.userService.registerUser(userBindingModel);
        model.addAttribute("successfulRegistration", "You've been successfully registered.");
        return "redirect:/login";
    }

    @GetMapping("/login")
    public String showLoginPage() {
        return "/templates/login";
    }

    @PostMapping("/login")
    public String login(@ModelAttribute LoginBindingModel loginBindingModel, Model model, HttpSession session) {
        User user = this.userService.find(loginBindingModel);
        if (user == null) {
            model.addAttribute("unexistingUser", "Wrong username or password.");
            return "/templates/login";
        }

        session.setAttribute("currentUser", user);
        return "redirect:/";
    }

    @GetMapping("/logout")
    public String logOut(HttpSession session) {
        session.invalidate();
        return "redirect:/";
    }
}