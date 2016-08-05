package problem10_11_12_13_InfernoInfinity.core.commands;

import problem10_11_12_13_InfernoInfinity.contracts.Engine;
import problem10_11_12_13_InfernoInfinity.contracts.Executable;
import problem10_11_12_13_InfernoInfinity.models.weapons.AbstractWeapon;
import problem10_11_12_13_InfernoInfinity.utilities.ClassInfo;
import problem10_11_12_13_InfernoInfinity.utilities.CommandName;

@CommandName(name = "Author")
public class AuthorCommand extends Command implements Executable {

    public AuthorCommand(Engine engine) {
        super(engine);
    }

    @Override
    public void execute(String[] args) {
        ClassInfo classInfoAnnotation =
                AbstractWeapon.class.getAnnotation(ClassInfo.class);
        String author = classInfoAnnotation.author();
        this.getEngine().getWriter().printLine("Author: " + author);
    }
}