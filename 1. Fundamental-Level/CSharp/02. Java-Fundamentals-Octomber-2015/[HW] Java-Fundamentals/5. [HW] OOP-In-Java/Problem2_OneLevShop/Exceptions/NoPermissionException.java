package Problem2_OneLevShop.Exceptions;

public class NoPermissionException extends Exception {
    public NoPermissionException() {
        super("You are too young to buy this product!");
    }
}