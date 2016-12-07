package app.model;

import app.model.enums.AgeRestriction;
import app.model.enums.EditionType;

import javax.persistence.*;
import java.math.BigDecimal;
import java.util.Date;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

@Entity(name = "books")
public class Book {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(length = 50, nullable = false)
    private String title;

    @Column(columnDefinition = "TEXT", length = 1000, nullable = true)
    private String description;

    @Column(nullable = false)
    @Enumerated(EnumType.STRING)
    private EditionType editionType;

    @Column(nullable = false)
    @Enumerated(EnumType.STRING)
    private AgeRestriction ageRestriction;

    @Column(columnDefinition = "DECIMAL(60, 30)", nullable = false)
    private BigDecimal price;

    @Column(nullable = false)
    private Long copies;

    @Column(nullable = true)
    private Date releaseDate;

    @ManyToOne(optional = false)
    private Author author;

    @ManyToMany
    private Set<Category> categories;

    @ManyToMany(cascade = CascadeType.ALL, fetch = FetchType.EAGER)
    @JoinTable(name = "related_books",
            joinColumns = @JoinColumn(name = "book_id"),
            inverseJoinColumns = @JoinColumn(name = "related_book_id"))
    private Set<Book> relatedBooks;

    public Book() {
    }

    public Book(String title,
                EditionType editionType,
                AgeRestriction ageRestriction,
                BigDecimal price,
                Long copies,
                Date releaseDate,
                Author author,
                Set<Category> categories) {
        this.setTitle(title);
        this.setEditionType(editionType);
        this.setAgeRestriction(ageRestriction);
        this.setPrice(price);
        this.setCopies(copies);
        this.setReleaseDate(releaseDate);
        this.setAuthor(author);
        this.setCategories(categories);
    }

    public Long getId() {
        return this.id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getTitle() {
        return this.title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getDescription() {
        return this.description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public EditionType getEditionType() {
        return this.editionType;
    }

    public void setEditionType(EditionType editionType) {
        this.editionType = editionType;
    }

    public AgeRestriction getAgeRestriction() {
        return this.ageRestriction;
    }

    public void setAgeRestriction(AgeRestriction ageRestriction) {
        this.ageRestriction = ageRestriction;
    }

    public BigDecimal getPrice() {
        return this.price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }

    public Long getCopies() {
        return this.copies;
    }

    public void setCopies(Long copies) {
        this.copies = copies;
    }

    public Date getReleaseDate() {
        return this.releaseDate;
    }

    public void setReleaseDate(Date releaseDate) {
        this.releaseDate = releaseDate;
    }

    public Author getAuthor() {
        return this.author;
    }

    public void setAuthor(Author author) {
        this.author = author;
    }

    public Set<Category> getCategories() {
        return this.categories;
    }

    public void setCategories(Set<Category> categories) {
        this.categories = categories;
    }

    public Set<Book> getRelatedBooks() {
        return this.relatedBooks;
    }

    public void setRelatedBooks(Set<Book> relatedBooks) {
        this.relatedBooks = relatedBooks;
    }
}