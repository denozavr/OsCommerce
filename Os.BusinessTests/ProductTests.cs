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
            var product = new Product() {ProductName = "Ladder", ProductId = 1, Description = "10 feet"};
            var expected = "It's Ladder (1): 10 feet";
            //act
            var actual = product.PrintProduct();

            //assert
            Assert.AreEqual(expected,actual);
        }
    }
}

