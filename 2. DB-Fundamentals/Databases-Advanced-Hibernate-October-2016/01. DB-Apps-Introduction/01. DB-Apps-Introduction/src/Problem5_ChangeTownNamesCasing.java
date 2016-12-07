import java.sql.*;
import java.util.Scanner;

public class Problem5_ChangeTownNamesCasing {

    private static final String URL = "jdbc:mysql://localhost:3306/minions_db?useSSL=false";
    private static final String USER = "root";
    private static final String PASSWORD = "root";

    private static final String GET_TOWNS_IN_COUNTRY_QUERY = "SELECT town_name " +
            "FROM towns " +
            "WHERE country_name = ?";

    private static final String UPDATE_TOWNS_IN_COUNTRY_QUERY = "UPDATE towns " +
            "SET town_name = UPPER(town_name) " +
            "WHERE country_name = ?";

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String countryName = scanner.nextLine();

        Connection connection = null;
        PreparedStatement updateTownsInCountryStatement = null;
        PreparedStatement getTownsInCountryStatement = null;
        try {
            connection = DriverManager.getConnection(URL, USER, PASSWORD);

            getTownsInCountryStatement =
                    connection.prepareStatement(GET_TOWNS_IN_COUNTRY_QUERY);
            getTownsInCountryStatement.setString(1, countryName);
            ResultSet townsInCountryResultSet =
                    getTownsInCountryStatement.executeQuery();
            if (getResultSetCount(townsInCountryResultSet) == 0) {
                System.out.println("No town names were affected.");
                return;
            }

            updateTownsInCountryStatement =
                    connection.prepareStatement(UPDATE_TOWNS_IN_COUNTRY_QUERY);
            updateTownsInCountryStatement.setString(1, countryName);
            int affectedRows = updateTownsInCountryStatement.executeUpdate();
            System.out.printf("%d town names were affected.%n", affectedRows);

            townsInCountryResultSet = getTownsInCountryStatement.executeQuery();
            System.out.print('[');
            while (townsInCountryResultSet.next()) {
                if (townsInCountryResultSet.isLast()) {
                    System.out.print(townsInCountryResultSet.getString("town_name"));
                } else {
                    System.out.print(townsInCountryResultSet.getString("town_name") + ", ");
                }
            }
            System.out.print(']');
        } catch (SQLException sqlEx) {
            System.err.println(sqlEx.getMessage());
        } finally {
            if (updateTownsInCountryStatement != null) {
                try {
                    updateTownsInCountryStatement.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }

            if (getTownsInCountryStatement != null) {
                try {
                    getTownsInCountryStatement.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }

            if (connection != null) {
                try {
                    connection.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }

            }
        }
    }

    private static int getResultSetCount(ResultSet resultSet) throws SQLException {
        int count = 0;
        if (resultSet != null) {
            resultSet.last();
            count = resultSet.getRow();
            resultSet.beforeFirst();
        }

        return count;
    }
}