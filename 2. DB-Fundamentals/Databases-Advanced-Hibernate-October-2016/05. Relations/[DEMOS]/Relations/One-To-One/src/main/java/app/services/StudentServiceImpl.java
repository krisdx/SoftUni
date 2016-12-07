package app.services;

import app.models.Student;
import app.repositories.StudentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import app.services.StudentService;

@Service
@Transactional
public class StudentServiceImpl implements StudentService {

    @Autowired
    private StudentRepository studentrepository;


    @Override
    public void createStudent(Student student) {
        this.studentrepository.save(student);
    }

    @Override
    public Student find(long id) {
        return this.studentrepository.findOne(id);
    }
}