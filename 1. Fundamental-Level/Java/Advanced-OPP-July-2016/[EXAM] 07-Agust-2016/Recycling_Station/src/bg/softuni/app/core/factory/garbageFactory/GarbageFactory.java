package bg.softuni.app.core.factory.garbageFactory;

import bg.softuni.app.framework.contracts.Waste;

public interface GarbageFactory {

    Waste createGarbage(String[] data)
            throws ReflectiveOperationException;
}