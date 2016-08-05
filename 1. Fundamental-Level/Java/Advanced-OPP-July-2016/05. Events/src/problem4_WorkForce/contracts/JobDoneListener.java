package problem4_WorkForce.contracts;

import problem4_WorkForce.events.JobDoneEvent;

public interface JobDoneListener {
    void handleJobDoneEvent(JobDoneEvent jobDoneEvent);
}