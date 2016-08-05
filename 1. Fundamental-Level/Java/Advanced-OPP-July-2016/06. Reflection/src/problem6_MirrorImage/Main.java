package problem6_MirrorImage;

import problem6_MirrorImage.constracts.Wizard;
import problem6_MirrorImage.core.CustomBinaryTree;
import problem6_MirrorImage.wizards.WizardImpl;

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

        String[] initialWizardArgs = reader.readLine().split("\\s+");
        String name = initialWizardArgs[0];
        int magicPower = Integer.valueOf(initialWizardArgs[1]);
        Wizard initialWizard = new WizardImpl(name, magicPower);

        CustomBinaryTree customBinaryTree = new CustomBinaryTree();
        customBinaryTree.addInitialWizard(initialWizard);

        while (true) {
            String line = reader.readLine();
            if (line.equalsIgnoreCase("end")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            String command = lineArgs[1];
            int id = Integer.valueOf(lineArgs[0]);
            if (command.equalsIgnoreCase("reflection")) {
                customBinaryTree.reflect(id);
            } else if (command.equalsIgnoreCase("fireball")) {
                customBinaryTree.fireBall(id);
            }
        }
    }
}