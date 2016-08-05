package bg.softuni.app.core.factory.fragmentFactory;

import bg.softuni.app.models.fragments.Fragment;

public interface FragmentFactory {

    Fragment createFragment(String[] data)
            throws ReflectiveOperationException;
}