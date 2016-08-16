package bg.softuni.app.models.garbage;

import bg.softuni.app.framework.annotations.BurnableGarbageAnnotation;
import bg.softuni.app.framework.contracts.Waste;

@BurnableGarbageAnnotation
public class BurnableGarbage extends AbstractGarbage implements Waste {

    public BurnableGarbage(String name, double weight,double volumePerKg) {
        super(name, weight, volumePerKg);
    }
}