import java.sql.*;

public class Problem2_GetVillainsNames {

    private static final String URL = "jdbc:mysql://localhost:3306/minions_db?useSSL=false";
    private static final String USER = "root";
    private static final String PASSWORD = "root";

    public static void main(String[] args) {
        String query = "SELECT v.villain_name" +
                       "      ,COUNT(vm.minion_id) AS minions_count " +
                       "FROM villains AS v " +
                       "  JOIN villains_minions AS vm ON v.villain_id = vm.villain_id " +
                       "GROUP BY v.villain_id " +
                       "HAVING COUNT(vm.minion_id) > 3 " +
                       "ORDER BY minions_count DESC";

        try (Connection connection = DriverManager.getConnection(URL, USER, PASSWORD);
             Statement statement = connection.createStatement();
             ResultSet resultSet = statement.executeQuery(query)) {

            while (resultSet.next()) {
                String villainName = resultSet.getString("villain_name");
                int minionsCount = resultSet.getInt("minions_count");

                System.out.printf("%s %d%n", villainName, minionsCount);
            }
        } catch (SQLException sqlEx) {
            sqlEx.printStackTrace();
        }
    }
}