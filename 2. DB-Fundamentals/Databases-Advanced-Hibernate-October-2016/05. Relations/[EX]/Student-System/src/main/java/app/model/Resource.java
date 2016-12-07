package app.model;

import app.model.enums.ResourceType;

import javax.persistence.*;

@Entity(name = "resources")
public class Resource {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false)
    private String name;

    @Column(nullable = false)
    @Enumerated
    private ResourceType resourceType;

    @Column(nullable = false)
    private String url;

    public Resource() {
    }

    public Resource(String name, ResourceType resourceType, String url) {
        this.setName(name);
        this.setResourceType(resourceType);
        this.setUrl(url);
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

    public ResourceType getResourceType() {
        return this.resourceType;
    }

    public void setResourceType(ResourceType resourceType) {
        this.resourceType = resourceType;
    }

    public String getUrl() {
        return this.url;
    }

    public void setUrl(String url) {
        this.url = url;
    }
}