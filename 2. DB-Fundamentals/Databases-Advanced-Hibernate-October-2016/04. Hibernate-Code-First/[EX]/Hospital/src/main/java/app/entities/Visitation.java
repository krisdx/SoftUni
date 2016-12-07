package app.entities;

import javax.persistence.*;
import java.util.Date;
import java.util.List;

@Entity(name = "visitations")
public class Visitation {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @Basic
    private Date date;

    @ManyToOne
    @JoinColumn(name = "patient_id", referencedColumnName = "id")
    private Patient patient;

    @OneToMany(mappedBy = "visitation", targetEntity = Comment.class)
    private List<Comment> comments;
}