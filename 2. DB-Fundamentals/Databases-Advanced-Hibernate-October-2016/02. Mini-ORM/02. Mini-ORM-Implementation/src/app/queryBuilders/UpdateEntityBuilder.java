package app.queryBuilders;

import app.persistence.Column;
import app.persistence.Entity;
import app.persistence.Id;

import java.lang.reflect.Field;

public class UpdateEntityBuilder {

    public static String buildCreateTableQuery(Class entity, Field... columns) {
        StringBuilder query = new StringBuilder();

        String tableName = getTableName(entity);
        query.append("UPDATE ").append(tableName);
        query.append(" SET ");

        boolean afterFirstColumn = false;
        for (Field column : columns) {
            column.setAccessible(true);
            if (column.isAnnotationPresent(Id.class)) {
                continue;
            }

            String columnName = getFieldName(column);
            String columnUpdate = String.format("%s = ?", columnName);
            if (!afterFirstColumn) {
                query.append(columnUpdate);
                afterFirstColumn = true;
            } else {
                query.append(", ").append(columnUpdate);
            }
        }

        query.append(" WHERE id = ?");
        return query.toString();
    }

    private static String getFieldName(Field field) {
        field.setAccessible(true);
        if (field.isAnnotationPresent(Column.class)) {// TODO: field.getClass ?
            Column columnAnnotation = field.getAnnotation(Column.class);
            return columnAnnotation.name();
        }

        return field.getName();
    }

    private static <E> String getTableName(Class<E> entity) {
        if (entity.isAnnotationPresent(Entity.class)) {
            Entity entityAnnotation = entity.getAnnotation(Entity.class);
            return entityAnnotation.name();
        }

        return entity.getSimpleName();
    }
}