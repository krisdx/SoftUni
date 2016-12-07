package app.models;

import javax.persistence.Column;
import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;
import javax.persistence.PrimaryKeyJoinColumn;

@Entity(name = "half_time_employees")
@PrimaryKeyJoinColumn(name = "id")
public class HalfTimeEmployee extends Employee {

    @Column(name = "is_student")
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
