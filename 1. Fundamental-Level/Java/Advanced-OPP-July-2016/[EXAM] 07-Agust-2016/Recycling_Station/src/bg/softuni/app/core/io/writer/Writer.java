package bg.softuni.app.core.io.writer;

public interface Writer {

    /**
     * Writes a message on the same line.
     *
     * @param message The actual message.
     */
    void write(String message);

    /**
     * Writes a message and continues on Push_Tests new line.
     *
     * @param message The actual message.
     */
    void writeLine(String message);

    /**
     * Displays the exception's message, and continues on a new line.
     */
    void displayException(Exception exception);
}