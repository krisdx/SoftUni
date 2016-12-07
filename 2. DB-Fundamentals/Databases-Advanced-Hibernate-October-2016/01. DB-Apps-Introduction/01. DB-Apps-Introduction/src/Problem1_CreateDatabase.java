import java.sql.*;

public class Problem1_CreateDatabase {

    private static final String URL = "jdbc:mysql://localhost:3306/?useSSL=false";
    private static final String USER = "root";
    private static final String PASSWORD = "root";

    public static void main(String[] args) {
        try (Connection connection = DriverManager.getConnection(URL, USER, PASSWORD);
             Statement statement = connection.createStatement()) {

            // Create statements
            statement.execute("DROP DATABASE IF EXISTS minions_db");
            statement.execute("CREATE DATABASE minions_db");

            statement.execute("USE minions_db");

            statement.execute("DROP TABLE IF EXISTS towns");
            statement.execute("CREATE TABLE towns(" +
                              "town_id INT NOT NULL AUTO_INCREMENT," +
                              "town_name VARCHAR(50) NOT NULL," +
                              "country_name VARCHAR(50)," +
                              "PRIMARY KEY(town_id))");

            statement.execute("DROP TABLE IF EXISTS minions");
            statement.execute("CREATE TABLE minions(" +
                              "minion_id INT NOT NULL AUTO_INCREMENT," +
                              "minion_name VARCHAR(50) NOT NULL," +
                              "minion_age INT NOT NULL," +
                              "town_id INT NOT NULL," +
                              "PRIMARY KEY(minion_id)," +
                              "FOREIGN KEY (town_id) REFERENCES towns(town_id))");

            statement.execute("DROP TABLE IF EXISTS villains");
            statement.execute("CREATE TABLE villains(" +
                              "villain_id INT NOT NULL AUTO_INCREMENT," +
                              "villain_name VARCHAR(50) NOT NULL," +
                              "evilness_factor ENUM('good', 'bad', 'evil', 'super evil') NOT NULL," +
                              "PRIMARY KEY(villain_id))");

            statement.execute("DROP TABLE IF EXISTS villains_minions");
            statement.execute("CREATE TABLE villains_minions(" +
                              "villain_id INT NOT NULL," +
                              "minion_id INT NOT NULL," +
                              "PRIMARY KEY(villain_id, minion_id)," +
                              "FOREIGN KEY (villain_id) REFERENCES villains(villain_id)," +
                              "FOREIGN KEY (minion_id) REFERENCES minions(minion_id))");

            // Insert statements
            statement.execute("INSERT INTO towns (town_name, country_name)" +
                              "VALUES ('Sofia', 'Bulgaria')," +
                              "  ('Burgas', 'Bulgaria')," +
                              "  ('Varna', 'Bulgaria')," +
                              "  ('Plovdiv', 'Bulgaria')," +
                              "  ('Shumen', 'Bulgaria')");

            statement.execute("INSERT INTO minions (minion_name, minion_age, town_id)" +
                              "VALUES ('minion1', 3, 1)," +
                              "  ('minion2', 4,2)," +
                              "  ('minion3', 15, 3)," +
                              "  ('minion4', 16, 4)," +
                              "  ('minion5', 31, 5)");

            statement.execute("INSERT INTO villains (villain_name, evilness_factor)" +
                              "VALUES ('villain1', 'good')," +
                              "  ('villain2', 'bad')," +
                              "  ('villain3', 'evil')," +
                              "  ('villain4', 'super evil')," +
                              "  ('villain5', 'super evil')");

            statement.execute("INSERT INTO villains_minions (villain_id, minion_id)" +
                              "VALUES (1, 1)," +
                              "(2, 1)," +
                              "(2, 2)," +
                              "(3, 1)," +
                              "(3, 2)," +
                              "(3, 3)," +
                              "(4, 1)," +
                              "(4, 2)," +
                              "(4, 3)," +
                              "(4, 4)," +
                              "(5, 1)," +
                              "(5, 2)," +
                              "(5, 3)," +
                              "(5, 4)," +
                              "(5, 5);");
        } catch (SQLException sqlEx) {
            sqlEx.printStackTrace();
        }
    }
}