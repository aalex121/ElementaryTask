using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _5_NumberToString;

namespace NumberToStringTest
{
    [TestClass]
    public class NumberToStringTranslatorTest
    {
        [TestMethod]
        [DataRow(12012, "twelve thousand twelve")]
        [DataRow(-120102, "minus one hundred twenty thousand one hundred two")]
        [DataRow(0, "zero")]
        public void TestNumberToStringTranslator(int input, string expected)
        {
            //Arrange
            NumberToStringTranslator translator = new NumberToStringTranslator(input);

            //Act
            string actual = translator.NumberStringValue;
            Console.WriteLine(actual);
            Console.WriteLine(expected);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
