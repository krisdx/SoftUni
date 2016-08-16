package bg.softuni.app.framework.strategyHolder;

import bg.softuni.app.framework.contracts.GarbageDisposalStrategy;
import bg.softuni.app.framework.contracts.StrategyHolder;

import java.util.Collections;
import java.util.LinkedHashMap;
import java.util.Map;

public class StrategyHolderImpl implements StrategyHolder {

    private Map<Class, GarbageDisposalStrategy> strategies;

    public StrategyHolderImpl() {
        this.strategies = new LinkedHashMap<>();
    }

    @Override
    public Map<Class, GarbageDisposalStrategy> getDisposalStrategies() {
        return Collections.unmodifiableMap(this.strategies);
    }

    @Override
    public boolean addStrategy(Class annotationClass, GarbageDisposalStrategy strategy) {
        if (this.strategies.containsKey(annotationClass)) {
            return false;
        }

        this.strategies.put(annotationClass, strategy);
        return true;
    }

    @Override
    public boolean removeStrategy(Class annotationClass) {
        if (!this.strategies.containsKey(annotationClass)) {
            return false;
        }

        this.strategies.remove(annotationClass);
        return true;
    }
}