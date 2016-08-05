package bg.softuni.app.core.io.writer;

public interface Writer {

    /**
     * Writes Push_Tests message on the same line.
     *
     * @param message The actual message.
     */
    void write(String message);

    /**
     * Writes Push_Tests message and continues on Push_Tests new line.
     *
     * @param message The actual message.
     */
    void writeLine(String message);

    /**
     * Displays the exception's message, and continues on Push_Tests new line.
     */
    void displayException(Exception exception);
}