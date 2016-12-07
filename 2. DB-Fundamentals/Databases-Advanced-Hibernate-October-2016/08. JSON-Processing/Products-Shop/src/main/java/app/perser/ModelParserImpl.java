package app.perser;

import org.modelmapper.ModelMapper;
import org.modelmapper.PropertyMap;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Component;

import java.io.File;
import java.util.HashSet;
import java.util.Set;

@Component
public class ModelParserImpl implements ModelParser {

    private ModelMapper modelMapper;

    public ModelParserImpl() {
        this.modelMapper = new ModelMapper();
    }

    @Override
    public <T, E> E convert(T source, Class<E> desired) {
        return this.convert(source, desired, null);
    }

    @Override
    public <T, E> E convert(T source, Class<E> desired, PropertyMap<T, E> propertyMap) {
        if (propertyMap != null) {
            this.modelMapper.addMappings(propertyMap);
        }


        return this.modelMapper.map(source, desired);
    }

    @Override
    public <T, E> Set<E> convertCollection(Set<T> source, Class<E> desired) {
        return this.convertCollection(source, desired, null);
    }

    @Override
    public <T, E> Set<E> convertCollection(Set<T> source, Class<E> desired, PropertyMap<T, E> propertyMap) {
        if (propertyMap != null) {
            this.modelMapper.addMappings(propertyMap);
        }

        Set<E> convertedObjects = new HashSet<>();
        for (T s : source) {
            E converted = this.modelMapper.map(s, desired);
            convertedObjects.add(converted);
        }

        return convertedObjects;
    }
}