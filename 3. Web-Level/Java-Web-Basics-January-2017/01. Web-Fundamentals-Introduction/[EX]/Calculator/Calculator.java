import java.io.IOException;

public class Calculator {
	
	public static void main(String[] args) throws IOException {
		System.out.println("Content-Type: text/html\n\n");
		System.out.println(WebUtils.readFile("/var/www/cgi/Calculator/calculator.html"));
		
		Object[] params = WebUtils.getParameters().values().toArray();
		
		double num1;
		double num2;
		try {
			num1 = Double.valueOf(params[0].toString());
			num2 = Double.valueOf(params[2].toString());
		} catch (NumberFormatException e) {
			System.out.println("Invalid number");
			return;
		}
		
		String sign = params[1].toString();
		switch (sign) {
			case "+":
				System.out.println("Result: " + (num1 + num2));
				break;
			case "-":
				System.out.println("Result: " + (num1 - num2));
				break;
			case "*":
				System.out.println("Result: " + (num1 * num2));
				break;
			case ":":
				System.out.println("Result: " + (num1 / num2));
				break;
			default: 
				System.out.println("Invalid sign");
				break;
		}
	}
}