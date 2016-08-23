package behavioral.visitorPattern.models.visitor;

import behavioral.visitorPattern.models.element.Element;

public interface Visitor {
    void visit(Element element);
}