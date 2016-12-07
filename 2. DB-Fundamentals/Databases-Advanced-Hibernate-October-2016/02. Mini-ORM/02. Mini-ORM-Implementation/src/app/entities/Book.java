package app.entities;

import app.persistence.Column;
import app.persistence.Entity;
import app.persistence.Id;

import java.util.Date;

@Entity(name = "books")
public class Book {

    @Id
    private long id;

    @Column(name = "title")
    private String title;

    @Column(name = "author")
    private String author;

    @Column(name = "published_on")
    private Date publishedOn;

    @Column(name = "language")
    private String language;

    @Column(name = "is_hard_covered")
    private boolean isHardCovered;

    public Book(String title, String author, Date publishedOn, String language, boolean isHardCovered) {
        this.title = title;
        this.author = author;
        this.publishedOn = publishedOn;
        this.language = language;
        this.isHardCovered = isHardCovered;
    }

    public long getId() {
        return this.id;
    }

    public String getTitle() {
        return this.title;
    }

    public String getAuthor() {
        return this.author;
    }

    public Date getPublishedOn() {
        return this.publishedOn;
    }

    public String getLanguage() {
        return this.language;
    }

    public boolean isHardCovered() {
        return this.isHardCovered;
    }
}