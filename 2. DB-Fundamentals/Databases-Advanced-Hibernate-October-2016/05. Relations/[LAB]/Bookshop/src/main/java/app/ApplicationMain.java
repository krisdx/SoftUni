package app;

import app.model.Author;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import javax.persistence.criteria.CriteriaBuilder;
import java.util.*;

@SpringBootApplication
public class ApplicationMain {
    public static void main(String[] args) {
         SpringApplication.run(ApplicationMain.class, args);
    }
}