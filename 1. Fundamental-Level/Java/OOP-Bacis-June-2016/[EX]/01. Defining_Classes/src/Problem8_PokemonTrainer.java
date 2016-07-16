import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Problem8_PokemonTrainer {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        Map<String, Trainer> trainers = new LinkedHashMap<>();
        while (true) {
            String line = reader.readLine();
            if (line.equals("Tournament")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            String trainerName = lineArgs[0];
            String pokemonName = lineArgs[1];
            String pokemonElement = lineArgs[2];
            int pokemonHealth = Integer.valueOf(lineArgs[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            Trainer trainer = null;
            if (trainers.containsKey(trainerName)) {
                trainers.get(trainerName).getPokemons().add(pokemon);
            } else {
                trainer = new Trainer(trainerName, pokemon);
                trainers.put(trainerName, trainer);
            }
        }

        while (true) {
            String line = reader.readLine();
            if (line.equals("End")) {
                break;
            }

            for (Map.Entry<String, Trainer> trainer : trainers.entrySet()) {
                if (trainer.getValue().containsPokemon(line)) {
                    trainer.getValue().setNumberOfBadges(trainer.getValue().getNumberOfBadges() + 1);
                } else {
                    trainer.getValue().damagePokemons();
                }
            }
        }

        trainers.entrySet().stream()
                .sorted((t1, t2) -> t2.getValue().getNumberOfBadges().compareTo(t1.getValue().getNumberOfBadges()))
                .forEach(t -> System.out.println(t.getValue()));
    }
}

class Pokemon {
    private String name;
    private String element;
    private int health;

    public Pokemon(String name, String element, int health) {
        this.name = name;
        this.element = element;
        this.health = health;
    }

    public String getElement() {
        return this.element;
    }

    public void setHealth(int health) {
        this.health = health;
    }

    public int getHealth() {
        return this.health;
    }
}

class Trainer {
    private String name;
    private int numberOfBadges;
    private Set<Pokemon> pokemons;

    public Trainer(String name) {
        this.name = name;
        this.pokemons = new HashSet<>();
    }

    public Trainer(String name, Pokemon pokemon) {
        this(name);
        this.pokemons.add(pokemon);
    }

    public boolean containsPokemon(String desiredPokemonElement) {
        for (Pokemon pokemon : this.pokemons) {
            if (pokemon.getElement().equals(desiredPokemonElement)) {
                return true;
            }
        }

        return false;
    }

    public void damagePokemons() {
        List<Pokemon> toRemove = new ArrayList<>();
        for (Pokemon pokemon : this.pokemons) {
            pokemon.setHealth(pokemon.getHealth() - 10);
            if (pokemon.getHealth() <= 0) {
                toRemove.add(pokemon);
            }
        }

        this.pokemons.removeAll(toRemove);
    }

    public Integer getNumberOfBadges() {
        return this.numberOfBadges;
    }

    public void setNumberOfBadges(int numberOfBadges) {
        this.numberOfBadges = numberOfBadges;
    }

    public Set<Pokemon> getPokemons() {
        return this.pokemons;
    }

    @Override
    public String toString() {
        return String.format("%s %d %d", this.name, this.numberOfBadges, this.pokemons.size());
    }
}