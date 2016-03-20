package Problem2_OneLevShop.Exceptions;

public class NoMoneyException extends Exception{
    public NoMoneyException(){
        super("You do not have enough money to buy this product!");
    }
}