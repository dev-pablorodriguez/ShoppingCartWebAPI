using System.Collections.Generic;
using Supercon.Model;

namespace Supercon.Service
{
    public class OrderService
    {
        public virtual void ShowConfirmation(Customer customer, IList<Product> products, double totalPrice, int loyaltyPointsEarned)
        {
            //show confirmation
            //do some calculations and formatting on the shopping cart data and ask user for confirmation
            //after confirmation redirect to place order
        }

        public ShoppingCart PlaceOrder(Customer customer, IList<Product> products)
        {
            //place order
            return new Order(customer, products);
        }

    }
}