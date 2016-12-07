import java.sql.*;
import java.util.Scanner;

public class Problem6_RemoveVillain {

    private static final String URL = "jdbc:mysql://localhost:3306/minions_db?useSSL=false";
    private static final String USER = "root";
    private static final String PASSWORD = "root";

    private static final String GET_VILLAIN_BY_ID_QUERY = "SELECT villain_name " +
            "FROM villains " +
            "WHERE villain_id = ?";

    private static final String DELETE_VILLAIN_BY_ID_QUERY = "DELETE " +
            "FROM villains " +
            "WHERE villain_id = ?";

    private static final String DELETE_VILLAIN_RELATIONSHIPS_QUERY = "DELETE " +
            "FROM villains_minions " +
            "WHERE villain_id = ?";

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int villainId = Integer.valueOf(scanner.nextLine());

        Connection connection = null;
        PreparedStatement deleteVillainRelationshipStatement = null;
        PreparedStatement getVillainByIdStatement = null;
        ResultSet villainResultSet = null;
        try {
            connection = DriverManager.getConnection(URL, USER, PASSWORD);
            connection.setAutoCommit(false);

            getVillainByIdStatement =
                    connection.prepareStatement(GET_VILLAIN_BY_ID_QUERY);
            getVillainByIdStatement.setInt(1, villainId);
            villainResultSet = getVillainByIdStatement.executeQuery();
            if (getResultSetCount(villainResultSet) == 0) {
                System.out.println("No such villain was found.");
                connection.rollback();
                return;
            }

            villainResultSet.next();
            String villainName = villainResultSet.getString("villain_name");

            deleteVillainRelationshipStatement =
                    connection.prepareStatement(DELETE_VILLAIN_RELATIONSHIPS_QUERY);
            deleteVillainRelationshipStatement.setInt(1, villainId);
            int minionsReleasedCount =
                    deleteVillainRelationshipStatement.executeUpdate();

            getVillainByIdStatement =
                    connection.prepareStatement(DELETE_VILLAIN_BY_ID_QUERY);
            getVillainByIdStatement.setInt(1, villainId);
            getVillainByIdStatement.execute();

            connection.commit();

            System.out.printf("%s was deleted%n", villainName);
            System.out.printf("%d minions released%n", minionsReleasedCount);
        } catch (SQLException sqlEx) {
            System.err.println(sqlEx.getMessage());
        } finally {
            if (villainResultSet != null){
                try {
                    villainResultSet.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }

            if (deleteVillainRelationshipStatement != null){
                try {
                    deleteVillainRelationshipStatement.close();
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }

            if (getVillainByIdStatement != null){
                try {
                    getVillainByIdStatement.close();
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