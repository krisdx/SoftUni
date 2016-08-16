package bg.softuni.app.core;

import bg.softuni.app.core.io.CommandInterpreter;
import bg.softuni.app.core.io.command.Executable;
import bg.softuni.app.core.io.reader.Reader;
import bg.softuni.app.core.io.writer.Writer;
import bg.softuni.app.utility.Messages;

import java.io.IOException;

public class EngimeImpl implements Engine {

    private Reader reader;
    private Writer writer;
    private CommandInterpreter commandInterpreter;

    public EngimeImpl(Reader reader, Writer writer,CommandInterpreter commandInterpreter) {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    @Override
    public void run() {
        while (true) {
            try {
                String inputLine = this.reader.readLine();
                if (inputLine.equals(Messages.END_MESSAGE)) {
                    break;
                }

                Executable command = this.commandInterpreter.parseCommand(inputLine);
                String result = command.execute();
                this.writer.writeLine(result);

            } catch (IOException ioEx) {
                this.writer.displayException(ioEx);
            } catch (ReflectiveOperationException roe) {
                this.writer.displayException(roe);
            }
        }
    }
}