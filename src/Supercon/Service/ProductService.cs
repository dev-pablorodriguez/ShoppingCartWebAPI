using System;
using System.Linq;
using System.Collections.Generic;
using Supercon.Model;

namespace Supercon.Service
{
    public class ProductService
    {
        // Simple source of products: would come from a database in the real world.
        private static readonly List<Product> AllProducts = new List<Product>
        {
            new Product(24.99, "CHAIR_RED", "Red plastic chair"),
            new Product(24.99, "DIS_10-CHAIR_BLUE", "Blue plastic chair"),
            new Product(24.99, "CHAIR_WHITE", "White plastic chair"),
            new Product(14.99, "STOOL_WHITE", "White plastic footstool"),
            new Product(14.99, "DIS_15-STOOL_GREEN", "Green plastic footstool"),
            new Product(74.99, "COMP_DESK", "Wooden computer desk"),
            new Product(129.99, "COMP_CHAIR", "Computer swivel chair"),
            new Product(249.99, "BOARD_TABLE", "12-person boardroom table"),
            new Product(99.99, "BOARD_CHAIR", "Boardroom chair")
        };

        private List<Product> products;

        public ProductService()
        {
            this.products = AllProducts;
        }

        public ProductService(List<Product> products)
        {
            this.products = products;
        }

        public List<string> GetProductCodes()
        {
            return products
                       .Select(p => p.ProductCode)
                       .ToList();
        }

        public Product GetProduct(string code)
        {
            foreach (var product in products)
            {
                if (product.ProductCode == code)
                {
                    return product;
                }
            }
            return null;
        }

    }
}
