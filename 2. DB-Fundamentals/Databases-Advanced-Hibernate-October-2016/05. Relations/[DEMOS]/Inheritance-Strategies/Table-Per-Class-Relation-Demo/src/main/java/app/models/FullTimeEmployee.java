package app.models;

import javax.persistence.Column;
import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;

@Entity(name = "full_time_employees")
public class FullTimeEmployee extends Employee{

    @Column(name = "work_hours")
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
