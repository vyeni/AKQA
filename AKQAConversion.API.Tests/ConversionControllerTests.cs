using AKQAConversion.API.Controllers;
using AKQAConversion.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AKQAConversion.API.Tests
{
    /// <summary>
    /// Tests the conversion controller method.
    /// </summary>
    [TestClass]
    public class ConversionControllerTests
    {
        Mock<ICaptureNumber> _captureNumber;
        ConversionController controller;

        /// <summary>
        /// Test Fixture
        /// </summary>
        public ConversionControllerTests()
        {
            _captureNumber = new Mock<ICaptureNumber>();
            _captureNumber.Setup(c => c.GetWords(12.44)).
                Returns("twelve dollars and fourty four cents");
        }

        /// <summary>
        /// Tests if Get method returns the expected result.
        /// </summary>
        [TestMethod]
        public void GetTestPassTest()
        {
            //Arrange 
            controller = new ConversionController(this._captureNumber.Object);

            //Act
            var response = controller.Get("John", "Smith", "12.44");

            //Assert
            Assert.AreEqual("twelve dollars and fourty four cents", response.AmountinText);
            Assert.AreEqual("John", response.FirstName);
            Assert.AreEqual("Smith", response.LastName);
            Assert.AreEqual(12.44, response.Amount);
        }

        [TestMethod]
        public void GetTestFailTest()
        {
            //Arrange 
            controller = new ConversionController(this._captureNumber.Object);

            //Act
            try
            {
                var response = controller.Get(null, null, " ");
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual("Input string was not in a correct format.", ex.Message);
            }

        }
    }
}
