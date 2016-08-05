package problem4_WorkForce.contracts;

import problem4_WorkForce.events.JobDoneEvent;

public interface Job {
    String getName();

    int getHoursOfWorkRequired();

    /**
     * If the job is done is prints the message:
     * <p>
     * <b>Job "name" done!</b>
     * <p>
     *
     * @return JobDoneEvent if the job has been finished.
     * Otherwise it returns null.
     */
    JobDoneEvent update();
}