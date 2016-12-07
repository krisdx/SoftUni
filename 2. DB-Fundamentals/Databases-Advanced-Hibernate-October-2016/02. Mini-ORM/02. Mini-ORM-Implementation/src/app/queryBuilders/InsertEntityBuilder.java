package app.queryBuilders;

import app.persistence.Column;
import app.persistence.Entity;
import app.persistence.Id;

import java.lang.reflect.Field;

public class InsertEntityBuilder {

    private static final Character VALUE_ARGUMENT_SYMBOL = '?';

    public static String buildInsertEntityQuery(Class entity, Field... columns) {
        StringBuilder query = new StringBuilder();

        query.append("INSERT INTO ")
                .append(getTableName(entity)).append("(");
        appendColumnNames(query, columns);
        query.append(")");

        query.append(" VALUES(");
        appendValueArgs(query, columns);
        query.append(")");

        return query.toString();
    }

    private static void appendColumnNames(StringBuilder query, Field... columns) {
        boolean afterFirstColumn = false;
        for (Field column : columns) {
            column.setAccessible(true);
            if (column.isAnnotationPresent(Id.class)) {
                continue;
            }

            String columnName = getFieldName(column);
            if (!afterFirstColumn) {
                query.append(columnName);
                afterFirstColumn = true;
            } else {
                query.append(", ").append(columnName);
            }
        }
    }

    private static void appendValueArgs(StringBuilder query, Field... columns) {
        boolean afterFirstColumn = false;
        for (Field column : columns) {
            column.setAccessible(true);
            if (column.isAnnotationPresent(Id.class)) {
                continue;
            }

            if (!afterFirstColumn) {
                query.append(VALUE_ARGUMENT_SYMBOL);
                afterFirstColumn = true;
            } else {
                query.append(", ").append(VALUE_ARGUMENT_SYMBOL);
            }
        }
    }

    private static <E> String getTableName(Class<E> entity) {
        if (entity.isAnnotationPresent(Entity.class)) {
            Entity entityAnnotation = entity.getAnnotation(Entity.class);
            return entityAnnotation.name();
        }

        return entity.getSimpleName();
    }

    private static String getFieldName(Field field) {
        field.setAccessible(true);
        if (field.isAnnotationPresent(Column.class)) {// TODO: field.getClass ?
            Column columnAnnotation = field.getAnnotation(Column.class);
            return columnAnnotation.name();
        }

        return field.getName();
    }
}