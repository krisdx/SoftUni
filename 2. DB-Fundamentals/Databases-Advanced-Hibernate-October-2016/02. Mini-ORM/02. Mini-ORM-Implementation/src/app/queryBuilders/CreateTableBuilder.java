package app.queryBuilders;

import app.persistence.Column;
import app.persistence.Entity;
import app.persistence.Id;

import java.lang.reflect.Field;

public class CreateTableBuilder {

    public static String buildCreateTableQuery(Class entity, Field primary, Field... columns) {
        StringBuilder query = new StringBuilder();

        String tableName = getTableName(entity);
        query.append("CREATE TABLE IF NOT EXISTS ")
                .append(tableName).append("(");

        appendPrimaryKey(primary, query);
        if (columns.length == 0) {
            query.append(")");
            return query.toString();
        }

        for (Field column : columns) {
            column.setAccessible(true);
            if (column.isAnnotationPresent(Id.class)) {
                continue;
            }

            String columnName = getFieldName(column);
            String columnType = getDbType(column);
            String columnStr = String.format(", %s %s", columnName, columnType);
            query.append(columnStr);
        }

        query.append(")");
        return query.toString();
    }

    private static void appendPrimaryKey(Field primary, StringBuilder query) {
        primary.setAccessible(true);

        String primaryKeyName = getFieldName(primary);
        String primaryKey = String.format("%s BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT",
                primaryKeyName);
        query.append(primaryKey);
    }

    private static String getFieldName(Field field) {
        field.setAccessible(true);
        if (field.isAnnotationPresent(Column.class)) {
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

    private static String getDbType(Field field) {
        switch (field.getType().getSimpleName().toLowerCase()) {
            case "int":
                return "INT";
            case "long":
                return "LONG";
            case "double":
                return "DOUBLE";
            case "string":
                return "VARCHAR(50)";
            case "date":
                return "DATE";
            case "boolean":
                return "TINYINT";
            default:
                throw new IllegalArgumentException("Unknow type.");
        }
    }
}