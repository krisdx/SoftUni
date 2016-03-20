import java.util.Scanner;

public class Problem3_PlaidTowel {
    public static void main(String[] args) {
        StringBuilder output = new StringBuilder();

        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        char backgroundSymbol = input.next().charAt(0);
        char rhombusSymbol = input.next().charAt(0);

        String  staticUpperAndLowerLine  =  String.format("%s%s%s%s%s",
                createString(backgroundSymbol, n),
                rhombusSymbol,
                createString(backgroundSymbol, (n * 2) - 1),
                rhombusSymbol,
                createString(backgroundSymbol, n));
        String staticMiddleLine  = String.format("%s%s%s%s%s",
                rhombusSymbol,
                createString(backgroundSymbol, n * 2 - 1),
                rhombusSymbol,
                createString(backgroundSymbol, n * 2 - 1),
                rhombusSymbol);

        System.out.println(staticUpperAndLowerLine);

        int sideDotsCounter = n-1;
        int middleDotsCounter = (n * 2) - 3;
        int insideDotsCounter = 1;
        for (int i = 0; i < n - 1; i++) {
            String sideDots = createString(backgroundSymbol, sideDotsCounter);
            String middleDots = createString(backgroundSymbol, middleDotsCounter);
            String insideDots = createString(backgroundSymbol, insideDotsCounter);
            output.append(String.format("%s%s%s%s%s%s%s%s%s\n", sideDots, rhombusSymbol,insideDots, rhombusSymbol, middleDots, rhombusSymbol, insideDots, rhombusSymbol, sideDots));
            insideDotsCounter+=2;
            sideDotsCounter--;
            middleDotsCounter-=2;
        }
        System.out.print(output);
        System.out.println(staticMiddleLine);
        sideDotsCounter = 1;
        middleDotsCounter = 1;
        insideDotsCounter = ((n * 2) - 1) - 2;
        for (int i = 0; i < n - 1; i++) {
            String sideDots = createString(backgroundSymbol, sideDotsCounter);
            String middleDots = createString(backgroundSymbol, middleDotsCounter);
            String insideDots = createString(backgroundSymbol, insideDotsCounter);
            System.out.printf("%s%s%s%s%s%s%s%s%s\n", sideDots, rhombusSymbol,insideDots, rhombusSymbol, middleDots, rhombusSymbol, insideDots, rhombusSymbol, sideDots);
            insideDotsCounter-=2;
            sideDotsCounter++;
            middleDotsCounter+=2;
        }
        System.out.println(staticUpperAndLowerLine);

        sideDotsCounter = n-1;
        middleDotsCounter = (n * 2) - 3;
        insideDotsCounter = 1;
        for (int i = 0; i < n - 1; i++) {
            String sideDots = createString(backgroundSymbol, sideDotsCounter);
            String middleDots = createString(backgroundSymbol, middleDotsCounter);
            String insideDots = createString(backgroundSymbol, insideDotsCounter);
            System.out.printf("%s%s%s%s%s%s%s%s%s\n", sideDots, rhombusSymbol,insideDots, rhombusSymbol, middleDots, rhombusSymbol, insideDots, rhombusSymbol, sideDots);
            insideDotsCounter+=2;
            sideDotsCounter--;
            middleDotsCounter-=2;
        }
        System.out.println(staticMiddleLine);
        sideDotsCounter = 1;
        middleDotsCounter = 1;
        insideDotsCounter = ((n * 2) - 1) - 2;
        for (int i = 0; i < n - 1; i++) {
            String sideDots = createString(backgroundSymbol, sideDotsCounter);
            String middleDots = createString(backgroundSymbol, middleDotsCounter);
            String insideDots = createString(backgroundSymbol, insideDotsCounter);
            System.out.printf("%s%s%s%s%s%s%s%s%s\n", sideDots, rhombusSymbol,insideDots, rhombusSymbol, middleDots, rhombusSymbol, insideDots, rhombusSymbol, sideDots);
            insideDotsCounter-=2;
            sideDotsCounter++;
            middleDotsCounter+=2;
        }
        System.out.println(staticUpperAndLowerLine);
    }

    private static String createString(char symbol, int count) {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < count; i++) {
            result.append(symbol);
        }

        return result.toString();
    }
}