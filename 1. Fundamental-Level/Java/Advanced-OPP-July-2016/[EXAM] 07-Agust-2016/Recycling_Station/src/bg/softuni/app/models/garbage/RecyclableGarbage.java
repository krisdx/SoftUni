package bg.softuni.app.models.garbage;

import bg.softuni.app.framework.annotations.RecyclableGarbageAnnotation;
import bg.softuni.app.framework.contracts.Waste;

@RecyclableGarbageAnnotation
public class RecyclableGarbage extends AbstractGarbage implements Waste {

    public RecyclableGarbage(String name, double weight, double volumePerKg) {
        super(name, weight, volumePerKg);
    }
}