import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem1_DragonSharp {

    private static final String IF_LOOP_PATTERN = "if\\s+\\((\\d+)([=<>]+)(\\d+)\\)\\s+loop\\s+(\\d+)\\s+out\\s+\"(.+)\";";
    private static final String IF_OUT_PATTERN = "if\\s+\\((\\d+)([=<>]+)(\\d+)\\)\\s+out\\s\"(.+)\";";
    private static final String ELSE_LOOP_PATTERN = "else\\s+loop\\s+(\\d+)\\s+out\\s+\"(.+)\";";
    private static final String ELSE_OUT_PATTERN = "else\\s+out\\s+\"(.+)\";";

    public static boolean isTrue = true;

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int n = Integer.parseInt(input.nextLine());

        ArrayList<String> allText = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            allText.add(input.nextLine());
        }

        int lineNumber = hasCompileErrors(allText);
        if (lineNumber > 0) {
            System.out.printf("Compile time error @ line %d\n", lineNumber);
            return;
        }

        StringBuilder output = new StringBuilder();
        for (int i = 0; i < n; i++) {
            String line = allText.get(i);

            if (line.contains("if")) {
                if (line.contains("loop")) {
                    Pattern pattern = Pattern.compile(IF_LOOP_PATTERN);
                    Matcher matcher = pattern.matcher(line);

                    matcher.find();
                    boolean isComparisonTrue =
                            executeComparison(Integer.parseInt(matcher.group(1)), Integer.parseInt(matcher.group(3)), matcher.group(2));
                    if (isComparisonTrue) {
                        int count = Integer.parseInt(matcher.group(4));
                        for (int j = 0; j < count; j++) {
                            if (i + 1 == count) {
                                output.append(matcher.group(5));
                            } else {
                                output.append(matcher.group(5) + "\n");
                            }
                        }
                        isTrue = true;
                    } else {
                        isTrue = false;
                    }
                } else {
                    Pattern pattern = Pattern.compile(IF_OUT_PATTERN);
                    Matcher matcher = pattern.matcher(line);

                    matcher.find();
                    boolean isComparisonTrue =
                            executeComparison(Integer.parseInt(matcher.group(1)), Integer.parseInt(matcher.group(3)), matcher.group(2));
                    if (isComparisonTrue) {
                        output.append(matcher.group(4) + "\n");
                        isTrue = true;
                    } else {
                        isTrue = false;
                    }
                }
            } else {
                if (!isTrue) {
                    {
                        if (line.contains("loop")) {
                            Pattern pattern = Pattern.compile(ELSE_LOOP_PATTERN);
                            Matcher matcher = pattern.matcher(line);

                            matcher.find();
                            int count = Integer.parseInt(matcher.group(1));
                            for (int j = 0; j < count; j++) {
                                if (i + 1 == count) {
                                    output.append(matcher.group(2));
                                } else {
                                    output.append(matcher.group(2) + "\n");
                                }
                            }
                        } else {
                            Pattern pattern = Pattern.compile(ELSE_OUT_PATTERN);
                            Matcher matcher = pattern.matcher(line);

                            matcher.find();
                            output.append(matcher.group(1) + "\n");
                        }
                    }
                }
            }
        }

        System.out.println(output);
    }

    private static boolean executeComparison(int firstOperand, int secondOperand, String comparator) {
        switch (comparator) {
            case "==":
                return firstOperand == secondOperand;
            case "<":
                return firstOperand < secondOperand;
            case ">":
                return firstOperand > secondOperand;
        }

        return false;
    }

    private static int hasCompileErrors(ArrayList<String> allText) {
        int lineNumberCount = 1;

        for (int i = 0; i < allText.size(); i++) {
            String line = allText.get(i);

            if (line.contains("if")) {
                if (line.contains("loop")) {
                    Pattern pattern = Pattern.compile(IF_LOOP_PATTERN);
                    Matcher matcher = pattern.matcher(line);

                    if (matcher.find() == false) {
                        return lineNumberCount;
                    }
                } else {
                    Pattern pattern = Pattern.compile(IF_OUT_PATTERN);
                    Matcher matcher = pattern.matcher(line);

                    if (matcher.find() == false) {
                        return lineNumberCount;
                    }
                }
            } else {
                if (line.contains("loop")) {
                    Pattern pattern = Pattern.compile(ELSE_LOOP_PATTERN);
                    Matcher matcher = pattern.matcher(line);

                    if (matcher.find() == false) {
                        return lineNumberCount;
                    }
                } else {
                    Pattern pattern = Pattern.compile(ELSE_OUT_PATTERN);
                    Matcher matcher = pattern.matcher(line);

                    if (matcher.find() == false) {
                        return lineNumberCount;
                    }
                }
            }

            lineNumberCount++;
        }

        return -1;
    }
}