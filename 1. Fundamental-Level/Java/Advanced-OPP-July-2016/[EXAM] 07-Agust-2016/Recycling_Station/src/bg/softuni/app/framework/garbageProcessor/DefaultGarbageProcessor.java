package bg.softuni.app.framework.garbageProcessor;

import bg.softuni.app.framework.annotations.Disposable;
import bg.softuni.app.framework.contracts.*;
import bg.softuni.app.framework.strategyHolder.DefaultStrategyHolder;
import bg.softuni.app.utility.Messages;

import java.lang.annotation.Annotation;

public class DefaultGarbageProcessor implements GarbageProcessor {

    private StrategyHolder strategyHolder;

    public DefaultGarbageProcessor(StrategyHolder strategyHolder) {
        this.setStrategyHolder(strategyHolder);
    }

    public DefaultGarbageProcessor() {
        this(new DefaultStrategyHolder());
    }

    @Override
    public StrategyHolder getStrategyHolder() {
        return this.strategyHolder;
    }

    @Override
    public ProcessingData processWaste(Waste garbage) {
        Class type = garbage.getClass();
        Annotation[] garbageAnnotations = type.getAnnotations();
        Class disposableAnnotation = null;
        for (Annotation annotation : garbageAnnotations) {
            if (Disposable.class.isAnnotationPresent(annotation.annotationType())) {
                disposableAnnotation = annotation.annotationType();
                break;
            }
        }

        if (disposableAnnotation == null ||
                !this.getStrategyHolder().getDisposalStrategies().containsKey(disposableAnnotation)) {
            throw new IllegalArgumentException(Messages.INVALID_GARBAGE);
        }

        GarbageDisposalStrategy currentStrategy = this.getStrategyHolder()
                .getDisposalStrategies()
                .get(disposableAnnotation);
        return currentStrategy.processGarbage(garbage);
    }

    private void setStrategyHolder(StrategyHolder strategyHolder) {
        this.strategyHolder = strategyHolder;
    }
}