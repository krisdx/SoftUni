package app.queryBuilders;

import app.persistence.Entity;

public class SelectBuilder {

    public static String buildSelectFirstQuery(Class table, String where) {
        String query = "SELECT * FROM " + getTableName(table) +
                (where == null ? "" : " " + where) +
                " LIMIT 1";
        return query;
    }

    public static String buildSelectQuery(Class table, String where) {
        String query = "SELECT * FROM " + getTableName(table) +
                (where == null ? "" : " " + where);
        return query;
    }

    private static <E> String getTableName(Class<E> entity) {
        if (entity.isAnnotationPresent(Entity.class)) {
            Entity entityAnnotation = entity.getAnnotation(Entity.class);
            return entityAnnotation.name();
        }

        return entity.getSimpleName();
    }
}