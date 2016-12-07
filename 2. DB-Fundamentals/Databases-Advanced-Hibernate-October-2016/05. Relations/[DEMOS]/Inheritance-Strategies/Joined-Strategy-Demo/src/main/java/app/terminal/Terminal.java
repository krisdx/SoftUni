package app.terminal;

import app.models.FullTimeEmployee;
import app.models.HalfTimeEmployee;
import app.service.EmployeeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

@Component
public class Terminal implements CommandLineRunner {

    @Autowired
    private EmployeeService employeeService;

    @Override
    public void run(String... strings) throws Exception {

        for (int count = 1; count <= 10; count++) {
            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee();
            fullTimeEmployee.setName("Full Time Employee"+count);
            fullTimeEmployee.setWorkHours(count);
            this.employeeService.createEmployee(fullTimeEmployee);
        }

        for (int count = 1; count <= 10; count++) {
            HalfTimeEmployee halfTimeEmployee = new HalfTimeEmployee();
            halfTimeEmployee.setName("Half Time Employee" + count);
            halfTimeEmployee.seIstStudent(count % 2 == 0);
            this.employeeService.createEmployee(halfTimeEmployee);
        }
    }
}