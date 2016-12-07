import entities.Address;
import entities.Employee;
import entities.Town;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Problem14_RemoveTowns {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String targetTownName = scanner.nextLine();

        EntityManagerFactory emf =
                Persistence.createEntityManagerFactory("soft_uni");
        EntityManager em = emf.createEntityManager();

        em.getTransaction().begin();

        Query getTownsQuery = em.createQuery("SELECT t FROM Town AS t" +
                " WHERE t.name = " + "'" + targetTownName + "'");
        List<Town> townsToRemove = getTownsQuery.getResultList();

        Query getAllAddressesQuery = em.createQuery("SELECT a FROM Address AS a");
        List<Address> addresses = getAllAddressesQuery.getResultList();
        List<Address> addressesToRemove = new ArrayList<>();
        for (Address address : addresses) {
            for (Town townToRemove : townsToRemove) {
                if (address.getTown() != null &&
                        address.getTown().getTownId() == townToRemove.getTownId()) {
                    addressesToRemove.add(address);
                }
            }
        }

        Query getAllEmployeesQuery = em.createQuery("SELECT e FROM Employee AS e");
        List<Employee> employees = getAllEmployeesQuery.getResultList();
        for (Employee employee : employees) {
            em.persist(employee);
            for (Address address : addressesToRemove) {
                if (employee.getAddress() != null &&
                        employee.getAddress().getAddressId() == address.getAddressId()) {
                    employee.setAddress(null);
                }
            }
        }

        for (Address address : addressesToRemove) {
            em.remove(address);
        }

        for (Town town : townsToRemove) {
            em.refresh(town);
        }

        em.getTransaction().commit();

        printResult(townsToRemove, addressesToRemove);

        em.close();
        emf.close();
    }

    private static void printResult(List<Town> townsToRemove, List<Address> addressesToRemove) {
        int addressesRemovedCount = addressesToRemove.size();
        if (addressesRemovedCount == 1) {
            System.out.printf("%d address in %s was deleted%n",
                    addressesRemovedCount, townsToRemove.get(0).getName());
        } else {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < townsToRemove.size(); i++) {
                if (i + 1 == townsToRemove.size()) {
                    output.append(townsToRemove.get(i).getName());
                } else {
                    output.append(townsToRemove.get(i).getName() + ", ");
                }
            }

            System.out.printf("%d addresses in %s were deleted%n",
                    addressesRemovedCount, output);
        }
    }
}