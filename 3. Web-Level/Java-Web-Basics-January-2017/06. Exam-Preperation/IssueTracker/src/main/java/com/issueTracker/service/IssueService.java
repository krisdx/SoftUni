package com.issueTracker.service;

import com.issueTracker.model.binding.IssueBindingModel;
import com.issueTracker.model.view.IssueViewModel;

import java.util.Set;

public interface IssueService {

    void save(IssueBindingModel issueBindingModel);

    void update(IssueBindingModel issueBindingModel);

    Set<IssueViewModel> findAll();

    Set<IssueViewModel> searchIssues(String status);

    Set<IssueViewModel> searchIssues(String status, String name);

    IssueViewModel findById(long id);

    void deleteById(long id);
}