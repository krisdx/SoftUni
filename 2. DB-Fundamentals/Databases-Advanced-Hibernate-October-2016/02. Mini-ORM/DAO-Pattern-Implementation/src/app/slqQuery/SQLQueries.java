package app.slqQuery;

public final class SQLQueries {
    public static final String SELECT_ALL_STUDENTS =
            "SELECT * FROM students";

    public static final String UPDATE_STUDENT =
            "UPDATE students " +
                    "SET name = ? " +
                    "WHERE id = ?";

    public static final String INSERT_STUDENT =
            "INSERT INTO students(id, name) " +
                    "VALUES(?, ?)";

    public static final String DELETE_STUDENT =
            "DELETE FROM students " +
                    "WHERE id = ?";
}