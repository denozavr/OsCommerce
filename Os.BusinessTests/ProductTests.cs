﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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


        [TestMethod()]
        public void ConvertMetersToInches()
        {
            //arrange
            var expected = 78.74;
            
            //act
            var actual = 2*Product.InchesInMeter;

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void MinimumPriceDefault()
        {
            //arrange
            var currentProduct = new Product();
            var expected = .96m;

            //act
            var actual = currentProduct.MinPrice;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceBulk()
        {
            //arrange
            var currentProduct = new Product(1,"Bulk Test","");
            var expected = 9.99m;

            //act
            var actual = currentProduct.MinPrice;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_Format()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.ProductName = " Screwdriver     ";

            var expected = "Screwdriver";

            //act
            var actual = currentProduct.ProductName;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_TooShort()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "it";

            string expected = null;
            string expectedMessage = "Product Name must be at least 3 characters";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ErrorMessage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void ProductName_TooLong()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Steel Bladed Hand Saw For Very Big Trees";

            string expected = null;
            string expectedMessage = "Product Name cannot be more than 30 characters";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ErrorMessage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void ProductName_JustRight()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Hammer";

            string expected = "Hammer";
            string expectedMessage = null;

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ErrorMessage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }


        [TestMethod()]
        public void Category_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();

            var expected = "Home";

            //Act
            var actual = currentProduct.Category;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductCode_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product() {SequenceNumber = 232, Category = "Nails"};
            

            var expected = "Nails-232";

            //Act
            var actual = currentProduct.ProductCode;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateSuggestedPriceTest()
        {
            // Arrange
            var currentProduct = new Product(1, "Nails", "");
            currentProduct.Cost = 20m;
            var expected = 22m;

            // Act
            var actual = currentProduct.CalculateSuggestedPrice(10m);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

