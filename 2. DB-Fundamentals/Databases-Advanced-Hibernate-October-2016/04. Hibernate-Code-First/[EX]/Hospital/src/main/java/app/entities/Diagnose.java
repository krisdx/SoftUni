package app.entities;

import javax.persistence.*;
import java.util.List;

@Entity
public class Diagnose {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private long id;

    @Column(name = "name")
    private String name;

    @ManyToOne
    @JoinColumn(name = "patient_id", referencedColumnName = "id")
    private Patient patient;

    @OneToMany(mappedBy = "diagnose", targetEntity = Comment.class)
    private List<Comment> comments;
}