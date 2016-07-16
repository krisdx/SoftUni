package problem5_OnlineRadioDatabase.exeptions;

public class InvalidSongException extends Exception {

    public InvalidSongException(String message) {
        super(message);
    }
}