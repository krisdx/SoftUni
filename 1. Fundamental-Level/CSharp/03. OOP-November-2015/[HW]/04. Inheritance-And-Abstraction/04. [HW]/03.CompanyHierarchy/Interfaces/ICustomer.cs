﻿namespace CompanyHierarchy.Interfaces
{
    public interface ICustomer
    {
        decimal PurchasesAmmount { get; set; }

        void AddPurchasePrice(decimal purchasePrice);
    }
}