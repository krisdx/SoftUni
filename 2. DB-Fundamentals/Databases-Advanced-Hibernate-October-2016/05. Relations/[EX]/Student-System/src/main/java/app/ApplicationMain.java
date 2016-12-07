package app;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import java.math.BigDecimal;

@SpringBootApplication
public class ApplicationMain {
    public static void main(String[] args) {
        BigDecimal a = new BigDecimal("1");
        BigDecimal b = new BigDecimal("3");

        BigDecimal result = a.divide(b, 3);
        System.out.println(result.toString());
        //SpringApplication.run(ApplicationMain.class, args);
    }
}