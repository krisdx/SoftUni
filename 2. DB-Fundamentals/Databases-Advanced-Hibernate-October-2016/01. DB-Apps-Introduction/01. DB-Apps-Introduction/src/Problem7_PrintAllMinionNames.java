import java.sql.*;

public class Problem7_PrintAllMinionNames {

    private static final String URL = "jdbc:mysql://localhost:3306/minions_db?useSSL=false";
    private static final String USER = "root";
    private static final String PASSWORD = "root";

    private static final String GET_ALL_MINIONS_QUERY = "SELECT minion_id " +
            "FROM minions";

    private static final String GET_MINION_BY_ID_QUERY = "SELECT minion_name " +
            "FROM minions " +
            "WHERE minion_id = ?";

    public static void main(String[] args) {
        Connection connection = null;
        Statement getAllMinionsStatement = null;
        ResultSet allMinions = null;

        try {
            connection = DriverManager.getConnection(URL, USER, PASSWORD);

            getAllMinionsStatement = connection.createStatement();
            allMinions = getAllMinionsStatement.executeQuery(GET_ALL_MINIONS_QUERY);
            int minionsCount = getResultSetCount(allMinions);

            int left = 1;
            int right = minionsCount;
            while (left <= right) {
                String minionFromLeftSideName = getMinionName(connection, left);
                System.out.println(minionFromLeftSideName);

                if (left != right) {
                    String minionFromRightSideName = getMinionName(connection, right);
                    System.out.println(minionFromRightSideName);
                }

                left++;
                right--;
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

    private static String getMinionName(Connection connection, int position) throws SQLException {
        PreparedStatement getMinionByIdStatement = connection.prepareStatement(GET_MINION_BY_ID_QUERY);
        getMinionByIdStatement.setInt(1, position);

        ResultSet currentMinion = getMinionByIdStatement.executeQuery();

        currentMinion.next();
        String minionName = currentMinion.getString("minion_name");

        currentMinion.close();
        getMinionByIdStatement.close();
        return minionName;
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