package app.perser;

import org.modelmapper.PropertyMap;

import java.util.Set;

public interface ModelParser {
    <T, E> E convert(T source, Class<E> desired);

    <T, E> E convert(T source, Class<E> desired, PropertyMap<T, E> propertyMap);

    <T, E> Set<E> convertCollection(Set<T> source, Class<E> desired);

    <T, E> Set<E> convertCollection(Set<T> source, Class<E> desired, PropertyMap<T, E> propertyMap);
}