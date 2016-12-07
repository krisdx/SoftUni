import entities.Employee;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.TypedQuery;
import java.util.List;
import java.util.Scanner;

public class Problem5_ContainsEmployee {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] targetName = scanner.nextLine().split(" ");
        String targetFirstName = targetName[0];
        String targetLastName = targetName[1];

        EntityManagerFactory emf =
                Persistence.createEntityManagerFactory("soft_uni");
        EntityManager em = emf.createEntityManager();

        em.getTransaction().begin();

        TypedQuery<Employee> studentsWithNameQuery = em.createQuery("SELECT e FROM Employee AS e" +
                " WHERE e.firstName = :target_fist_name" +
                " AND e.lastName = :target_last_name", Employee.class);
        studentsWithNameQuery.setParameter("target_fist_name", targetFirstName);
        studentsWithNameQuery.setParameter("target_last_name", targetLastName);

        List<Employee> students = studentsWithNameQuery.getResultList();
        System.out.println(students.size() > 0 ? "Yes" : "No");

        em.getTransaction().commit();
        em.close();
        emf.close();
    }
}