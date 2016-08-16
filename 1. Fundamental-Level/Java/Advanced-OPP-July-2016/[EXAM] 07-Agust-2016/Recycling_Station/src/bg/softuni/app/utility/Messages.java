package bg.softuni.app.utility;

public final class Messages {

    public static final String END_MESSAGE = "TimeToRecycle";

    public static final String SUCCESSFUL_GARBAGE_PROCESSING =
            "%.2f kg of %s successfully processed!";

    public static final String FAILED_GARBAGE_PROCESSING =
            "Failed to process garbage.";

    public static final String STATUS_MESSAGE =
            "Energy: %.2f Capital: %.2f";

    public static final String INVALID_GARBAGE =
            "The passed in garbage does not implement " +
                    "an annotation implementing the Disposable meta-annotation or " +
                    "is not supported by the StrategyHolder.";

    public static final String NULL_GARBAGE =
            "The garbage cannot be null.";

    public static final String NULL_NAME =
            "The name cannot be null";

    public static final String NEGATIVE_ARGUMENT =
            "The %s cannot be nagative.";

    public static final String SUCCESSFUL_MANAGEMENT_CHANGED =
            "Management requirement changed!";

    public static final String CANNOT_PRODUCE =
            "Processing Denied!";

    /*
      This class should not be instantiated.
     */
    private Messages() {
    }
}