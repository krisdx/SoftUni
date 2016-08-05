package problem6_MirrorImage.constracts;

import problem6_MirrorImage.events.CastFireballSpellEvent;
import problem6_MirrorImage.events.CastReflectionEvent;

public interface Wizard {
    int getId();

    String getName();

    int getMagicalPower();

    void castReflection(CastReflectionEvent reflectionSpellEvent);

    void castFireball(CastFireballSpellEvent fireballSpellEvent);
}