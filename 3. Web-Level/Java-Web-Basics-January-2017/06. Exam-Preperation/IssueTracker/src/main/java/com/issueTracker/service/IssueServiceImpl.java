package com.issueTracker.service;

import com.issueTracker.entity.issue.Issue;
import com.issueTracker.entity.issue.Priority;
import com.issueTracker.entity.issue.Status;
import com.issueTracker.model.binding.IssueBindingModel;
import com.issueTracker.model.view.IssueViewModel;
import com.issueTracker.repository.IssueRepository;
import org.modelmapper.ModelMapper;

import javax.ejb.Stateless;
import javax.inject.Inject;
import java.util.HashSet;
import java.util.Set;

@Stateless
public class IssueServiceImpl implements IssueService {

    private final IssueRepository issueRepository;
    private final ModelMapper modelMapper;

    @Inject
    public IssueServiceImpl(IssueRepository issueRepository) {
        this.issueRepository = issueRepository;
        this.modelMapper = new ModelMapper();
    }

    @Override
    public void save(IssueBindingModel issueBindingModel) {
        Issue issue = this.modelMapper.map(issueBindingModel, Issue.class);
        issue.setStatus(Status.valueOf(issueBindingModel.getStatus().toUpperCase()));
        issue.setPriority(Priority.valueOf(issueBindingModel.getPriority().toUpperCase()));
        this.issueRepository.save(issue);
    }

    @Override
    public void update(IssueBindingModel issueBindingModel) {
        Issue issue = this.modelMapper.map(issueBindingModel, Issue.class);
        issue.setStatus(Status.valueOf(issueBindingModel.getStatus().toUpperCase()));
        issue.setPriority(Priority.valueOf(issueBindingModel.getPriority().toUpperCase()));
        this.issueRepository.update(issue);
    }

    @Override
    public Set<IssueViewModel> findAll() {
        Set<Issue> issues = this.issueRepository.findAll();
        Set<IssueViewModel> issueViewModels = new HashSet<>();
        for (Issue issue : issues) {
            IssueViewModel issueViewModel = this.modelMapper.map(issue, IssueViewModel.class);
            issueViewModels.add(issueViewModel);
        }

        return issueViewModels;
    }

    @Override
    public Set<IssueViewModel> searchIssues(String status) {
        Set<Issue> issues = this.issueRepository.findAllByStatus(status);
        Set<IssueViewModel> issueViewModels = new HashSet<>();
        for (Issue issue : issues) {
            IssueViewModel issueViewModel = this.modelMapper.map(issue, IssueViewModel.class);
            issueViewModels.add(issueViewModel);
        }

        return issueViewModels;
    }

    @Override
    public Set<IssueViewModel> searchIssues(String status, String name) {
        Set<Issue> issues = this.issueRepository.findAllByStatusAndName(status, name);
        Set<IssueViewModel> issueViewModels = new HashSet<>();
        for (Issue issue : issues) {
            IssueViewModel issueViewModel = this.modelMapper.map(issue, IssueViewModel.class);
            issueViewModels.add(issueViewModel);
        }

        return issueViewModels;
    }

    @Override
    public IssueViewModel findById(long id) {
        Issue issue = this.issueRepository.findById(id);
        return this.modelMapper.map(issue, IssueViewModel.class);
    }

    @Override
    public void deleteById(long id) {
        this.issueRepository.deleteById(id);
    }
}