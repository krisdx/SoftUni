package app.models;

import javax.persistence.*;
import java.io.Serializable;
import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name = "anomalies")
public class Anomaly implements Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @ManyToOne(optional = false)
    private Planet originPlanet;

    @ManyToOne(optional = false)
    private Planet teleportPlanet;

    @ManyToMany(fetch = FetchType.EAGER)
    @JoinTable(name = "anomaly_victims",
            joinColumns = @JoinColumn(name = "anomaly_id", referencedColumnName = "id"),
            inverseJoinColumns = @JoinColumn(name = "person_id", referencedColumnName = "id"))
    private Set<Person> victims;

    public Anomaly() {
        this.setVictims(new HashSet<>());
    }

    public Anomaly(Planet originPlanet, Planet teleportPlanet) {
        this();
        this.setOriginPlanet(originPlanet);
        this.setTeleportPlanet(teleportPlanet);
    }

    public Long getId() {
        return this.id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Planet getOriginPlanet() {
        return this.originPlanet;
    }

    public void setOriginPlanet(Planet originPlanet) {
        this.originPlanet = originPlanet;
    }

    public Planet getTeleportPlanet() {
        return this.teleportPlanet;
    }

    public void setTeleportPlanet(Planet teleportPlanet) {
        this.teleportPlanet = teleportPlanet;
    }

    public Set<Person> getVictims() {
        return this.victims;
    }

    public void setVictims(Set<Person> victims) {
        this.victims = victims;
    }

    public void addVictim(Person victim) {
        if (victim == null) {
            throw new IllegalArgumentException("The civtim cannot be null.");
        }

        this.getVictims().add(victim);
    }
}