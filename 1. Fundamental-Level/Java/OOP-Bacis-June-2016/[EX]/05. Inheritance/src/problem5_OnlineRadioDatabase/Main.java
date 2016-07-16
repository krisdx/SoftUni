package problem5_OnlineRadioDatabase;

import problem5_OnlineRadioDatabase.exeptions.InvalidSongException;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        long totalTimeInSeconds = 0;
        int totalSongsCount = 0;

        int n = Integer.valueOf(reader.readLine());
        for (int i = 0; i < n; i++) {
            try {
                String[] lineArgs = reader.readLine().split(";");
                String artistName = lineArgs[0];
                String songName = lineArgs[1];
                String[] minutesAndSeconds = lineArgs[2].split(":");
                int minutes = Integer.valueOf(minutesAndSeconds[0]);
                int seconds = Integer.valueOf(minutesAndSeconds[1]);

                try {
                    Song song = new Song(artistName, songName, minutes, seconds);

                    totalTimeInSeconds += minutes * 60;
                    totalTimeInSeconds += seconds;
                    totalSongsCount++;
                    System.out.println("Song added.");
                } catch (InvalidSongException ex) {
                    System.out.println(ex.getMessage());
                }
            } catch (NumberFormatException ex) {
                System.out.println("Invalid song length.");
            }
        }

        System.out.println("Songs added: " + totalSongsCount);
        long hours = totalTimeInSeconds / 3600;
        long minutes = (totalTimeInSeconds / 60) % 60;
        long second = totalTimeInSeconds % 60;
        System.out.printf("Playlist length: %dh %dm %ds", hours, minutes, second);
    }
}