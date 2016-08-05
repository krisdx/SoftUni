package problem8_MilitaryElite.contracts;

import java.util.Collection;

public interface LeutanantGeneral extends PrivateSoldier {
    Collection<PrivateSoldier> getPrivateSoldiers();
}