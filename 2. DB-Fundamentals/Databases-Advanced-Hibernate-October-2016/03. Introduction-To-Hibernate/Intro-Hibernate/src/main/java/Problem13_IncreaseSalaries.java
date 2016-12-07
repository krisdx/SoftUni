import entities.Employee;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import java.math.BigDecimal;
import java.util.List;

public class Problem13_IncreaseSalaries {
    public static void main(String[] args) {
        EntityManagerFactory emf =
                Persistence.createEntityManagerFactory("soft_uni");
        EntityManager em = emf.createEntityManager();

        em.getTransaction().begin();

        Query getEmployeeProjectsQuery = em.createQuery("SELECT e FROM Employee AS e" +
                " JOIN e.department AS d" +
                " WHERE d.name IN('Engineering', 'Tool Design', 'Marketing', 'Information Services')");
        List<Employee> employees = getEmployeeProjectsQuery.getResultList();
        for (Employee employee : employees) {
            em.persist(employee);
            employee.setSalary(employee.getSalary().add(employee.getSalary().multiply(new BigDecimal("0.12"))));

            System.out.printf("%s %s ($%s)%n",
                    employee.getFirstName(), employee.getLastName(), employee.getSalary());
        }

        em.getTransaction().commit();
        em.close();
        emf.close();
    }
}