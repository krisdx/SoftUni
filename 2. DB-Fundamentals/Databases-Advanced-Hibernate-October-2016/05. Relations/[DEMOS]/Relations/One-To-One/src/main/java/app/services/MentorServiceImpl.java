package app.services;

import app.models.Mentor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import app.repositories.MentorRepository;

@Service
@Transactional
public class MentorServiceImpl implements MentorService {

    @Autowired
    private MentorRepository mentorrepository;

    @Override
    public void createMentor(Mentor mentor) {
        this.mentorrepository.saveAndFlush(mentor);
    }

    @Override
    public Mentor find(long id) {
        return this.mentorrepository.findOne(id);
    }
}