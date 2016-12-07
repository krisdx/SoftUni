package app.terminal;

import app.models.Mentor;
import app.models.Student;
import app.services.MentorService;
import app.services.StudentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

@Component
public class Terminal implements CommandLineRunner {

    @Autowired
    private StudentService studentService;

    @Autowired
    private MentorService mentorService;

    @Override
    public void run(String... strings) throws Exception {

        //// Unidirectional one to one relationship
        //List<Mentor> mentors = new ArrayList<>();
        //for (int count = 1; count <= 10; count++) {
        //    Mentor mentor = new Mentor();
        //    mentor.setName("mentor" + count);
        //    mentors.add(mentor);
        //    this.mentorService.createMentor(mentor);
        //}
        //
        //for (int i = 0; i < mentors.size(); i++) {
        //    Student student = new Student();
        //    student.setName("student" + (i + 1));
        //    student.setMentor(mentors.get(i));
        //    this.studentService.createStudent(student);


        Student student = new Student();
        student.setName("student");

        Mentor mentor = new Mentor();
        mentor.setName("mentor");
        mentor.setStudent(student);
        student.setMentor(mentor);
        this.mentorService.createMentor(mentor);
        // this.studentService.createStudent(student);

        Student resultStudent = this.studentService.find(1L);
        System.out.println(resultStudent.getMentor());
        System.out.println(resultStudent.getMentor().getName());
        Mentor resultMentor = this.mentorService.find(1L);
        System.out.println(resultMentor.getStudent().getName());
    }
}