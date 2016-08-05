package problem4_WorkForce.contracts;

import java.util.List;

/**
 * Custom collection that holds a list of jobs,
 * and several operations for them.
 */
public interface JobCollection {
    void addJob(Job job);

    /**
     * Updates all the jobs in the collection.
     * If some job is finished, it print message,
     * and it's removed from the collection
     */
    void updateJobs();

    List<Job> getJobs();
}