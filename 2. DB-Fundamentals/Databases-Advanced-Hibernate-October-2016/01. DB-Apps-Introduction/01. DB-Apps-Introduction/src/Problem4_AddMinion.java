import java.sql.*;
import java.util.Scanner;

public class Problem4_AddMinion {

    private static final String URL = "jdbc:mysql://localhost:3306/minions_db?useSSL=false";
    private static final String USER = "root";
    private static final String PASSWORD = "root";

    private static final String GET_TOWN_QUERY = "SELECT town_id " +
            "FROM towns " +
            "WHERE town_name = ? " +
            "LIMIT 1";

    private static final String INSERT_TOWN_QUERY = "INSERT INTO towns(town_name) " +
            "VALUES(?)";

    private static final String INSERT_MINION_QUERY = "INSERT INTO minions(minion_name, minion_age, town_id) " +
            "VALUES(?, ?, ?)";

    private static final String GET_INSERTED_MINION_ID_QUERY = "SELECT minion_id " +
            "FROM minions " +
            "ORDER BY minion_id DESC " +
            "LIMIT 1";

    private static final String GET_VILLAIN_ID_QUERY = "SELECT villain_id " +
            "FROM villains " +
            "WHERE villain_name = ? " +
            "LIMIT 1";

    private static final String INSERT_VILLAIN_QUERY = "INSERT INTO villains (villain_name, evilness_factor) " +
            "VALUES (?, ?)";

    private static final String ADD_MINION_TO_VILLAIN_QUERY = "INSERT INTO villains_minions(villain_id, minion_id) " +
            "VALUES (?, ?)";

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] minionArgs = scanner.nextLine().split(": ")[1].split(" ");
        String minionName = minionArgs[0];
        int minionAge = Integer.valueOf(minionArgs[1]);
        String townName = minionArgs[2];
        String villainName = scanner.nextLine().split(": ")[1];

        Connection connection = null;
        Statement statement = null;
        try {
            connection = DriverManager.getConnection(URL, USER, PASSWORD);

            // This method inserts the the town if it not exists.
            int targetTownId = getTownId(townName, connection);

            boolean isMinionInserted = insertMinion(minionName, minionAge, connection, targetTownId);
            if (!isMinionInserted) {
                throw new SQLException(
                        String.format("Cannot insert minion %s to the database.", minionName));
            }

            statement = connection.createStatement();

            ResultSet insertedMinionResultSet = statement.executeQuery(GET_INSERTED_MINION_ID_QUERY);
            insertedMinionResultSet.getInt("minion_id");
            insertedMinionResultSet.next();

            int insertedMinionId = insertedMinionResultSet.getInt("minion_id");
            int villainId = getVillainId(villainName, connection);

            addMinionToVillain(minionName, villainName, connection, insertedMinionId, villainId);
        } catch (SQLException sqlEx) {
            System.err.println(sqlEx.getMessage());
            sqlEx.printStackTrace();
        } finally {
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
                } catch (SQLException sqlEx) {
                    sqlEx.printStackTrace();
                }
            }
        }
    }

    private static void addMinionToVillain(String minionName, String villainName, Connection connection, int insertedMinionId, int villainId) throws SQLException {
        PreparedStatement addMinionToVillainStatement =
                connection.prepareStatement(ADD_MINION_TO_VILLAIN_QUERY);
        addMinionToVillainStatement.setInt(1, villainId);
        addMinionToVillainStatement.setInt(2, insertedMinionId);

        int affectedRows = addMinionToVillainStatement.executeUpdate();
        if (affectedRows != 1) {
            throw new SQLException(
                    String.format("Cannot add minion %s to be servant of villain %s.", minionName, villainName));
        }

        System.out.printf("Successfully added %s to be minion of %s.", minionName, villainName);
    }

    private static int getVillainId(String villainName, Connection connection) throws SQLException {
        PreparedStatement getVillainIdStatement = connection.prepareStatement(GET_VILLAIN_ID_QUERY);
        getVillainIdStatement.setString(1, villainName);

        ResultSet villainIdResultSet = getVillainIdStatement.executeQuery();
        if (getResultSetCount(villainIdResultSet) == 0) {
            boolean isVillainInserted = insertVillain(villainName, connection);
            if (!isVillainInserted) {
                throw new SQLException(
                        String.format("Cannot insert villain %s to the database.", villainName));
            }

            villainIdResultSet = getVillainIdStatement.executeQuery();
            villainIdResultSet.next();
            return villainIdResultSet.getInt("villain_id");
        }

        villainIdResultSet.next();
        return villainIdResultSet.getInt("villain_id");
    }

    private static boolean insertVillain(String villainName, Connection connection) throws SQLException {
        PreparedStatement insertTownStatement =
                connection.prepareStatement(INSERT_VILLAIN_QUERY);
        insertTownStatement.setString(1, villainName);
        insertTownStatement.setString(2, "evil");

        int affectedRows = insertTownStatement.executeUpdate();
        if (affectedRows == 1) {
            System.out.printf("Villain %s was added to the database.%n", villainName);
            return true;
        }

        System.err.printf("Cannot add villain %s to the database.%n", villainName);
        return false;
    }

    private static boolean insertMinion(String minionName, int minionAge, Connection connection, int targetTownId) throws SQLException {
        PreparedStatement insertMinionStatement =
                connection.prepareStatement(INSERT_MINION_QUERY);
        insertMinionStatement.setString(1, minionName);
        insertMinionStatement.setInt(2, minionAge);
        insertMinionStatement.setInt(3, targetTownId);

        int affectedRows = insertMinionStatement.executeUpdate();
        if (affectedRows != 1) {
            System.err.println("Cannot add minion ot the database.");
            return false;
        }

        System.out.printf("Successfully added minion %s to the database.%n", minionName);
        return true;
    }

    private static int getTownId(String townName, Connection connection) throws SQLException {
        PreparedStatement getTownStatement = connection.prepareStatement(GET_TOWN_QUERY);
        getTownStatement.setString(1, townName);

        ResultSet townResultSet = getTownStatement.executeQuery();
        if (getResultSetCount(townResultSet) == 0) {
            boolean isTownInserted = insertTown(townName, connection);
            if (!isTownInserted) {
                throw new SQLException(
                        String.format("Cannot insert town %s to the database.", townName));
            }

            townResultSet = getTownStatement.executeQuery();
            townResultSet.next();
            return townResultSet.getInt("town_id");
        }

        townResultSet.next();
        return townResultSet.getInt("town_id");
    }

    private static boolean insertTown(String townName, Connection connection) throws SQLException {
        PreparedStatement insertTownStatement =
                connection.prepareStatement(INSERT_TOWN_QUERY);
        insertTownStatement.setString(1, townName);

        int affectedRows = insertTownStatement.executeUpdate();
        if (affectedRows == 1) {
            System.out.printf("Town %s was added to the database.%n", townName);
            return true;
        }

        System.err.printf("Cannot add town %s to the database.%n", townName);
        return false;
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