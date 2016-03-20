package Problem2_OneLevShop.Exceptions;

public class ProductExpiredException extends Exception {
    public ProductExpiredException() {
        super("The product has expired");
    }
}