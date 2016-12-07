import java.sql.*;
import java.util.Scanner;

public class Problem9_IncreaseAgeStoredProcedure {

    private static final String URL = "jdbc:mysql://localhost:3306/minions_db?useSSL=false";
    private static final String USER = "root";
    private static final String PASSWORD = "root";

    private static final String GET_ALL_MINIONS_QUERY = "SELECT minion_name, minion_age " +
            "FROM minions " +
            "WHERE minion_id = ?";

    private static final String INCREASE_AGE_PROCEDURE_QUERY = "CREATE PROCEDURE usp_get_older(target_minion_id INT)" +
            "BEGIN " +
            "   UPDATE minions " +
            "   SET minion_age = minion_age + 1 " +
            "   WHERE minion_id = target_minion_id; " +
            "END";

    private static final String CALL_INCREASE_AGE_PROCEDURE_QUERY = "CALL usp_get_older(?)";

    public static void main(String[] args) {
        Connection connection = null;
        CallableStatement callIncreaseAgeProcedureStatement = null;
        PreparedStatement getMinionByIdStatement = null;
        Statement statement = null;
        ResultSet minionResultSet = null;

        int targetMinionId = 1;
        try {
            connection = DriverManager.getConnection(URL, USER, PASSWORD);
            statement = connection.createStatement();

            statement.execute("DROP PROCEDURE IF EXISTS usp_get_older");
            statement.execute(INCREASE_AGE_PROCEDURE_QUERY);

            callIncreaseAgeProcedureStatement =
                    connection.prepareCall(CALL_INCREASE_AGE_PROCEDURE_QUERY);
            callIncreaseAgeProcedureStatement.setInt(1, targetMinionId);
            callIncreaseAgeProcedureStatement.executeUpdate();

            getMinionByIdStatement = connection.prepareStatement(GET_ALL_MINIONS_QUERY);
            getMinionByIdStatement.setInt(1, targetMinionId);
            minionResultSet = getMinionByIdStatement.executeQuery();

            while (minionResultSet.next()) {
                String minionName = minionResultSet.getString("minion_name");
                int minionAge = minionResultSet.getInt("minion_age");
                System.out.println(minionName + " " + minionAge);
            }
        } catch (SQLException sqlEx) {
            System.err.println(sqlEx.getMessage());
            sqlEx.printStackTrace();
        } finally {
            if (minionResultSet != null) {
                try {
                    minionResultSet.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }

            if (callIncreaseAgeProcedureStatement != null) {
                try {
                    callIncreaseAgeProcedureStatement.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }

            if (getMinionByIdStatement != null) {
                try {
                    getMinionByIdStatement.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }

            if (statement != null) {
                try {
                    statement.close();
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