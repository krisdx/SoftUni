package behavioral.mementoPattern;

import java.util.concurrent.SynchronousQueue;

import behavioral.mementoPattern.models.Memento;
import behavioral.mementoPattern.models.originator.SalesProspect;
import behavioral.mementoPattern.models.originator.SalesProspectImpl;

public class Main {

	public static void main(String[] args) {

		/**
		 * Memento pattern captures(wthout violating encapsulation) an object's
		 * internal state so that the object can be returned to this state
		 * later.
		 */

		SalesProspect sale = new SalesProspectImpl("Noel van Halen", "(412) 256-0990)", 245.54);
		System.out.println("When created: ");
		System.out.println(sale);
		Memento memento = sale.saveMemento();

		sale.setBudget(20.0);
		sale.setName("");
		sale.setPhone("123");

		System.out.println("When changed: ");
		System.out.println(sale);

		System.out.println("When restored: ");
		sale.restore(memento);
		System.out.println(sale);
	}
}