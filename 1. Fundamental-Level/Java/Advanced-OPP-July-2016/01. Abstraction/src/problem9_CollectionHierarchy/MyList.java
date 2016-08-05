package problem9_CollectionHierarchy;

import java.util.ArrayList;
import java.util.List;

public class MyList implements Addable, Removeable, Countable {
    private List<String> elements;

    public MyList() {
        this.elements = new ArrayList<>();
    }

    @Override
    public int add(String element) {
        this.elements.add(0, element);
        return 0;
    }

    @Override
    public String remove() {
        String elementToRemove = this.elements.get(0);
        this.elements.remove(0);
        return elementToRemove;
    }

    @Override
    public int count() {
        return this.elements.size();
    }
}
