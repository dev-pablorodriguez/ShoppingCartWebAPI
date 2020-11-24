using System;
using System.Collections.Generic;
using System.Linq;
using Supercon.Service;

namespace Supercon.Model
{

    public class ShoppingCart
    {
        //Product and quantity
        private IList<Product> products;
        private Customer customer;
        private string cartState;

        public void SetOrderService(OrderService orderService)
        {
            this.orderService = orderService;
        }

        private OrderService orderService = new OrderService();

        public ShoppingCart(Customer customer, IList<Product> products, string cartState)
        {
            this.customer = customer;
            this.products = products;
            this.cartState = cartState;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }


        /*
            Checkout: Calculates total price and total loyalty points earned by the customer.
            Products with product code starting with DIS_10 have a 10% discount applied.
            Products with product code starting with DIS_15 have a 15% discount applied.

            Loyalty points are earned more when the product is not under any offer.
                Customer earns 1 point on every $5 purchase.
                Customer earns 1 point on every $10 spent on a product with 10% discount.
                Customer earns 1 point on every $15 spent on a product with 15% discount.
        */

        public void Checkout()
        {
            double totalPrice = 0;
            int loyaltyPointsEarned = 0;

            foreach (Product product in products)
            {
                double discount = 0;
                if (product.ProductCode.StartsWith("DIS_10", System.StringComparison.OrdinalIgnoreCase))
                {
                    discount = (product.Price * 0.1);
                    loyaltyPointsEarned += (int)(product.Price / 10);
                }
                else if (product.ProductCode.StartsWith("DIS_15", System.StringComparison.OrdinalIgnoreCase))
                {
                    discount = (product.Price * 0.15);
                    loyaltyPointsEarned += (int)(product.Price / 15);
                }
                else
                {
                    loyaltyPointsEarned += (int)(product.Price / 5);
                }

                //En la mayoría de retails los descuentos no son acumulables.
                //En caso de que un producto tenga varios descuentos se aplican el más alto.
                //Esa lógica se implementó aquí. Si es silla plástica el descuento del 20% será aplicado por sobre el descuento del código de producto.
                if (product.Name.Contains("plastic chair"))
                {
                    discount = (product.Price * 0.2);
                }

                totalPrice += product.Price - discount;
            }

            //Evalúa si aplica descuento por promoción de mesa+silla
            //obtiene cantidad de sillas de la compra
            int cantSillas = products.Where(p => p.ProductCode.Contains("CHAIR")).ToList().Count;

            //obtiene cantidad de mesas de la compra
            int cantMesas = products.Where(p => p.ProductCode.Contains("TABLE")).ToList().Count;

            //obtiene la cantidad total de promociones de la lista de productos
            int totalPromos = Math.Min(cantSillas, cantMesas);

            //por cada promoción llevada realiza un descuento de $20
            totalPrice -= totalPromos * 20;



            //Si la compra supera los $1000 realiza un descuento del 10%
            if (totalPrice > 1000) totalPrice *= 0.9;

            orderService.ShowConfirmation(customer, products, totalPrice, loyaltyPointsEarned);
        }

    }
}
