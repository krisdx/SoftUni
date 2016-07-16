package problem5_OnlineRadioDatabase;

import problem5_OnlineRadioDatabase.exeptions.*;

public class Song {
    private String songName;
    private String artistName;
    private int minutes;
    private int seconds;

    public Song(String artistName, String songName, int minutes, int seconds) throws InvalidSongException {
        this.setArtistName(artistName);
        this.setSongName(songName);
        this.setMinutes(minutes);
        this.setSeconds(seconds);
    }

    private void setArtistName(String artistName) throws InvalidArtistNameException {
        if (artistName.length() < 3 || artistName.length() > 20) {
            throw new InvalidArtistNameException(
                    "Artist name should be between 3 and 20 symbols.");
        }

        this.artistName = artistName;
    }

    private void setSongName(String songName) throws InvalidSongNameException {
        if (songName.length() < 3 || songName.length() > 30) {
            throw new InvalidSongNameException(
                    "Song name should be between 3 and 30 symbols.");
        }

        this.songName = songName;
    }

    private void setMinutes(int minutes) throws InvalidSongMinutesException {
        if (minutes < 0 || minutes > 14) {
            throw new InvalidSongMinutesException(
                    "Song minutes should be between 0 and 14.");
        }

        this.minutes = minutes;
    }

    private void setSeconds(int seconds) throws InvalidSongSecondsException {
        if (seconds < 0 || seconds > 59) {
            throw new InvalidSongSecondsException(
                    "Song seconds should be between 0 and 59.");
        }

        this.seconds = seconds;
    }
}