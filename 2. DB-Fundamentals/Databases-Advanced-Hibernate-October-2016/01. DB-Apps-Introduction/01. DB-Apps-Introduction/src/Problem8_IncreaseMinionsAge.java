import java.sql.*;
import java.util.Scanner;

public class Problem8_IncreaseMinionsAge {

    private static final String URL = "jdbc:mysql://localhost:3306/minions_db?useSSL=false";
    private static final String USER = "root";
    private static final String PASSWORD = "root";

    private static final String GET_ALL_MINIONS_QUERY = "SELECT minion_name, minion_age " +
            "FROM minions";

    private static final String UPDATE_MINION_NAMES_QUERY = "UPDATE minions " +
            "SET minion_name =  CONCAT(UPPER(LEFT(minion_name, 1)), SUBSTRING(minion_name, 2)) " +
            "WHERE minion_id = ?";

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] inputArgs = scanner.nextLine().split("\\s+");
        int[] ids = new int[inputArgs.length];
        for (int i = 0; i < inputArgs.length; i++) {
            ids[i] = Integer.valueOf(inputArgs[i]);
        }

        Connection connection = null;
        PreparedStatement updateMinionNamesStatement = null;
        Statement getAllMinionsStatement = null;
        ResultSet allMinions = null;

        try {
            connection = DriverManager.getConnection(URL, USER, PASSWORD);
                updateMinionNamesStatement =
                        connection.prepareStatement(UPDATE_MINION_NAMES_QUERY);

            for (int i = 0; i < ids.length; i++) {
                updateMinionNamesStatement.setInt(1, ids[i]);
                updateMinionNamesStatement.executeUpdate();
            }

            getAllMinionsStatement = connection.createStatement();
            allMinions = getAllMinionsStatement.executeQuery(GET_ALL_MINIONS_QUERY);
            while (allMinions.next()){
                String minionName = allMinions.getString("minion_name");
                int minionAge = allMinions.getInt("minion_age");
                System.out.println(minionName + " " + minionAge);
            }
        } catch (SQLException sqlEx) {
            System.err.println(sqlEx.getMessage());
        } finally {
            if (allMinions != null) {
                try {
                    allMinions.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }

            if (updateMinionNamesStatement != null) {
                try {
                    updateMinionNamesStatement.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }

            if (getAllMinionsStatement != null) {
                try {
                    getAllMinionsStatement.close();
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
}