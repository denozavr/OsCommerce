using Microsoft.VisualStudio.TestTools.UnitTesting;
using Os.BusinessLayer;

namespace Os.BusinessTests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void PrintProductTest()
        {
            //arrange
            var product = new Product
            {
                ProductName = "Ladder",
                ProductId = 1,
                Description = "10 feet",
                ProductVendor = {CompanyName = "NanoSoft"}

            };
            var expected = "It's Ladder (1): 10 feet" + " Available on: ";
            
            //act
            var actual = product.PrintProduct();

            //assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void PrintProductTestWithParamConstructor()
        {
            //arrange
            var product = new Product(1,"Ladder","10 feet");
            var expected = "It's Ladder (1): 10 feet" + " Available on: ";
            //act
            var actual = product.PrintProduct();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_Null()
        {
            //Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            //Act
            var actual = companyName;

            //Assert
            Assert.AreEqual(expected, actual);
        }


    }
}

