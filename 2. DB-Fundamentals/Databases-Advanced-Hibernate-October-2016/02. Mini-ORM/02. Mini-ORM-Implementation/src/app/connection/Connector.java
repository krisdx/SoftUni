package app.connection;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Properties;

public class Connector {

    private static Connection connection = null;

    public static void initConnection(String driver, String username, String password,
                                      String host, String port, String dbName) throws SQLException {
        Properties connectionProperties = new Properties();
        connectionProperties.setProperty("user", username);
        connectionProperties.setProperty("password", password);

        String url = String.format("jdbc:%s://%s:%s/%s?useSSL=false", driver, host, port, dbName);
        // System.out.println(url);
        connection = DriverManager.getConnection(url, connectionProperties);
    }

    public static Connection getConnection() {
        return connection;
    }
}