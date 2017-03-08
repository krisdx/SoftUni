package com.issueTracker.controller;

import com.issueTracker.entity.user.User;
import com.issueTracker.model.binding.IssueBindingModel;
import com.issueTracker.model.view.IssueViewModel;
import com.issueTracker.service.IssueService;
import com.issueTracker.service.UserService;
import com.mvcFramework.annotations.controller.Controller;
import com.mvcFramework.annotations.parameters.ModelAttribute;
import com.mvcFramework.annotations.parameters.PathVariable;
import com.mvcFramework.annotations.parameters.RequestParam;
import com.mvcFramework.annotations.request.GetMapping;
import com.mvcFramework.annotations.request.PostMapping;
import com.mvcFramework.models.Model;

import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.servlet.http.HttpSession;
import java.util.Date;

@Stateless
@Controller
public class IssueController {

    private final UserService userService;
    private final IssueService issueService;

    @Inject
    public IssueController(UserService userService, IssueService issueService) {
        this.userService = userService;
        this.issueService = issueService;
    }

    @GetMapping("/issues")
    public String getIssuesPage(Model model, @RequestParam("status") String status, @RequestParam("name") String name, HttpSession session) {
        User currentUser = (User) session.getAttribute("currentUser");
        if (currentUser == null) {
            return "redirect:/login";
        }

        boolean hasStatus = status != null;
        boolean hasName = (name != null && !name.isEmpty());
        if (hasStatus && status.equalsIgnoreCase("all")) {
            model.addAttribute("issues", this.issueService.findAll());
        } else if (hasStatus && hasName) {
            model.addAttribute("issues", this.issueService.searchIssues(status, name));
        } else if (hasStatus && !hasName) {
            model.addAttribute("issues", this.issueService.searchIssues(status));
        } else {
            model.addAttribute("issues", this.issueService.findAll());
        }

        return "templates/issues";
    }

    @GetMapping("/issues/add")
    public String getIssuesAddPage() {
        return "templates/add-issue";
    }

    @PostMapping("/issues/add")
    public String addIssue(@ModelAttribute IssueBindingModel issueBindingModel, HttpSession session) {
        User currentUser = (User) session.getAttribute("currentUser");
        issueBindingModel.setAuthor(currentUser);
        issueBindingModel.setCreatedOn(new Date());
        this.issueService.save(issueBindingModel);
        return "redirect:/issues";
    }

    @GetMapping("/issues/edit/{issueId}")
    public String editIssueEditPage(@PathVariable("issueId") long issueId, Model model) {
        IssueViewModel issueViewModel = this.issueService.findById(issueId);
        model.addAttribute("issueViewModel", issueViewModel);
        return "templates/edit-issue";
    }

    @PostMapping("/issue/edit/{issueId}")
    public String editIssue(@PathVariable("issueId") long issueId, @ModelAttribute IssueBindingModel issueBindingModel) {
        issueBindingModel.setId(issueId);
        this.issueService.update(issueBindingModel);
        return "redirect:/issues";
    }

    @GetMapping("/issues/delete/{issueId}")
    public String deleteIssue(@PathVariable("issueId") long issueId) {
        this.issueService.deleteById(issueId);
        return "redirect:/issues";
    }
}