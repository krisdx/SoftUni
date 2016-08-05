package problem9_CollectionHierarchy;

import java.util.ArrayList;
import java.util.List;

public class AddCollection implements Addable {
    private List<String> elements;

    public AddCollection() {
        this.elements = new ArrayList<>();
    }

    @Override
    public int add(String element) {
        int addedIndex = this.elements.size();
        this.elements.add(element);
        return addedIndex;
    }
}