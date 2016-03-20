package Problem2_OneLevShop;

public class Customer {
    private String name;
    private int age;
    private double balance;

    public Customer(String name, int age, double balance) {
        this.name = name;
        this.age = age;
        this.balance = balance;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        if (name.equals(" ") || name.equals(null)) {
            throw new IllegalArgumentException("The name of a person cannot be an empty string");
        }
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        if (age < 0) {
            throw new IllegalArgumentException("The age of a person cannot be a negative number");
        }
        this.age = age;
    }

    public double getBalance() {
        return balance;
    }

    public void setBalance(double balance) {
        if (balance < 0) {
            throw new IllegalArgumentException("The balance of a person cannot be a negative number");
        }
        this.balance = balance;
    }
}