package app.models;

import javax.persistence.*;
import java.io.Serializable;

@Entity
@Table(name = "planets")
public class Planet implements Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(length = 100, nullable = false)
    private String name;

    @ManyToOne(optional = false)
    private Star sun;

    @ManyToOne(optional = false)
    private SolarSystem solarSystem;

    public Planet() {
    }

    public Long getId() {
        return this.id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Star getSun() {
        return this.sun;
    }

    public void setSun(Star sun) {
        this.sun = sun;
    }

    public SolarSystem getSolarSystem() {
        return this.solarSystem;
    }

    public void setSolarSystem(SolarSystem solarSystem) {
        this.solarSystem = solarSystem;
    }
}