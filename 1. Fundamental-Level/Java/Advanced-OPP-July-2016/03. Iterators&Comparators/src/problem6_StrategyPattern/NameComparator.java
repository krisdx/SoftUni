package problem6_StrategyPattern;

import java.util.Comparator;

public class NameComparator implements Comparator<TestPerson> {

    @Override
    public int compare(TestPerson firstPerson, TestPerson secondPesron) {
        int compareIndex = Integer.compare(
                firstPerson.getName().length(),
                secondPesron.getName().length());
        if (compareIndex == 0) {
            compareIndex = Character.compare(
                    firstPerson.getName().toLowerCase().charAt(0),
                    secondPesron.getName().toLowerCase().charAt(0));
        }

        return compareIndex;
    }
}