using System.Collections.Generic;
using Supercon.Model;

namespace Supercon.Service
{
    public class ShoppingCartService
    {
        public void Checkout(Customer customer, IList<Product> products)
        {
            ShoppingCart cart = new ShoppingCart(customer, products, "OPEN");
            cart.Checkout();
        }
    }
}