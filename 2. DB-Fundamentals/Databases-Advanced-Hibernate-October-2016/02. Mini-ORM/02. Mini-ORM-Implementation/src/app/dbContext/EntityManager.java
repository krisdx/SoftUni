package app.dbContext;

import app.persistence.Column;
import app.persistence.Id;
import app.queryBuilders.CreateTableBuilder;
import app.queryBuilders.InsertEntityBuilder;
import app.queryBuilders.SelectBuilder;
import app.queryBuilders.UpdateEntityBuilder;

import java.lang.reflect.Field;
import java.sql.*;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.List;

public class EntityManager implements DbContext {

    private Connection connection;

    public EntityManager(Connection connection) {
        this.connection = connection;
    }

    @Override
    public <E> boolean persist(E entity) throws IllegalAccessException, SQLException, NoSuchFieldException {

        Field primary = this.getId(entity.getClass());
        primary.setAccessible(true);
        Long value = (Long) primary.get(entity);

        // Creates the table if it doesn't exists.
        this.createTable(entity, primary);

        if (value == null || value <= 0) {
            // If the object is not present, we insert it.
            return this.doInsert(entity, primary);
        }

        // If the object is present, we update it.
        if (!this.doUpdate(entity, primary)) {
            return this.doInsert(entity, primary);
        }

        return true;
    }

    @Override
    public <E> Iterable<E> find(Class<E> table) throws SQLException, IllegalAccessException, InstantiationException {
        return find(table, null);
    }

    @Override
    public <E> Iterable<E> find(Class<E> table, String where)
            throws SQLException, InstantiationException, IllegalAccessException {

        String selectQuery = SelectBuilder.buildSelectQuery(table, where);
        Statement statement = connection.createStatement();
        ResultSet resultSet = statement.executeQuery(selectQuery);

        List<E> entities = this.fillEntity(table, resultSet);

        resultSet.close();
        statement.close();
        return entities;
    }

    @Override
    public <E> E findFirst(Class<E> table)
            throws SQLException, IllegalAccessException, InstantiationException {
        return this.findFirst(table, null);
    }

    @Override
    public <E> E findFirst(Class<E> table, String where)
            throws SQLException, InstantiationException, IllegalAccessException {

        String selectQuery = SelectBuilder.buildSelectFirstQuery(table, where);
        Statement statement = connection.createStatement();
        ResultSet resultSet = statement.executeQuery(selectQuery);

        List<E> entities = this.fillEntity(table, resultSet);

        resultSet.close();
        statement.close();
        return entities.get(0);
    }

    @Override
    public void close() throws Exception {
        if (this.connection != null) {
            this.connection.close();
        }
    }

    private Field getId(Class c) throws IllegalAccessException {
        Field[] fields = c.getDeclaredFields();
        for (Field field : fields) {
            field.setAccessible(true);
            if (field.isAnnotationPresent(Id.class)) {
                return field;
            }
        }

        throw new IllegalAccessException(
                "No primary key found in entity " + c.getSimpleName());
    }

    private <E> List<E> fillEntity(Class<E> table, ResultSet resultSet)
            throws SQLException, IllegalAccessException, InstantiationException {

        List<E> entities = new ArrayList<>();
        while (resultSet.next()) {
            E entity = table.newInstance();
            Field[] fields = entity.getClass().getDeclaredFields();
            for (Field field : fields) {
                field.setAccessible(true);
                String fieldName = this.getFieldName(field);
                Object value = resultSet.getObject(fieldName);
                field.set(entity, value);
            }

            entities.add(entity);
        }

        return Collections.unmodifiableList(entities);
    }

    private <E> boolean createTable(E entity, Field primary) throws SQLException {
        String createTableQuery =
                CreateTableBuilder.buildCreateTableQuery(entity.getClass(), primary, entity.getClass().getDeclaredFields());
        Statement statement = this.connection.createStatement();
        boolean hasExecuted = statement.execute(createTableQuery);

        statement.close();
        return hasExecuted;
    }

    private <E> boolean doInsert(E entity, Field primary) throws SQLException, IllegalAccessException, NoSuchFieldException {
        String insertQuery =
                InsertEntityBuilder.buildInsertEntityQuery(entity.getClass(), entity.getClass().getDeclaredFields());
        PreparedStatement insertStatement =
                this.connection.prepareStatement(insertQuery);

        this.setArguments(entity, insertStatement);

        boolean hasExecuted = insertStatement.execute();
        insertStatement.close();
        return hasExecuted;
    }

    private <E> boolean doUpdate(E entity, Field primary) throws SQLException, IllegalAccessException {
        String updateQuery =
                UpdateEntityBuilder.buildCreateTableQuery(entity.getClass(), entity.getClass().getDeclaredFields());
        PreparedStatement updateStatement =
                this.connection.prepareStatement(updateQuery);

        int lastArgumentPosition = this.setArguments(entity, updateStatement);

        Field primaryKey = this.getId(entity.getClass());
        int id = (int) primaryKey.get(entity);
        updateStatement.setInt(lastArgumentPosition, id);

        int affectedRows = updateStatement.executeUpdate();
        updateStatement.close();
        return affectedRows > 0;
    }

    private <E> int setArguments(E entity, PreparedStatement preparedStatement) throws IllegalAccessException, SQLException {
        int argumentPosition = 1;
        Field[] fields = entity.getClass().getDeclaredFields();
        for (Field field : fields) {
            field.setAccessible(true);
            if (field.isAnnotationPresent(Id.class)) {
                continue;
            }

            Object fieldValue = field.get(entity);
            if (fieldValue instanceof Date) {
                fieldValue =
                        new SimpleDateFormat("yyyy/MM/dd").format(fieldValue);
            } else if (fieldValue instanceof Boolean) {
                fieldValue = ((boolean) fieldValue) ? 1 : 0;
            }

            preparedStatement.setString(argumentPosition, fieldValue.toString());
            argumentPosition++;
        }

        return argumentPosition;
    }

    private String getFieldName(Field field) {
        field.setAccessible(true);
        if (field.isAnnotationPresent(Column.class)) {// TODO: field.getClass ?
            Column columnAnnotation = field.getAnnotation(Column.class);
            return columnAnnotation.name();
        }

        return field.getName();
    }
}