import entities.Project;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import java.util.List;

public class Problem12_FindLatestProjects {
    public static void main(String[] args) {
        EntityManagerFactory emf =
                Persistence.createEntityManagerFactory("soft_uni");
        EntityManager em = emf.createEntityManager();

        em.getTransaction().begin();

        Query getEmployeeProjectsQuery = em.createQuery("SELECT p FROM Project AS p" +
                " ORDER BY p.startDate DESC , p.name ASC");
        List<Project> latestProjects = getEmployeeProjectsQuery.setMaxResults(10).getResultList();
        for (Project project: latestProjects) {
            System.out.printf("%s %s %s %s%n",
                    project.getName(), project.getDescription(),
                    project.getStartDate(), project.getEndDate());
        }

        em.getTransaction().commit();
        em.close();
        emf.close();
    }
}