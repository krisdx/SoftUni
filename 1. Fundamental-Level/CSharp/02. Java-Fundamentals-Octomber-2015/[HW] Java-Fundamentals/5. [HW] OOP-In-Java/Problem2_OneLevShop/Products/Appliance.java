package Problem2_OneLevShop.Products;

import Problem2_OneLevShop.AgeRestriction;

import java.util.Date;

public class Appliance extends ElectonicsProduct {
    public Appliance(String name, double price, int quantity, AgeRestriction ageRestriction) {
        super(name, quantity, price, ageRestriction);
        this.guaranteePeriod = new Date(new Date().getYear(), new Date().getMonth() + 6, new Date().getDate());
    }

    @Override
    public double getPrice() {
        double price = this.price;
        if (this.getQuantity() < 50) {
            price *= 1.05;
        }
        return price;
    }
}