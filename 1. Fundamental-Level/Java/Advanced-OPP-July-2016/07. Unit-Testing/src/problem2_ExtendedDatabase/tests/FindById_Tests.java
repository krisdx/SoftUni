package problem2_ExtendedDatabase.tests;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import problem2_ExtendedDatabase.Person;
import problem2_ExtendedDatabase.PersonDatabase;
import problem2_ExtendedDatabase.PersonDatabaseImpl;

import javax.naming.OperationNotSupportedException;

public class FindById_Tests {
    private PersonDatabase personDatabase;

    @Before
    public void initialize() {
        this.personDatabase = new PersonDatabaseImpl();
    }

    @Test
    public void addOnePerson_ShouldFindTheSamePerson()
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
    public void findPersonWithWrongId_ShouldThrow()
            throws OperationNotSupportedException {

        // Arrange
        Long unexistingId = 1L;

        // Act & Assert
        this.personDatabase.findById(unexistingId);
    }

    @Test(expected = OperationNotSupportedException.class)
    public void findPersonWithNullId_ShouldThrow()
            throws OperationNotSupportedException {

        // Act & Assert
        this.personDatabase.findById(null);
    }
}