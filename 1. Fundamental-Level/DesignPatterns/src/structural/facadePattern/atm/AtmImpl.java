package structural.facadePattern.atm;

public class AtmImpl implements Atm {

	private static final int VALID_PIN_CODE = 1234;
	private static final int DAILY_DRAW_LIMIT = 1000;

	private int currentAmount;

	public AtmImpl() {
		this.currentAmount = DAILY_DRAW_LIMIT;
	}

	@Override
	public void draw(int desiredAmount, int givenPinCode) {

		if (VALID_PIN_CODE != givenPinCode) {
			System.out.println("Wrong pin code.");
			return;
		}

		if (this.currentAmount - desiredAmount < 0) {
			System.out.println("You have exceed the daily drawing amount. You can come again tommorow.");
			return;
		}

		this.currentAmount -= desiredAmount;
		System.out.println("You successfuly drawed: " + desiredAmount);
	}
}