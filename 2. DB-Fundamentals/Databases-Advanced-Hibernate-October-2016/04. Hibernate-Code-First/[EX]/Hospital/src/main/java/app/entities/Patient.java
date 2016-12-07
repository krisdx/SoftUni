package app.entities;

import javax.persistence.*;
import java.io.Serializable;
import java.util.Date;
import java.util.Set;

@Entity(name = "patients")
public class Patient implements Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @Column(name = "fist_name")
    private String firstName;

    @Column(name = "last_name")
    private String lastName;

    @Column(name = "address")
    private String address;

    @Column(name = "email")
    private String email;

    @Column(name = "date_of_birth")
    private Date birthDate;

    @Column(name = "picture", columnDefinition = "BLOB")
    private byte[] picture;

    @Column(name = "has_medical_insurance")
    private Boolean hasMedicalInsurance;

    @OneToMany(mappedBy = "patient", targetEntity = Visitation.class)
    private Set<Visitation> visitations;

    @OneToMany
    private Set<Diagnose> diagnoses;

    @OneToMany
    private Set<Medicament> medicaments;
}