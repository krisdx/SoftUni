package problem4_WorkForce;

import problem4_WorkForce.contracts.JobDoneListener;
import problem4_WorkForce.events.JobDoneEvent;

import java.util.ArrayList;

public class CustomList<E> extends ArrayList<E> implements JobDoneListener {

    @Override
    public void handleJobDoneEvent(JobDoneEvent jobDoneEvent) {
        this.remove(jobDoneEvent.getSource());
    }
}