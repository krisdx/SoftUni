import entities.Address;
import entities.Employee;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;

public class Problem8_UpdateEmployee {
    public static void main(String[] args) {
        EntityManagerFactory emf =
                Persistence.createEntityManagerFactory("soft_uni");
        EntityManager em = emf.createEntityManager();

        em.getTransaction().begin();

        Address address = new Address();
        address.setAddressText("Vitoshka 15");
        em.persist(address);

        Query getEmployeeQuery = em.createQuery("SELECT e FROM Employee AS e" +
                " WHERE e.lastName = 'Nakov'");
        Employee employee = (Employee) getEmployeeQuery.getSingleResult();
        employee.setAddress(address);

        em.persist(employee);
        em.getTransaction().commit();

        Employee resultEmployee = (Employee) getEmployeeQuery.getSingleResult();
        System.out.println(resultEmployee.getAddress().getAddressText());

        em.close();
        emf.close();
    }
}