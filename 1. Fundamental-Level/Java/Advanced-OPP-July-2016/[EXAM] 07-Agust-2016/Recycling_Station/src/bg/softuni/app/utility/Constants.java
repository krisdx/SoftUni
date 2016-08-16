package bg.softuni.app.utility;

import bg.softuni.app.framework.strategy.StorableGarbageStrategy;

public final class Constants {

    public static final String STRATEGIES_PACKAGE =
            StorableGarbageStrategy.class.getPackage().getName();

    public static final String ANNOTATION_SUFFIX = "Annotation";

    public static final String COMMAND_SUFFIX = "Command";

    public static final String GARBAGE_SUFFIX = "Garbage";

    public static final String STRATEGY_SUFFIX = "Strategy";

    /*
     This class should not be instantiated.
    */
    private Constants() {
    }
}