package app.terminal;

import app.models.Employee;
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
        FullTimeEmployee fullTimeEmployee = new FullTimeEmployee();
        fullTimeEmployee.setName("Full Time Employee");
        fullTimeEmployee.setWorkHours(1);

        HalfTimeEmployee halfTimeEmployee = new HalfTimeEmployee();
        halfTimeEmployee.setName("Half Time Employee");
        halfTimeEmployee.seIstStudent(true);

        this.employeeService.createEmployee(fullTimeEmployee);
        this.employeeService.createEmployee(halfTimeEmployee);
    }
}
