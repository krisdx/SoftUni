import entities.Employee;
import entities.Project;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import java.util.ArrayList;
import java.util.List;

public class Problem9_DeleteProjectById {

    private static final  int TARGET_PROJECT_ID = 2;

    public static void main(String[] args) {
        EntityManagerFactory emf =
                Persistence.createEntityManagerFactory("soft_uni");
        EntityManager em = emf.createEntityManager();

        em.getTransaction().begin();

        Query getEmployeeProjectsQuery = em.createQuery("SELECT e FROM Employee AS e");
        List<Employee> employees= getEmployeeProjectsQuery.getResultList();
        for (Employee employee : employees) {
            List<Project> projectsToRemove = new ArrayList<>();
            for (Project project : employee.getProjects()) {
                if (project.getProjectId() == TARGET_PROJECT_ID){
                    projectsToRemove.add(project);
                }
            }
            employee.getProjects().removeAll(projectsToRemove);
        }

        Project projectToRemove = em.find(Project.class, TARGET_PROJECT_ID);
        em.remove(projectToRemove);

        em.getTransaction().commit();
        em.close();
        emf.close();
    }
}