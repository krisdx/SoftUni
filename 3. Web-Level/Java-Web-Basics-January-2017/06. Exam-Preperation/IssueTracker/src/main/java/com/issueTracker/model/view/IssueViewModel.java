package com.issueTracker.model.view;

import com.issueTracker.entity.issue.Priority;
import com.issueTracker.entity.issue.Status;

import java.util.Date;

public class IssueViewModel {

    private long id;
    private String name;
    private Priority priority;
    private Status status;
    private Date createdOn;
    private String authorUsername;

    public IssueViewModel() {
    }

    public long getId() {
        return this.id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Priority getPriority() {
        return this.priority;
    }

    public void setPriority(Priority priority) {
        this.priority = priority;
    }

    public Status getStatus() {
        return this.status;
    }

    public void setStatus(Status status) {
        this.status = status;
    }

    public Date getCreatedOn() {
        return this.createdOn;
    }

    public void setCreatedOn(Date createdOn) {
        this.createdOn = createdOn;
    }

    public String getAuthorUsername() {
        return this.authorUsername;
    }

    public void setAuthorUsername(String authorUsername) {
        this.authorUsername = authorUsername;
    }
}
