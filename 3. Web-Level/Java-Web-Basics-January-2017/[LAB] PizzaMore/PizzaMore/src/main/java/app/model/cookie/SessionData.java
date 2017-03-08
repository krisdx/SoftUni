package app.model.cookie;

import javax.persistence.*;

@Entity
@Table(name = "sessions_data")
public class SessionData {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(name = "key_data")
    private String key;

    @Column(name = "value_data")
    private String value;

    @ManyToOne
    @JoinColumn(name = "session_id")
    private Session session;

    public SessionData() {
    }

    public SessionData(String key, String value, Session session) {
        this.setKey(key);
        this.setValue(value);
        this.setSession(session);
    }

    public Long getId() {
        return this.id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getKey() {
        return this.key;
    }

    public void setKey(String key) {
        this.key = key;
    }

    public String getValue() {
        return this.value;
    }

    public void setValue(String value) {
        this.value = value;
    }

    public Session getSession() {
        return this.session;
    }

    public void setSession(Session session) {
        this.session = session;
    }
}