package problem5_OnlineRadioDatabase.exeptions;

public class InvalidSongSecondsException extends InvalidSongLengthException{
    public InvalidSongSecondsException(String message) {
        super(message);
    }
}