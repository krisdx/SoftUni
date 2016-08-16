package bg.softuni.app.core.factory.garbageFactory;

import bg.softuni.app.framework.contracts.Waste;
import bg.softuni.app.models.garbage.AbstractGarbage;
import bg.softuni.app.utility.Constants;

import java.lang.reflect.Constructor;

public class GarbageFactoryImpl implements GarbageFactory {

    private static final String GARBAGES_PACKAGE =
            AbstractGarbage.class.getPackage().getName();

    @Override
    @SuppressWarnings("unchecked")
    public Waste createGarbage(String[] data) throws ReflectiveOperationException {
        String name = data[0];
        double weight = Double.valueOf(data[1]);
        double volumePerKg = Double.valueOf(data[2]);
        String garbageType = data[3];

        String classPath = GARBAGES_PACKAGE + "." + garbageType + Constants.GARBAGE_SUFFIX;
        Class<Waste> garbageClass = (Class<Waste>) Class.forName(classPath);
        Constructor constructor = garbageClass.getDeclaredConstructor(String.class, double.class, double.class);
        Waste waste = (Waste) constructor.newInstance(name, weight, volumePerKg);
        return waste;
    }
}