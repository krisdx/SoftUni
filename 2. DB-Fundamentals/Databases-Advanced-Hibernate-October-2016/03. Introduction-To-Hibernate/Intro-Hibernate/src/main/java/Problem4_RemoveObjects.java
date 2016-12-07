import entities.Town;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import java.util.List;

public class Problem4_RemoveObjects {
    public static void main(String[] args) {

        EntityManagerFactory emf =
                Persistence.createEntityManagerFactory("soft_uni");
        EntityManager em = emf.createEntityManager();

        em.getTransaction().begin();

        Query allTownsQuery = em.createQuery("SELECT t FROM Town AS t" +
                " WHERE CHAR_LENGTH(t.name) > 5");
        List<Town> allTowns = allTownsQuery.getResultList();
        for (Town town : allTowns) {
            em.persist(town);
        }

        Query townsWithLengthQuery = em.createQuery("SELECT t FROM Town AS t" +
                " WHERE CHAR_LENGTH(t.name) > 5");
        List<Town> townsWithLength = townsWithLengthQuery.getResultList();
        for (Town town : townsWithLength) {
            em.detach(town);
            town.setName(town.getName().toLowerCase());
            em.merge(town);
        }

        em.getTransaction().commit();
        em.close();
        emf.close();
    }
}