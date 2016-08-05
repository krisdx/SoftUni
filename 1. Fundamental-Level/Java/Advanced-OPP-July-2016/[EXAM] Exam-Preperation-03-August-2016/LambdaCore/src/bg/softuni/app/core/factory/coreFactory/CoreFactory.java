package bg.softuni.app.core.factory.coreFactory;

import bg.softuni.app.models.cores.Core;

public interface CoreFactory {

    Core createCore(String[] data)
            throws ReflectiveOperationException;
}