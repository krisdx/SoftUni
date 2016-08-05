package problem6_MirrorImage.core;

import problem6_MirrorImage.constracts.Wizard;
import problem6_MirrorImage.events.CastFireballSpellEvent;
import problem6_MirrorImage.events.CastReflectionEvent;
import problem6_MirrorImage.wizards.WizardImpl;

import java.util.*;

public class CustomBinaryTree {

    private int idCounter;

    private Map<Integer, Wizard> wizardsById;
    private Map<Wizard, List<Wizard>> wizardsWithChildren;

    public CustomBinaryTree() {
        this.wizardsById = new LinkedHashMap<>();
        this.wizardsWithChildren = new LinkedHashMap<>();
    }

    public void addInitialWizard(Wizard wizard) {
        this.wizardsById.put(wizard.getId(), wizard);
        this.wizardsWithChildren.put(wizard, new ArrayList<>());
        this.idCounter = wizard.getId() + 1;
    }

    public void reflect(int id) {
        Wizard wizardFather = this.wizardsById.get(id);
        this.triggerReflectionSpell(wizardFather);
        this.reflect(wizardFather);
    }

    public void fireBall(int id) {
        Wizard wizardFather = this.wizardsById.get(id);

        this.triggerFireballSpellEvent(wizardFather);

        this.fireBall(wizardFather);
    }

    private void reflect(Wizard wizardFather) {
        List<Wizard> children =
                this.wizardsWithChildren.get(wizardFather);
        if (children == null || children.isEmpty()) {
            this.createChildren(wizardFather);
            return;
        }

        for (Wizard child : children) {
            this.triggerReflectionSpell(child);
            this.reflect(child);
        }
    }

    private void triggerReflectionSpell(Wizard wizard) {
        CastReflectionEvent reflectionEvent = new CastReflectionEvent(this);
        wizard.castReflection(reflectionEvent);
    }

    private void createChildren(Wizard wizardFather) {
        for (int i = 1; i <= 2; i++) {
            int id = this.idCounter++;
            int magicPower = wizardFather.getMagicalPower() / 2;
            Wizard child = new WizardImpl(id, wizardFather.getName(), magicPower);

            if (!this.wizardsById.containsKey(id)) {
                this.wizardsById.put(id, child);
            }

            if (!this.wizardsWithChildren.containsKey(child)) {
                this.wizardsWithChildren.put(child, new ArrayList<>());
            }

            this.wizardsWithChildren.get(wizardFather).add(child);
        }
    }

    private void fireBall(Wizard wizardFather) {
        List<Wizard> children =
                this.wizardsWithChildren.get(wizardFather);
        if (children == null || children.isEmpty()) {
            return;
        }

        for (Wizard child : children) {
            this.triggerFireballSpellEvent(child);
            this.fireBall(child);
        }
    }

    private void triggerFireballSpellEvent(Wizard wizard) {
        CastFireballSpellEvent fireballSpellEvent = new CastFireballSpellEvent(this);
        wizard.castFireball(fireballSpellEvent);
    }
}