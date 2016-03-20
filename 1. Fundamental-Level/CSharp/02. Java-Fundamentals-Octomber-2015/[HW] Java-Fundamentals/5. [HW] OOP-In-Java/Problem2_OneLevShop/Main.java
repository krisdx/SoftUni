package Problem2_OneLevShop;

import Problem2_OneLevShop.Exceptions.NoMoneyException;
import Problem2_OneLevShop.Exceptions.NoPermissionException;
import Problem2_OneLevShop.Exceptions.NoQuantityException;
import Problem2_OneLevShop.Exceptions.ProductExpiredException;
import Problem2_OneLevShop.Products.FoodProduct;

public class Main {
    public static void main(String[] args) {
        FoodProduct cigars = new FoodProduct("Hrana", 6, 50, AgeRestriction.Adult);
        Customer customer = new Customer("Pesho", 17, 30.00);{
            try {
                PurchaseManager.processPurchase(customer, cigars);
            } catch (NoPermissionException e) {
                e.printStackTrace();
            } catch (NoMoneyException e) {
                e.printStackTrace();
            } catch (NoQuantityException e) {
                e.printStackTrace();
            } catch (ProductExpiredException e) {
                e.printStackTrace();
            }
        }

        Customer customer2 = new Customer("Gosho", 18, 19);{
            try {
                PurchaseManager.processPurchase(customer2, cigars);
            } catch (NoPermissionException e) {
                e.printStackTrace();
            } catch (NoMoneyException e) {
                e.printStackTrace();
            } catch (NoQuantityException e) {
                e.printStackTrace();
            } catch (ProductExpiredException e) {
                e.printStackTrace();
            }
        }
    }
}