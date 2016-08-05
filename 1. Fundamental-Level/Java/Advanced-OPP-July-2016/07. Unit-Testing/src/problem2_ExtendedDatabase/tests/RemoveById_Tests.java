package problem2_ExtendedDatabase.tests;

import problem2_ExtendedDatabase.Person;
import problem2_ExtendedDatabase.PersonDatabase;
import problem2_ExtendedDatabase.PersonDatabaseImpl;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import javax.naming.OperationNotSupportedException;

public class RemoveById_Tests {

    private PersonDatabase personDatabase;

    @Before
    public void initialize() {
        this.personDatabase = new PersonDatabaseImpl();
    }

    @Test
    public void removeOnePerson_ShouldRemove()
            throws OperationNotSupportedException {

        // Arrange
        Long id = 1L;
        Person expectedPerson = new Person(id, "Test");

        // Act
        this.personDatabase.add(expectedPerson);
        Person actualPerson = this.personDatabase.removeById(id);

        // Assert
        Assert.assertEquals(expectedPerson, actualPerson);
    }

    @Test(expected =  OperationNotSupportedException.class)
    public void removeOnePersonWithWrongId_ShouldThrow()
            throws OperationNotSupportedException {

        // Arrange
        Long id = 1L;

        // Act
       this.personDatabase.removeById(id);
    }
}