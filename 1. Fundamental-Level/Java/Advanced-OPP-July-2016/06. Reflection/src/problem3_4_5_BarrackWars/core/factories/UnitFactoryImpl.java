package problem3_4_5_BarrackWars.core.factories;

import problem3_4_5_BarrackWars.contracts.Unit;
import problem3_4_5_BarrackWars.contracts.UnitFactory;
import problem3_4_5_BarrackWars.models.units.AbstractUnit;

import java.lang.reflect.Constructor;

public class UnitFactoryImpl implements UnitFactory {

    private static final String UNITS_PACKAGE_NAME =
            AbstractUnit.class.getPackage().getName();

    @Override
    public Unit createUnit(String unitType) {
        String classPath = UNITS_PACKAGE_NAME + "." + unitType;
        try {
            Class unitClass = Class.forName(classPath);
            Constructor constructor = unitClass.getDeclaredConstructor();
            Unit unit = (Unit) constructor.newInstance();
            return unit;
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        } catch (NoSuchMethodException e) {
            e.printStackTrace();
        } catch (IllegalAccessException | InstantiationException e) {
            e.printStackTrace();
        } catch (ReflectiveOperationException ex) {
            ex.printStackTrace();
        }

        return null;
    }
}