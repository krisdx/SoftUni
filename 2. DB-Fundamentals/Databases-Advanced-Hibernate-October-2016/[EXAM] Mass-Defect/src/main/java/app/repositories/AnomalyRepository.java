package app.repositories;

import app.models.Anomaly;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface AnomalyRepository extends JpaRepository<Anomaly,Long> {

    @Query(value = "SELECT *" +
            " FROM anomaly_victims AS av" +
            "   JOIN anomalies AS a ON a.id = av.anomaly_id\n" +
            " GROUP BY av.anomaly_id" +
            " ORDER BY COUNT(av.person_id) DESC" +
            " LIMIT 1", nativeQuery = true)
    Anomaly getAnomalyWithMostVictims();
}