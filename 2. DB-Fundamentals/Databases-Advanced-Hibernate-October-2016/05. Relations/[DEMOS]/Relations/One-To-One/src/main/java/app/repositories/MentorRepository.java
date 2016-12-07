package app.repositories;

import org.springframework.stereotype.Repository;
import org.springframework.data.jpa.repository.JpaRepository;
import app.models.Mentor;

@Repository
public interface MentorRepository extends JpaRepository<Mentor,Long> {
}