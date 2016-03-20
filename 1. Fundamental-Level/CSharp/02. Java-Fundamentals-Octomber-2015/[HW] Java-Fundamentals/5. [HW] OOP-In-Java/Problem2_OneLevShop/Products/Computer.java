package Problem2_OneLevShop.Products;

import Problem2_OneLevShop.AgeRestriction;

import java.util.Date;

public class Computer extends ElectonicsProduct{

    public Computer(String name, int quantity, double price, AgeRestriction ageRestriction) {
        super(name, quantity, price, ageRestriction);
    }

    @Override
    public double getPrice() {
        double price = this.price;
        if(this.getQuantity() > 1000) {
            price *= 0.95;
        }
        return price;
    }
}
