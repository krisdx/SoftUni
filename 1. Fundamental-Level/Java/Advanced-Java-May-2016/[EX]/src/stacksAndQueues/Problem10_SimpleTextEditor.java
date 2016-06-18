package stacksAndQueues;

import java.util.Scanner;
import java.util.Stack;

public class Problem10_SimpleTextEditor {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Stack<Character> text = new Stack<>();
        int n = Integer.valueOf(input.nextLine());
        Stack<EraseCommand> lastEraseCommands = new Stack<>();
        Stack<AppendCommand> lastApendCommands = new Stack<>();
        Stack<Integer> lastCommands = new Stack<>();
        for (int i = 0; i < n; i++) {
            String[] commandArgs = input.nextLine().split(" ");
            int type = Integer.valueOf(commandArgs[0]);
            if (type == 1) {
                String stringToAppend = commandArgs[1];
                for (int j = 0; j < stringToAppend.length(); j++) {
                    text.push(stringToAppend.charAt(j));
                }

                AppendCommand appendCommand = new AppendCommand(stringToAppend.length());
                lastApendCommands.push(appendCommand);
                lastCommands.push(1);

            } else if (type == 2) {
                int count = Integer.valueOf(commandArgs[1]);
                String lastErasedText = "";
                for (int j = 0; j < count; j++) {
                    lastErasedText += text.pop();
                }
                lastErasedText = new StringBuffer(lastErasedText).reverse().toString();

                EraseCommand eraseCommand = new EraseCommand(lastErasedText);
                lastEraseCommands.push(eraseCommand);
                lastCommands.push(2);
            } else if (type == 3) {
                int indexToFind = Integer.valueOf(commandArgs[1]);
                int currentIndex = 0;
                for (Character symbol : text) {
                    if (currentIndex == indexToFind - 1) {
                        System.out.println(symbol);
                        break;
                    }

                    currentIndex++;
                }
            } else if (type == 4) {
                int lastCommand = lastCommands.pop();
                if (lastCommand == 1) {
                    AppendCommand appendCommand =  lastApendCommands.pop();
                    for (int j = 0; j < appendCommand.count; j++) {
                        text.pop();
                    }
                } else {
                    EraseCommand eraseCommand =  lastEraseCommands.pop();
                    for (int j = 0; j < eraseCommand.lastAppendedText.length(); j++) {
                        text.push(eraseCommand.lastAppendedText.charAt(j));
                    }
                }
            }
        }
    }
}

class EraseCommand {
    public String lastAppendedText;

    public EraseCommand(String lastAppendedText) {
        this.lastAppendedText = lastAppendedText;
    }
}

class AppendCommand {
    public int count;

    public AppendCommand(int count) {
        this.count = count;
    }
}