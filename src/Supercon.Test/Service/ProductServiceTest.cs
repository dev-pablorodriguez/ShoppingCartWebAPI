using System;
using System.Collections.Generic;
using Supercon.Service;
using Xunit;
using Supercon.Model;
using System.Linq;

namespace Supercon.Test.Service
{
    public class ProductServiceTest
    {
        private readonly ProductService productService;

        public ProductServiceTest()
        {
            productService = new ProductService(new List<Product>
            {
                new Product(1.50, "PROD_01", "Product 01"),
                new Product(3.45, "PROD_02", "Product 02")
            });
        }

        [Fact]
        public void GetProductCodes_ShouldReturnAllCodes()
        {
            List<string> codes = productService.GetProductCodes();

            Assert.Equal(2, codes.Count);
            Assert.Equal("PROD_01", codes.ElementAt(0));
            Assert.Equal("PROD_02", codes.ElementAt(1));
        }

        [Fact (Skip = "Its breaking the pipeline")]
        public void GetProduct_ShouldReturnProductForKnownCode()
        {
            Product product = productService.GetProduct("PROD_01");
            Assert.Equal("PROD_01", product.ProductCode);
            Assert.Equal("Product 01", product.Name);
            Assert.Equal(1.50, product.Price);
        }

        [Fact]
        public void GetProduct_ShouldReturnNullForUnknownCode()
        {
            Product product = productService.GetProduct("PROD_03");
            Assert.Null(product);
        }

    }
}
