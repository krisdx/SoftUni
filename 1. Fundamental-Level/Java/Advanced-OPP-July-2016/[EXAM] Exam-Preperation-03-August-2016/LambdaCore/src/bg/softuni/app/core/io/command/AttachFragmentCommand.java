package bg.softuni.app.core.io.command;

import bg.softuni.app.core.factory.fragmentFactory.FragmentFactory;
import bg.softuni.app.data.DataProvider;
import bg.softuni.app.models.fragments.Fragment;
import bg.softuni.app.utility.Messages;
import bg.softuni.app.utility.annotations.Inject;

public class AttachFragmentCommand extends Command implements Executable {

    @Inject
    private FragmentFactory fragmentFactory;

    @Inject
    private DataProvider database;

    public AttachFragmentCommand(String[] data) {
        super(data);
    }

    @Override
    public String execute() {
        Fragment fragment = null;
        try {
            fragment =
                    this.fragmentFactory.createFragment(this.getData());
            this.database.attachFragment(fragment);
        } catch (ReflectiveOperationException | IllegalArgumentException | UnsupportedOperationException ex) {
            return String.format(Messages.FAILED_TO_ATTACHE_FRAGMENT,
                    fragment.getName());
        }

        return String.format(Messages.SUCCESSFUL_ATTACHED_FRAGMENT,
                fragment.getName(), this.database.getCurrentCore().getName());
    }
}