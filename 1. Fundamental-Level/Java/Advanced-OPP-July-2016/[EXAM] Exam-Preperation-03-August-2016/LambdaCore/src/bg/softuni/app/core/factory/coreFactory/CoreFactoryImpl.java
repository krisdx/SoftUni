package bg.softuni.app.core.factory.coreFactory;

import bg.softuni.app.models.cores.Core;
import bg.softuni.app.utility.Constants;

import java.lang.reflect.Constructor;

public class CoreFactoryImpl implements CoreFactory {

    private static final String CORE_PACKAGE =
            Core.class.getPackage().getName();

    @Override
    @SuppressWarnings("unchecked")
    public Core createCore(String[] data) throws ReflectiveOperationException {
        String coreType = data[0];
        long durability = Long.valueOf(data[1]);

        String path = CORE_PACKAGE + "." + coreType + Constants.CORE_SUFFIX;
        Class<Core> coreClass = (Class<Core>) Class.forName(path);
        Constructor constructor = coreClass.getDeclaredConstructor(long.class);
        Core core = (Core) constructor.newInstance(durability);
        return core;
    }
}