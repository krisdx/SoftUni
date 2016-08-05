package bg.softuni.app.core.io.command;

import bg.softuni.app.data.DataProvider;
import bg.softuni.app.models.fragments.Fragment;
import bg.softuni.app.utility.Messages;
import bg.softuni.app.utility.annotations.Inject;

public class DetachFragmentCommand extends Command implements Executable {

    @Inject
    private DataProvider database;

    public DetachFragmentCommand(String[] data) {
        super(data);
    }

    @Override
    public String execute() {
        Fragment detachedFragment = null;
        try {
            detachedFragment = this.database.detachFragment();
        } catch (UnsupportedOperationException ex) {
            return String.format(Messages.FAILED_DETACH_FRAGMENT, detachedFragment.getName());
        }

        return String.format(Messages.SUCCESSFUL_DETACH_FRAGMENT,
                detachedFragment.getName(), this.database.getCurrentCore().getName());
    }
}