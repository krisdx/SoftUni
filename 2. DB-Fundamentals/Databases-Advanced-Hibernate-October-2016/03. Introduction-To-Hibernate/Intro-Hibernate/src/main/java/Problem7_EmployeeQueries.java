import entities.Employee;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import java.util.List;
import java.util.stream.Collectors;

public class Problem7_EmployeeQueries {
    public static void main(String[] args) {
        EntityManagerFactory emf =
                Persistence.createEntityManagerFactory("soft_uni");
        EntityManager em = emf.createEntityManager();

        em.getTransaction().begin();

        Query employeesQuery = em.createQuery("SELECT e.firstName FROM Employee AS e" +
                " WHERE e.salary > 50000");

        List<String> employeesNames = employeesQuery.getResultList();
        for (String employeeName : employeesNames) {
            System.out.println(employeeName);
        }

        Query employeesFromDepartmentQuery = em.createQuery("SELECT e FROM Employee AS e" +
                " JOIN e.department AS d" +
                " WHERE d.name = 'Research and Development'");
        List<Employee> employees = employeesFromDepartmentQuery.getResultList();
        employees = employees
                .stream()
                .sorted((e1, e2) -> {
                    if (e1.getSalary().compareTo(e2.getSalary()) != 0) {
                        return e1.getSalary().compareTo(e2.getSalary());
                    }

                    return e2.getFirstName().compareTo(e1.getFirstName());
                }).collect(Collectors.toList());
        for (Employee employee : employees) {
            System.out.printf("%s %s from %s - $%.2f%n",
                    employee.getFirstName(),
                    employee.getLastName(),
                    employee.getDepartment().getName(),
                    employee.getSalary());
        }

        em.getTransaction().commit();
        em.close();
        emf.close();
    }
}