package app.models;

import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;

@Entity
@DiscriminatorValue(value = "Half Time")
public class HalfTimeEmployee extends Employee {

    private Boolean isStudent;

    public HalfTimeEmployee() {
    }

    public Boolean getIsStudent() {
        return this.isStudent;
    }

    public void seIstStudent(Boolean student) {
        this.isStudent = student;
    }
}
