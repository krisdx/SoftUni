package bg.softuni.app.models.garbage;

import bg.softuni.app.framework.annotations.StorableGarbageAnnotation;
import bg.softuni.app.framework.contracts.Waste;

@StorableGarbageAnnotation
public class StorableGarbage extends AbstractGarbage implements Waste {

    public StorableGarbage(String name, double weight, double volumePerKg) {
        super(name, weight, volumePerKg);
    }
}