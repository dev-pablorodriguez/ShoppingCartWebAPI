using System.Collections.Generic;

namespace Supercon.Model
{
    public class Order: ShoppingCart
    {
        public Order(Customer customer, IList<Product> products):base(customer, products, "ORDER_PLACED")
        {
        }
    }
}
