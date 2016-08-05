package problem4_WorkForce;

import problem4_WorkForce.contracts.Employee;
import problem4_WorkForce.contracts.Job;
import problem4_WorkForce.events.JobDoneEvent;

public class JobImpl implements Job {

    private String name;
    private int hoursOfWorkRequired;
    private Employee employee;
    private CustomJobCollection jobCollection;

    public JobImpl(
            String name,
            int hoursOfWorkRequired,
            Employee employee,
            CustomJobCollection jobCollection) {
        this.name = name;
        this.hoursOfWorkRequired = hoursOfWorkRequired;
        this.employee = employee;
        this.jobCollection = jobCollection;
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public int getHoursOfWorkRequired() {
        return this.hoursOfWorkRequired;
    }

    @Override
    public JobDoneEvent update() {
        this.hoursOfWorkRequired -= this.employee.getWorkHoursPerWeek();
        if (this.hoursOfWorkRequired <= 0) {
            // Trigger JobImpl Done Event
            System.out.printf("Job %s done!%n", this.name);
            return new JobDoneEvent(this);
        }

        return null;
    }

    @Override
    public String toString() {
        return String.format("Job: %s Hours Remaining: %d",
                this.getName(), this.getHoursOfWorkRequired());
    }
}