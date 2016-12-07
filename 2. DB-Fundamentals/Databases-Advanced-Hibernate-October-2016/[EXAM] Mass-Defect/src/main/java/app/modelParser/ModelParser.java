package app.modelParser;

import org.modelmapper.PropertyMap;

public interface ModelParser {
    <T, E> E convert(T source, Class<E> desired);

    <T, E> E convert(T source, Class<E> desired, PropertyMap<T, E> propertyMap);
}