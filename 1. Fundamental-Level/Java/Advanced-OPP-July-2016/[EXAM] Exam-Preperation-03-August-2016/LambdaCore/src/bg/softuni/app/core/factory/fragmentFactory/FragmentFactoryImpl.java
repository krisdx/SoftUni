package bg.softuni.app.core.factory.fragmentFactory;

import bg.softuni.app.models.fragments.Fragment;
import bg.softuni.app.utility.Constants;

import java.lang.reflect.Constructor;

public class FragmentFactoryImpl implements FragmentFactory {

    private static final String FRAGMENTS_PACKAGE =
            Fragment.class.getPackage().getName();

    @Override
    @SuppressWarnings("unchecked")
    public Fragment createFragment(String[] data) throws ReflectiveOperationException{
        String fragmentType = data[0];
        String name = data[1];
        long pressureAffection = Long.valueOf(data[2]);

        String path =
                FRAGMENTS_PACKAGE + "." + fragmentType + Constants.FRAGMENT_SUFFIX;
        Class<Fragment> coreClass = (Class<Fragment>) Class.forName(path);
        Constructor constructor = coreClass.getDeclaredConstructor(String.class, long.class);
        Fragment fragment = (Fragment) constructor.newInstance(name, pressureAffection);
        return fragment;
    }
}