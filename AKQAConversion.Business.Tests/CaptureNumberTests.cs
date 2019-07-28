using Microsoft.VisualStudio.TestTools.UnitTesting;
using AKQAConversion.Business;
using Moq;

namespace AKQAConversion.Business.Tests
{
    /// <summary>
    /// Tests for CaptureNumber
    /// </summary>
    [TestClass]
    public class CaptureNumberTests
    {
        Mock<IConversion> _conversion;
        CaptureNumber getNumber;

        /// <summary>
        /// Test Fixtures
        /// </summary>
        public CaptureNumberTests()
        {
            _conversion = new Mock<IConversion>();
            _conversion.Setup(c => c.NumberToString(12)).Returns("twelve");
            _conversion.Setup(c => c.NumberToString(2)).Returns("two");
            _conversion.Setup(c => c.NumberToString(00)).Returns("zero");
            _conversion.Setup(c => c.NumberToString(0)).Returns("zero");
            _conversion.Setup(c => c.NumberToString(1)).Returns("one");
            _conversion.Setup(c => c.NumberToString(01)).Returns("one");

        }

        /// <summary>
        /// Basic  to check different input and output results.
        /// </summary>
        [TestMethod]
        public void ConvertNumberToStringPassTest()
        {
            // Arrange
            getNumber = new CaptureNumber(_conversion.Object);

            // Act
            var result1 = getNumber.GetWords(12.02);
            var result2 = getNumber.GetWords(12);
            var result3 = getNumber.GetWords(.02);
            var result4 = getNumber.GetWords(12.00);
            var result5 = getNumber.GetWords(00.02);

            // Assert
            Assert.AreEqual("twelve dollars and two cents", result1);
            Assert.AreEqual("twelve dollars", result2);
            Assert.AreEqual("zero dollars and two cents", result3);
            Assert.AreEqual("twelve dollars", result4);
            Assert.AreEqual("zero dollars and two cents", result5);
        }

        /// <summary>
        /// Check for dollar/dollars/cent/cents assignments.
        /// </summary>
        [TestMethod]
        public void ConvertNumberToStringOneDollarOneCentCheck()
        {
            // Arrange
            getNumber = new CaptureNumber(_conversion.Object);

            // Act
            var result1 = getNumber.GetWords(01.1);
            var result2 = getNumber.GetWords(01);
            var result3 = getNumber.GetWords(0.1);
            var result4 = getNumber.GetWords(2.0);
            var result5 = getNumber.GetWords(0.2);

            //Assert
            Assert.AreEqual("one dollar and one cent", result1);
            Assert.AreEqual("one dollar", result2);
            Assert.AreEqual("zero dollars and one cent", result3);
            Assert.AreEqual("two dollars", result4);
            Assert.AreEqual("zero dollars and two cents", result5);
        }
    }

}
