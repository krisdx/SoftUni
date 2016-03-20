package Problem2_OneLevShop.Products;

import Problem2_OneLevShop.AgeRestriction;
import Problem2_OneLevShop.Interfaces.Buyable;

public abstract class Product implements Buyable{
    protected String name;
    protected double price;
    protected int quantity;
    protected AgeRestriction ageRestrinction;

    public Product(String name, int quantity, double price, AgeRestriction ageRestrinction) {
        this.name = name;
        this.quantity = quantity;
        this.price = price;
        this.ageRestrinction = ageRestrinction;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void saledProduct(){
        this.quantity--;
    }

    public AgeRestriction getAgeRestriction() {
        return ageRestrinction;
    }

    public void setAgeRestriction(AgeRestriction ageRestriction) {
        this.ageRestrinction = ageRestriction;
    }

    public int getQuantity() {
        return this.quantity;
    }

    public void setQuantity(int quantity) {
        if(quantity < 0){
            throw new IllegalArgumentException("The quantity of the product cannot be a negative number");
        }
        this.quantity = quantity;
    }

    public double price(){
        return this.price;
    }

    public void setPrice(double price) {
        if(price < 0){
            throw new IllegalArgumentException("The price of the product cannot be a negative number");
        }
        this.price = price;
    }
}