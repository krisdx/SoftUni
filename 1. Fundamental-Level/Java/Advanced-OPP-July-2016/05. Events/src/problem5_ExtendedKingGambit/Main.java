package problem5_ExtendedKingGambit;

import problem5_ExtendedKingGambit.contracts.AttackObservable;
import problem5_ExtendedKingGambit.contracts.Attackable;
import problem5_ExtendedKingGambit.contracts.HeroObserver;
import problem5_ExtendedKingGambit.observers.AbstractHero;
import problem5_ExtendedKingGambit.observers.Footman;
import problem5_ExtendedKingGambit.observers.King;
import problem5_ExtendedKingGambit.observers.RoyalGuard;

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

        AttackObservable attackHandler = new AttackHandler();

        // Adding king
        String kingName = reader.readLine();
        Attackable king = new King(kingName);
        attackHandler.attachKing(king);

        // Adding Royal Guards
        String[] royalGuardsNames = reader.readLine().split("\\s+");
        for (String royalGuardsName : royalGuardsNames) {
            AbstractHero royalGuard = new RoyalGuard(royalGuardsName, attackHandler);
            attackHandler.attachHero(royalGuard);
        }

        // Adding Footmans
        String[] footmanNames = reader.readLine().split("\\s+");
        for (String footmanName : footmanNames) {
            AbstractHero royalGuard = new Footman(footmanName, attackHandler);
            attackHandler.attachHero(royalGuard);
        }

        while (true) {
            String line = reader.readLine();
            if (line.equalsIgnoreCase("end")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            String command = lineArgs[0];
            if (command.equalsIgnoreCase("attack")) {
                attackHandler.attackKing();
            } else if (command.equalsIgnoreCase("kill")) {
                String heroName = lineArgs[1];
                attackHandler.attackHero(heroName);
            }
        }
    }
}