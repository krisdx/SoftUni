package problem9_CustomListGenerator;

public class CommandInterpreter {

    public static <E> String executeCommand(String line, CustomIterableList<E> elements) {
        String[] lineArgs = line.split("\\s+");
        String command = lineArgs[0];

        String commandResult = null;
        switch (command) {
            case "Add":
                commandResult = executeAddCommand(lineArgs, elements);
                break;
            case "Remove":
                commandResult = executeRemoveCommand(lineArgs, elements);
                break;
            case "Contains":
                commandResult = executeContainsCommand(lineArgs, elements);
                break;
            case "Swap":
                commandResult = executeSwapCommand(lineArgs, elements);
                break;
            case "Greater":
                commandResult = executeGreaterCommand(lineArgs, elements);
                break;
            case "Max":
                commandResult = executeMaxCommand(lineArgs, elements);
                break;
            case "Min":
                commandResult = executeMinCommand(lineArgs, elements);
                break;
            case "Sort":
                commandResult = executeSortCommand(lineArgs, elements);
                break;
            case "Print":
                commandResult = executePrintCommand(lineArgs, elements);
                break;
            default:
                throw new IllegalArgumentException("Unknown command.");
        }

        return commandResult;
    }

    private static <E> String executeSortCommand(String[] lineArgs, CustomIterableList<E> elements) {
        elements.sort();
        return "";
    }

    private static <E> String executePrintCommand(String[] lineArgs, CustomIterableList<E> elements) {
        StringBuilder output = new StringBuilder();
        for (E element : elements) {
            output.append(element.toString())
                    .append(System.lineSeparator());
        }

        return output.toString().trim();
    }

    private static <E> String executeMinCommand(String[] lineArgs, CustomIterableList<E> elements) {
        E minElement = elements.getMin();
        return minElement.toString();
    }

    private static <E> String executeMaxCommand(String[] lineArgs, CustomIterableList<E> elements) {
        E maxElement = elements.getMax();
        return maxElement.toString();
    }

    private static <E> String executeGreaterCommand(String[] lineArgs, CustomIterableList<E> elements) {
        E element = (E) lineArgs[1];
        Integer result = elements.countGreaterThan(element);

        return result.toString();
    }

    private static <E> String executeSwapCommand(String[] lineArgs, CustomIterableList<E> elements) {
        int firstIndex = Integer.valueOf(lineArgs[1]);
        int secondIndex = Integer.valueOf(lineArgs[2]);
        elements.swap(firstIndex, secondIndex);

        return "";
    }

    private static <E> String executeContainsCommand(String[] lineArgs, CustomIterableList<E> elements) {
        E searchElement = (E) lineArgs[1];
        Boolean hasFound = elements.contains(searchElement);

        return hasFound.toString();
    }

    private static <E> String executeRemoveCommand(String[] lineArgs, CustomIterableList<E> element) {
        int index = Integer.valueOf(lineArgs[1]);
        E removedElement = element.removeElement(index);

        return "";
    }

    private static <E> String executeAddCommand(String[] lineArgs, CustomIterableList<E> elements) {
        E elementToAdd = (E) lineArgs[1];
        elements.add(elementToAdd);

        return "";
    }
}