package app.domain.dto;

import com.google.gson.annotations.Expose;

import java.io.Serializable;

public class CategoryDto implements Serializable {

    @Expose
    private String name;

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }
}