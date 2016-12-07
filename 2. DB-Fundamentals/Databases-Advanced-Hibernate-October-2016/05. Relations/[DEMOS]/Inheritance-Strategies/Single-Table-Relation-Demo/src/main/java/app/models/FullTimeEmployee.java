package app.models;

import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;

@Entity
@DiscriminatorValue(value = "Full Time")
public class FullTimeEmployee extends Employee{

    private Integer workHours;

    public FullTimeEmployee() {
    }

    public Integer getWorkHours() {
        return this.workHours;
    }

    public void setWorkHours(Integer workHours) {
        this.workHours = workHours;
    }
}
