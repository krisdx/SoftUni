package bg.softuni.app.utility;

public final class Messages {

    public static final String END_MESSAGE = "System Shutdown!";

    public static final String SUCCESSFUL_CORE_CREATION =
            "Successfully created Core %s!";

    public static final String FAILED_CORE_CREATION =
            "Failed to create Core!";

    public static final String NON_EXISTING_CORE_IN_DATABASE =
            "The core with the name %s does not exist in the database.";

    public static final String NEGATIVE_CORE_DURABILITY =
            "The durability cannot be negative.";

    public static final String FAILED_TO_REMOVE_CORE =
            "Failed to remove Core %s!";

    public static final String REMOVE_CORE_SUCCESSFUL =
            "Successfully removed Core %s!";

    public static final String SUCCESSFUL_CORE_SELECTION =
            "Currently selected Core %s!";

    public static final String FAILED_CORE_SELECTION =
            "Failed to select Core %s!";

    public static final String NEGATIVE_PRESSURE_AFFECTION =
            "The pressure cannot be negative.";

    public static final String NON_SELECTED_CORE =
            "No currently selected core";

    public static final String SUCCESSFUL_ATTACHED_FRAGMENT =
            "Successfully attached Fragment %s to Core %s!";

    public static final String FAILED_TO_ATTACHE_FRAGMENT =
            "Failed to attach Fragment %s!";

    public static final String EMPTY_COLLECTION_MESSAGE =
            "The stack is empty.";

    public static final String FAILED_DETACH_FRAGMENT =
            "Failed to detach Fragment %s!";

    public static final String SUCCESSFUL_DETACH_FRAGMENT =
            "Successfully detached Fragment %s from Core %s!";

    /*
      This class should not be instantiated.
     */
    private Messages() {
    }
}