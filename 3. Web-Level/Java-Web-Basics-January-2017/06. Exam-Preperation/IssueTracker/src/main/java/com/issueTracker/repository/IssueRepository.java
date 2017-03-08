package com.issueTracker.repository;

import com.issueTracker.entity.issue.Issue;

import java.util.Set;

public interface IssueRepository {
    void save(Issue issue);

    void update(Issue issue);

    Set<Issue> findAll();

    Set<Issue> findAllByStatusAndName(String status, String name);

    Issue findById(long id);

    void deleteById(long id);

    Set<Issue> findAllByStatus(String status);
}