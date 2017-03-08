package com.issueTracker.controller;

import com.issueTracker.entity.user.User;
import com.issueTracker.model.binding.LoginModel;
import com.issueTracker.model.binding.UserModel;
import com.issueTracker.service.UserService;
import com.mvcFramework.annotations.controller.Controller;
import com.mvcFramework.annotations.parameters.ModelAttribute;
import com.mvcFramework.annotations.request.GetMapping;
import com.mvcFramework.annotations.request.PostMapping;
import com.mvcFramework.models.Model;

import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.servlet.http.HttpSession;
import javax.validation.ConstraintViolation;
import javax.validation.Validation;
import javax.validation.Validator;
import java.util.Set;

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
    public String registerUser(@ModelAttribute UserModel userModel, Model model) {
        Validator validator = Validation.buildDefaultValidatorFactory().getValidator();
        Set<ConstraintViolation<UserModel>> constraintViolations = validator.validate(userModel);
        if (!constraintViolations.isEmpty()) {
            model.addAttribute("constraintViolations", constraintViolations);
            return "/templates/register";
        }

        if (!userModel.getPassword().equals(userModel.getRepeatPassword())) {
            model.addAttribute("passwordMismatch", "passwordMismatch");
            return "/templates/register";
        }

        User user = this.userService.find(userModel.getUsername());
        if (user != null) {
            model.addAttribute("duplicateUsername", userModel.getUsername());
            return "/templates/register";
        }

        this.userService.registerUser(userModel);
        model.addAttribute("successfulRegistration", "You've been successfully registered.");
        return "/templates/login";
    }

    @GetMapping("/login")
    public String getLoginPage() {
        return "/templates/login";
    }

    @PostMapping("/login")
    public String login(@ModelAttribute LoginModel loginModel, Model model, HttpSession session) {
        User user = this.userService.find(loginModel);
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
