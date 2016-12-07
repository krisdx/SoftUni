import java.sql.*;
import java.util.Scanner;

public class Problem3_GetMinionNames {

    private static final String URL = "jdbc:mysql://localhost:3306/minions_db?useSSL=false";
    private static final String USER = "root";
    private static final String PASSWORD = "root";

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int targetVillainId = scanner.nextInt();

        String getVillainQuery = "SELECT v.villain_name " +
                                 "FROM villains AS v " +
                   String.format("WHERE v.villain_id = %d", targetVillainId);

        String getMinionsQuery = "SELECT m.minion_name, m.minion_age " +
                                 "FROM minions AS m" +
                                 "  JOIN villains_minions AS vm ON m.minion_id = vm.minion_id " +
                   String.format("WHERE vm.villain_id = %d", targetVillainId);

        try (Connection connection = DriverManager.getConnection(URL, USER, PASSWORD);
             Statement statement = connection.createStatement()) {

            ResultSet villain = statement.executeQuery(getVillainQuery);
            if (villain.getFetchSize() == 0){
                System.err.printf("No villain with ID %d exists in the database.", targetVillainId);
                return;
            }

            while (villain.next()) {
                String villainName = villain.getString("villain_name");
                System.out.println("Villain: " + villainName);
            }

            ResultSet minions = statement.executeQuery(getMinionsQuery);
            int count = 1;
            while (minions.next()) {
                String minionName = minions.getString("minion_name");
                int minionAge = minions.getInt("minion_age");

                System.out.printf("%d. %s %d%n", count, minionName, minionAge);
                count++;
            }
        } catch (SQLException sqlEx) {
            sqlEx.printStackTrace();
        }
    }
}