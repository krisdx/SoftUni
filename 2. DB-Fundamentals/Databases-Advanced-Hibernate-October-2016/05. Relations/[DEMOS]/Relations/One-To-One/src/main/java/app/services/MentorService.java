package app.services;

import app.models.Mentor;

public interface MentorService {
    void createMentor(Mentor mentor);

    Mentor find(long id);
}