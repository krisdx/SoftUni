package problem2_ExtendedDatabase.tests;

import problem2_ExtendedDatabase.Person;
import problem2_ExtendedDatabase.PersonDatabase;
import problem2_ExtendedDatabase.PersonDatabaseImpl;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import javax.naming.OperationNotSupportedException;

public class Add_Tests {

    private PersonDatabase personDatabase;

    @Before
    public void initialize() {
        this.personDatabase = new PersonDatabaseImpl();
    }

    @Test
    public void addOnePerson_ShouldAdd()
            throws OperationNotSupportedException {

        // Arrange
        Long id = 1L;
        Person expectedPerson = new Person(id, "Test");

        // Act
        this.personDatabase.add(expectedPerson);

        // Assert
        Person actualPerson = this.personDatabase.findById(id);
        Assert.assertEquals(actualPerson, expectedPerson);
    }

    @Test(expected = OperationNotSupportedException.class)
    public void addTwoPersonsWithSameId_ShouldThrow()
            throws OperationNotSupportedException {

        // Arrange
        Long id = 1L;
        Person expectedPerson = new Person(id, "Test");

        // Act & Assert
        this.personDatabase.add(expectedPerson);
        this.personDatabase.add(expectedPerson);
    }

    @Test(expected = OperationNotSupportedException.class)
    public void addPersonWithNegativeId_ShouldThrow()
            throws OperationNotSupportedException {

        // Arrange
        Long id = -13L;
        Person expectedPerson = new Person(id, "Test");

        // Act & Assert
        this.personDatabase.add(expectedPerson);
    }

    @Test(expected = OperationNotSupportedException.class)
    public void addPersonWithNullId_ShouldThrow()
            throws OperationNotSupportedException {

        // Arrange
        Long id = null;
        Person expectedPerson = new Person(id, "Test");

        // Act & Assert
        this.personDatabase.add(expectedPerson);
    }
}