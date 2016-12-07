package app.modelParser;

import org.modelmapper.ModelMapper;
import org.modelmapper.PropertyMap;
import org.springframework.stereotype.Component;

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
            // Clearing old/duplicated mappings, by created new object.
            this.modelMapper = new ModelMapper();
            this.modelMapper.addMappings(propertyMap);
        }

        return this.modelMapper.map(source, desired);
    }
}