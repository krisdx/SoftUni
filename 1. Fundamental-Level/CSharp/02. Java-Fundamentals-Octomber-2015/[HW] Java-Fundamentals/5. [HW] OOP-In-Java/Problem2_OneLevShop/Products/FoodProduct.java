package Problem2_OneLevShop.Products;

import Problem2_OneLevShop.AgeRestriction;
import Problem2_OneLevShop.Interfaces.Expirable;

import java.util.Date;

public class FoodProduct extends Product implements Expirable{
    private Date productionDate;

    public FoodProduct(String name, int quantity, double price, AgeRestriction ageRestrinction) {
        super(name, quantity, price, ageRestrinction);
        this.productionDate = new Date(new Date().getYear(), new Date().getMonth(), new Date().getDate() - 10);
    }

    @Override
    public double getPrice() {
        double currentPrice = this.price;
        if(new Date().getDate() > this.getExpirationDate().getDate() - 15){
            currentPrice *= 0.7;
        }
        return currentPrice;
    }

    @Override
    public Date getExpirationDate() {
        return new Date(productionDate.getYear(), productionDate.getMonth() + 1, productionDate.getDate());
    }
}