package behavioral.visitorPattern.models.element;

import behavioral.visitorPattern.models.visitor.Visitor;

public interface Element {
    void accept(Visitor visitor);
}