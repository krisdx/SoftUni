package behavioral.interpreterPattern.models;

public class Context {

	private String input;
	private int output;

	public Context(String input) {
		this.input = input;
	}

	public String getInput() {
		return this.input;
	}

	public void setInput(String input) {
		this.input = input;
	}

	public int getOutput() {
		return this.output;
	}

	public void setOutput(int output) {
		this.output = output;
	}
}