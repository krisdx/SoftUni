package bg.softuni.app.framework.garbageProcessor;

import bg.softuni.app.framework.annotations.Disposable;
import bg.softuni.app.framework.contracts.*;
import bg.softuni.app.framework.strategyHolder.DefaultStrategyHolder;
import bg.softuni.app.utility.Constants;
import bg.softuni.app.utility.Messages;

import java.lang.annotation.Annotation;

public class GarbageProcessorImpl implements GarbageProcessor {

    private StrategyHolder strategyHolder;

    public GarbageProcessorImpl(StrategyHolder strategyHolder) {
        this.setStrategyHolder(strategyHolder);
    }

    public GarbageProcessorImpl() {
        this(new DefaultStrategyHolder());
    }

    @Override
    public StrategyHolder getStrategyHolder() {
        return this.strategyHolder;
    }

    @Override
    public ProcessingData processWaste(Waste garbage) {
        if (garbage == null) {
            throw new IllegalArgumentException(Messages.NULL_GARBAGE);
        }

        Class type = garbage.getClass();
        Annotation[] garbageAnnotations = type.getAnnotations();
        Class disposableAnnotation = null;
        for (Annotation annotation : garbageAnnotations) {
            if (annotation.annotationType().isAnnotationPresent(Disposable.class)) {
                disposableAnnotation = annotation.annotationType();
                break;
            }
        }

        this.addStrategyToStrategyHolder(disposableAnnotation);
        if (disposableAnnotation == null) {
            throw new IllegalArgumentException(Messages.INVALID_GARBAGE);
        }

        GarbageDisposalStrategy currentStrategy = this.getStrategyHolder()
                .getDisposalStrategies()
                .get(disposableAnnotation);
        return currentStrategy.processGarbage(garbage);
    }

    private void addStrategyToStrategyHolder(Class disposableAnnotation) {
        try {
            String strategyName = disposableAnnotation.getSimpleName()
                    .replace(Constants.ANNOTATION_SUFFIX, "")
                    .concat(Constants.STRATEGY_SUFFIX);

            String path = Constants.STRATEGIES_PACKAGE + "." + strategyName;
            Class strategy = Class.forName(path);
            this.getStrategyHolder().addStrategy(
                    disposableAnnotation, (GarbageDisposalStrategy) strategy.newInstance());
        } catch (ReflectiveOperationException ex) {
            ex.printStackTrace();
        }
    }

    private void setStrategyHolder(StrategyHolder strategyHolder) {
        this.strategyHolder = strategyHolder;
    }
}