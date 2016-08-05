package problem2_ExtendedDatabase.tests;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import problem2_ExtendedDatabase.Person;
import problem2_ExtendedDatabase.PersonDatabase;
import problem2_ExtendedDatabase.PersonDatabaseImpl;

import javax.naming.OperationNotSupportedException;

public class RemoveByUsername {

    private PersonDatabase personDatabase;

    @Before
    public void initialize() {
        this.personDatabase = new PersonDatabaseImpl();
    }

    @Test
    public void removeOnePerson_ShouldRemove()
            throws OperationNotSupportedException {

        // Arrange
        String username = "Test";
        Person expectedPerson = new Person(1L, username);

        // Act
        this.personDatabase.add(expectedPerson);
        Person actualPerson = this.personDatabase.removeByUsername(username);

        // Assert
        Assert.assertEquals(expectedPerson, actualPerson);
    }

    @Test(expected =  OperationNotSupportedException.class)
    public void removeOnePersonWithUnexistingUsername_ShouldThrow()
            throws OperationNotSupportedException {

        // Arrange
        String username = "Test";

        // Act
        this.personDatabase.removeByUsername(username);
    }

    @Test(expected =  OperationNotSupportedException.class)
    public void removeOnePersonWithNullUsername_ShouldThrow()
            throws OperationNotSupportedException {

        // Act
        this.personDatabase.removeByUsername(null);
    }

    @Test(expected =  OperationNotSupportedException.class)
    public void removeOnePersonWithWrongUsername_ShouldThrow()
            throws OperationNotSupportedException {

        // Arrange
        String username = "Test";
        String wrongUsename = "test";

        // Act
        this.personDatabase.add(new Person(1L, username));

        // Act
        this.personDatabase.removeByUsername(wrongUsename);
    }
}