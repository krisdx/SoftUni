import entities.Employee;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.TypedQuery;
import java.util.List;
import java.util.Scanner;

public class Problem15_FindEmployeesByFirstName {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String targetNamePattern = scanner.nextLine();

        EntityManagerFactory emf =
                Persistence.createEntityManagerFactory("soft_uni");
        EntityManager em = emf.createEntityManager();

        em.getTransaction().begin();

        TypedQuery<Employee> getEmployeesByNameQuery = em.createQuery("SELECT e FROM Employee AS e" +
                " WHERE SUBSTRING(e.firstName, 1, :patternLength) = :namePattern", Employee.class);
        getEmployeesByNameQuery.setParameter("patternLength", targetNamePattern.length());
        getEmployeesByNameQuery.setParameter("namePattern", targetNamePattern);
        List<Employee> employees = getEmployeesByNameQuery.getResultList();
        for (Employee employee : employees) {
            System.out.printf("%s %s - %s - ($%s)%n",
                    employee.getFirstName(), employee.getLastName(),
                    employee.getDepartment().getName(), employee.getSalary());
        }

        em.getTransaction().commit();
        em.close();
        emf.close();
    }
}