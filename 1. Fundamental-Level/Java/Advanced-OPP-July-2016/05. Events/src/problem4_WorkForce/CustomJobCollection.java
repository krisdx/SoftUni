package problem4_WorkForce;

import problem4_WorkForce.contracts.Job;
import problem4_WorkForce.contracts.JobCollection;
import problem4_WorkForce.events.JobDoneEvent;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class CustomJobCollection implements JobCollection {

    private CustomList<Job> jobCollection;

    public CustomJobCollection() {
        this.jobCollection = new CustomList<>();
    }

    @Override
    public void addJob(Job job) {
        this.jobCollection.add(job);
    }

    public void updateJobs() {
        List<JobDoneEvent> jobsToRemove = new ArrayList<>();
        for (Job job : this.jobCollection) {
            JobDoneEvent jobDoneEvent = job.update();
            if (jobDoneEvent != null) {
                jobsToRemove.add(jobDoneEvent);
            }
        }

        jobsToRemove.forEach(this::handleJobDoneEvent);
    }

    @Override
    public List<Job> getJobs() {
        return Collections.unmodifiableList(this.jobCollection);
    }

    private void handleJobDoneEvent(JobDoneEvent jobDoneEvent) {
        this.jobCollection.handleJobDoneEvent(jobDoneEvent);
    }
}