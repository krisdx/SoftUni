package app;

import app.connection.Connector;
import app.dbContext.DbContext;
import app.dbContext.EntityManager;
import app.entities.Book;
import app.entities.User;

import java.sql.Connection;
import java.sql.SQLException;
import java.util.Date;
import java.util.Iterator;

public class Main {

    public static void main(String[] args) {

        Connection connection = null;
        try {
            Connector.initConnection("mysql", "root", "root", "localhost", "3306", "users");
            connection = Connector.getConnection();
        } catch (SQLException sqlEx) {
            sqlEx.printStackTrace();
        }

        try (DbContext entityManager = new EntityManager(connection)) {
            //// Insert users
            //for (int i = 1; i <= 10; i++) {
            //    User user = new User("User" + i, i + 10, new Date());
            //    entityManager.persist(user);
            //}
            //
            //Iterable<User> users = entityManager.find(User.class, "WHERE YEAR(registration_date) > 2010 AND age >= 18");
            //for (User user : users) {
            //    System.out.print("Id: " + user.getId());
            //    System.out.print(" Age: " + user.getAge());
            //    System.out.print(" Password: " + user.getPassword());
            //    System.out.println(" Registration date: " + user.getRegistrationDate());
            //}

            // Insert users
            for (int i = 1; i <= 10; i++) {
                Book book = new Book("title" + i, "author" + i, new Date(), "english", i % 2 == 0);
                entityManager.persist(book);
            }
        } catch (IllegalAccessException e) {
            e.printStackTrace();
        } catch (SQLException e) {
            e.printStackTrace();
        } catch (NoSuchFieldException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}