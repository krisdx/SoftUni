package problem2_ExtendedDatabase;

import javax.naming.OperationNotSupportedException;

public interface PersonDatabase {

    void add(Person person)
            throws OperationNotSupportedException;

    Person removeById(Long id)
            throws OperationNotSupportedException;

    Person removeByUsername(String username) throws OperationNotSupportedException;

    Person findById(Long id) throws OperationNotSupportedException;
}