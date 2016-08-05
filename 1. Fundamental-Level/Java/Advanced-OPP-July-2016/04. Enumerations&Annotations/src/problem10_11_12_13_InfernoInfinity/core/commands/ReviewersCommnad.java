package problem10_11_12_13_InfernoInfinity.core.commands;

import problem10_11_12_13_InfernoInfinity.contracts.Engine;
import problem10_11_12_13_InfernoInfinity.contracts.Executable;
import problem10_11_12_13_InfernoInfinity.models.weapons.AbstractWeapon;
import problem10_11_12_13_InfernoInfinity.utilities.ClassInfo;
import problem10_11_12_13_InfernoInfinity.utilities.CommandName;

@CommandName(name = "Reviewers")
public class ReviewersCommnad extends Command implements Executable {

    public ReviewersCommnad(Engine engine) {
        super(engine);
    }

    @Override
    public void execute(String[] args) {
        ClassInfo classInfoAnnotation =
                AbstractWeapon.class.getAnnotation(ClassInfo.class);
        String[] reviewers = classInfoAnnotation.reviewers();
        this.getEngine().getWriter().printLine("Reviewers: " + String.join(", ", reviewers));
    }
}