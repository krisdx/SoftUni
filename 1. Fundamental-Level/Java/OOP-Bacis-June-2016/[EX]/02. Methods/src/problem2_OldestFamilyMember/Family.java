package problem2_OldestFamilyMember;

import java.util.ArrayList;
import java.util.List;

public class Family {
    private List<Person> people;
    private Person oldestMember;

    public Family() {
        this.people = new ArrayList<>();
    }

    public void addMember(Person member) {
        if (this.oldestMember == null) {
            this.oldestMember = member;
        }

        if (member.getAge() > oldestMember.getAge()){
            oldestMember = member;
        }

        this.people.add(member);
    }

    public Person getOldestMember() {
        return this.oldestMember;
    }
}