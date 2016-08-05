package problem1_Database;

import javax.naming.OperationNotSupportedException;

public interface Database {
    void add(Integer element)
            throws OperationNotSupportedException;

    Integer remove()
            throws OperationNotSupportedException;

    Integer[] fetch();
}