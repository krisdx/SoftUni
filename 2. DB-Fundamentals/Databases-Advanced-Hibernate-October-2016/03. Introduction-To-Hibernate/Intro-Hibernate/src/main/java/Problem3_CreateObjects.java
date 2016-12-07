import entities.*;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;

public class Problem3_CreateObjects {
    public static void main(String[] args) {

        EntityManagerFactory emf =
                Persistence.createEntityManagerFactory("soft_uni");
        EntityManager em = emf.createEntityManager();

        em.getTransaction().begin();

        Department trainingDepartment = new Department();
        trainingDepartment.setName("Training");
        Employee trainingDepartmentManager = em.find(Employee.class, 2);
        trainingDepartment.setManager(trainingDepartmentManager);

        Town burgasTown = new Town();
        burgasTown.setName("Burgas");

        Address address = new Address();
        address.setTown(burgasTown);
        address.setAddressText("This is Burgas");

        Project project = new Project();
        project.setName("Some project");
        project.setDescription("this is the description");
        project.setStartDate(new Date());
        project.setEndDate(new Date());

        Employee employee = new Employee();
        employee.setFirstName("Ivan");
        employee.setMiddleName("Ivanov");
        employee.setLastName("Ivanov");
        employee.setJobTitle("Senior Developr");
        employee.setSalary(new BigDecimal("10000"));
        employee.setAddress(address);
        employee.setHireDate(new Date());
        employee.setDepartment(trainingDepartment);
        Employee managerOfIvan = em.find(Employee.class, 1);
        employee.setManager(managerOfIvan);
        employee.setProjects(new ArrayList<>());
        employee.getProjects().add(project);

        em.persist(trainingDepartment);
        em.persist(burgasTown);
        em.persist(address);
        em.persist(project);
        em.persist(employee);

        em.getTransaction().commit();
        em.close();
        emf.close();
    }
}