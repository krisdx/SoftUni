import entities.Department;
import entities.Employee;

import javax.persistence.*;
import java.math.BigDecimal;
import java.util.List;
import java.util.Objects;
import java.util.Scanner;

public class Problem16_EmployeesMaximumSalaries {
    public static void main(String[] args) {

        EntityManagerFactory emf =
                Persistence.createEntityManagerFactory("soft_uni");
        EntityManager em = emf.createEntityManager();

        em.getTransaction().begin();

        TypedQuery<Object[]> maxSalaryForEachDepartmentQuery = em.createQuery("SELECT d.name, MAX(e.salary)" +
                        " FROM Employee AS e" +
                        " JOIN e.department AS d" +
                        " GROUP BY d.id" +
                        " HAVING MAX(e.salary) < 30000 OR MAX(e.salary) > 70000",
                Object[].class);
        List<Object[]> maxSalariesByDepartment = maxSalaryForEachDepartmentQuery.getResultList();
        for (Object[] objects : maxSalariesByDepartment) {
            String departmentName = (String) objects[0];
            BigDecimal maxSalary = (BigDecimal) objects[1];
            System.out.println(departmentName + " - " + maxSalary);
        }

        em.getTransaction().commit();
        em.close();
        emf.close();
    }
}