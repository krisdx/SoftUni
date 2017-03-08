package app.model.cookie;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name = "sessions")
public class Session {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @OneToMany(mappedBy = "session", cascade = CascadeType.ALL, fetch = FetchType.EAGER, orphanRemoval = true)
    private Set<SessionData> sessionData;

    public Session() {
        this.setSessionData(new HashSet<>());
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Set<SessionData> getSessionData() {
        return sessionData;
    }

    public void setSessionData(Set<SessionData> sessionData) {
        this.sessionData = sessionData;
    }

    public void addData(String key, String value) {
        this.getSessionData().add(new SessionData(key, value, this));
    }
}