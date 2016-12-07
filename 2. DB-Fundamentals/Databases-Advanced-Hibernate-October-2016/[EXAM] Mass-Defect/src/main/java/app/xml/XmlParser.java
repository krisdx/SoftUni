package app.xml;

import javax.xml.bind.JAXBException;

public interface XmlParser {
    <T> T readFromXml(Class<T> classes, String file) throws JAXBException;

    <T> void writeToXml(T object, String filePath) throws JAXBException;
}