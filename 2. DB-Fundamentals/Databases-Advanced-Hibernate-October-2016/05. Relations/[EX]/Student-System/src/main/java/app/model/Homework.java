package app.model;

import app.model.enums.ContentType;

import javax.persistence.*;
import java.util.Date;

@Entity(name = "homeworks")
public class Homework {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false)
    private String content;

    @Column(nullable = false)
    @Enumerated
    private ContentType contentType;

    @Column(nullable = false)
    private Date submissionDate;

    public Homework() {
    }


    public Homework(String content, ContentType contentType, Date submissionDate) {
        this.setContent(content);
        this.setContentType(contentType);
        this.setSubmissionDate(submissionDate);
    }

    public Long getId() {
        return this.id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getContent() {
        return this.content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public ContentType getContentType() {
        return this.contentType;
    }

    public void setContentType(ContentType contentType) {
        this.contentType = contentType;
    }

    public Date getSubmissionDate() {
        return this.submissionDate;
    }

    public void setSubmissionDate(Date submissionDate) {
        this.submissionDate = submissionDate;
    }
}