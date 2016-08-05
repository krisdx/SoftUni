package problem7_CustomList;

public class CommandInterpreter {

    public static <E> String executeCommand(String line, CustomList<E> elements) {
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
            case "Print":
                commandResult = executePrintCommand(lineArgs, elements);
                break;
            default:
                throw new IllegalArgumentException("Unknown command");
        }

        return commandResult;
    }

    private static <E> String executePrintCommand(String[] lineArgs, CustomList<E> elements) {
        return elements.toString();
    }

    private static <E> String executeMinCommand(String[] lineArgs, CustomList<E> elements) {
        E minElement = elements.getMin();
        return minElement.toString();
    }

    private static <E> String executeMaxCommand(String[] lineArgs, CustomList<E> elements) {
        E maxElement = elements.getMax();
        return maxElement.toString();
    }

    private static <E> String executeGreaterCommand(String[] lineArgs, CustomList<E> elements) {
        E element = (E) lineArgs[1];
        Integer result = elements.countGreaterThan(element);

        return result.toString();
    }

    private static <E> String executeSwapCommand(String[] lineArgs, CustomList<E> elements) {
        int firstIndex = Integer.valueOf(lineArgs[1]);
        int secondIndex = Integer.valueOf(lineArgs[2]);
        elements.swap(firstIndex, secondIndex);

        return "";
    }

    private static <E> String executeContainsCommand(String[] lineArgs, CustomList<E> elements) {
        E searchElement = (E) lineArgs[1];
        Boolean hasFound = elements.contains(searchElement);

        return hasFound.toString();
    }

    private static <E> String executeRemoveCommand(String[] lineArgs, CustomList<E> element) {
        int index = Integer.valueOf(lineArgs[1]);
        E removedElement = element.removeElement(index);

        return removedElement.toString();
    }

    private static <E> String executeAddCommand(String[] lineArgs, CustomList<E> elements) {
        E elementToAdd = (E) lineArgs[1];
        elements.add(elementToAdd);

        return "";
    }
}