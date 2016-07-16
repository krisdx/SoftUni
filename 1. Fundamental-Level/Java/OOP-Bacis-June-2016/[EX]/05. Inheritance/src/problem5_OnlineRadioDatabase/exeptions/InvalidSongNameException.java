package problem5_OnlineRadioDatabase.exeptions;

public class InvalidSongNameException extends InvalidSongException{
    public InvalidSongNameException(String message) {
        super(message);
    }
}