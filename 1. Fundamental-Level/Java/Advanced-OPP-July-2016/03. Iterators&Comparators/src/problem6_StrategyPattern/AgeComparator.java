package problem6_StrategyPattern;

import java.util.Comparator;

public class AgeComparator implements Comparator<TestPerson>{
    @Override
    public int compare(TestPerson firstPerson, TestPerson secondPerson) {
        return Integer.compare(firstPerson.getAge(), secondPerson.getAge());
    }
}
