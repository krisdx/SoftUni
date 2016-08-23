package structural.compositePattern;

import structural.compositePattern.models.Employee;
import structural.compositePattern.models.Intern;
import structural.compositePattern.models.JuniorDeveloper;
import structural.compositePattern.models.Manager;

public class Main {

	public static void main(String[] args) {
		
		Employee qaManager = new Manager("Hristo");
		Employee qaSeniorDeveloper = new Manager("Qnko");
		qaManager.add(qaSeniorDeveloper);
		qaManager.add(new JuniorDeveloper("Pesho"));
		qaManager.add(new JuniorDeveloper("Gosho"));
		qaManager.add(new JuniorDeveloper("Tosho"));
		qaSeniorDeveloper.add(new Intern("Kristiyan"));
		
		Employee frontEndManager = new Manager("Stanislav");
		Employee frontEndSeniorDeveloper = new Manager("Nikifor");
		frontEndManager.add(frontEndSeniorDeveloper);
		frontEndManager.add(new JuniorDeveloper("Bobi"));
		frontEndManager.add(new JuniorDeveloper("Angel"));
		frontEndManager.add(new JuniorDeveloper("Ilian"));
		frontEndSeniorDeveloper.add(new Intern("Mariq"));
		
		Employee backEndManager = new Manager("Georgri");
		Employee backEndSeniorDeveloper = new Manager("Iordan");
		backEndManager.add(backEndSeniorDeveloper);
		backEndManager.add(new JuniorDeveloper("Petur"));
		backEndManager.add(new JuniorDeveloper("Aleksandur"));
		backEndManager.add(new JuniorDeveloper("Rosen"));
		backEndSeniorDeveloper.add(new Intern("Rado"));
		
		System.out.println("QA's: ");
		qaManager.display(1);
		System.out.println();
		
		System.out.println("Fron-End Developers: ");
		frontEndManager.display(1);
		System.out.println();
		
		System.out.println("Back-End Developers: ");
		backEndManager.display(1);
		System.out.println();
		
	}
}