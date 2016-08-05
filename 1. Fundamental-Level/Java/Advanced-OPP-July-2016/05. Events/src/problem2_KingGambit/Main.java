package problem2_KingGambit;

import problem2_KingGambit.contracts.AttackObservable;
import problem2_KingGambit.contracts.HeroObserver;
import problem2_KingGambit.observers.Footman;
import problem2_KingGambit.observers.King;
import problem2_KingGambit.observers.RoyalGuard;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {

    public static void main(String[] args) throws IOException {

        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

        AttackObservable attackObservable = new AttackHandler();

        // Adding king
        String kingName = reader.readLine();
        HeroObserver king = new King(kingName);
        attackObservable.attachHero(king);

        // Adding Royal Guards
        String[] royalGuardsNames = reader.readLine().split("\\s+");
        for (String royalGuardsName : royalGuardsNames) {
            HeroObserver royalGuard = new RoyalGuard(royalGuardsName);
            attackObservable.attachHero(royalGuard);
        }

        // Adding Footmans
        String[] footmanNames = reader.readLine().split("\\s+");
        for (String footmanName : footmanNames) {
            HeroObserver royalGuard = new Footman(footmanName);
            attackObservable.attachHero(royalGuard);
        }

        while (true) {
            String line = reader.readLine();
            if (line.equalsIgnoreCase("end")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            String command = lineArgs[0];
            if (command.equalsIgnoreCase("attack")) {
                attackObservable.attackKing();
            } else if (command.equalsIgnoreCase("kill")) {
                String heroName = lineArgs[1];
                attackObservable.killHero(heroName);
            }
        }
    }
}