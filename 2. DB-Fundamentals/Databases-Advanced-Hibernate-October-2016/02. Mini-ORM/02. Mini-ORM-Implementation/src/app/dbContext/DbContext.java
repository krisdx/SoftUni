package app.dbContext;

import java.sql.SQLException;

public interface DbContext extends AutoCloseable {

    <E> boolean persist(E entity) throws IllegalAccessException, SQLException, NoSuchFieldException;

    <E> Iterable<E> find(Class<E> table) throws SQLException, IllegalAccessException, InstantiationException;

    <E> Iterable<E> find(Class<E> table, String where) throws SQLException, InstantiationException, IllegalAccessException;

    <E> E findFirst(Class<E> table) throws SQLException, IllegalAccessException, InstantiationException;

    <E> E findFirst(Class<E> table, String where) throws SQLException, InstantiationException, IllegalAccessException;
}