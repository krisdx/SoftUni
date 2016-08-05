package problem9_CollectionHierarchy;

import java.util.ArrayList;
import java.util.List;

public class AddRemoveCollection implements Addable, Removeable {
    private List<String> elements;

    public AddRemoveCollection() {
        this.elements = new ArrayList<>();
    }

    @Override
    public int add(String element) {
        this.elements.add(0, element);
        return 0;
    }

    @Override
    public String remove() {
        String elementToRemove = this.elements.get(this.elements.size() - 1);
        this.elements.remove(this.elements.size() - 1);
        return elementToRemove;
    }
}