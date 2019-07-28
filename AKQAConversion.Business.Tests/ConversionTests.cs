using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AKQAConversion.Business.Tests
{
    /// <summary>
    /// Tests for Conversion class
    /// </summary>
    [TestClass]
    public class ConversionTests
    {
        Conversion conversionObj;

        [TestMethod]
        public void c()
        {
            // Arrange
            conversionObj = new Conversion();

            // Act
            var result1 = conversionObj.NumberToString(12);
            var result2 = conversionObj.NumberToString(02);
            var result3 = conversionObj.NumberToString(00);
            var result4 = conversionObj.NumberToString(0);

            // Assert
            Assert.AreEqual("twelve", result1);
        }

        [TestMethod]
        public void ConvertNumberToStringZeroTest()
        {
            // Arrange
            conversionObj = new Conversion();

            // Act
            var result1 = conversionObj.NumberToString(-0);

            // Assert
            Assert.AreEqual("zero", result1);
        }


        /// <summary>
        /// Negative number test
        /// </summary>
        [TestMethod]
        public void ConvertNumberToStringNegativeNumberTest()
        {
            // Arrange
            conversionObj = new Conversion();

            // Act
            var result1 = conversionObj.NumberToString(-12);


            // Assert
            Assert.AreEqual("minus twelve", result1);
        }
    }
}
