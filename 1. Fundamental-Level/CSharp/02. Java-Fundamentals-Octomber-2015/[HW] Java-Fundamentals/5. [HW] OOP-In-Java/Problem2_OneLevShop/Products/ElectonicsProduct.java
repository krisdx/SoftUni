package Problem2_OneLevShop.Products;

import Problem2_OneLevShop.AgeRestriction;
import Problem2_OneLevShop.Interfaces.Expirable;

import java.util.Date;

public abstract class ElectonicsProduct extends Product  {
    protected Date guaranteePeriod;

    public ElectonicsProduct(String name, int quantity, double price, AgeRestriction ageRestriction) {
        super(name, quantity, price, ageRestriction);
    }
}