using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using _8_Fibonacci;

namespace FibonacciTest
{
    [TestClass]
    public class InputValidatorTest
    {
        [TestMethod]
        public void TestUserInputValidatorExpectTrue()
        {
            //Arrange
            string[] inputStringArray = new string[] { "5", "8" };
            int methodOutputStart;
            int methodOutputEnd;

            //Act
            bool expectedOutput = InputValidator.ValidateUserInput(inputStringArray,
                out methodOutputStart, out methodOutputEnd);

            //Assert
            Assert.IsTrue(expectedOutput);
        }

        [TestMethod]
        [DataRow(new string[] { "a", "b" })]
        [DataRow(new string[] { "8", "" })]
        public void TestUserInputValidatorExpectFalse(string[] inputStringArray)
        {
            //Arrange            
            int methodOutputStart;
            int methodOutputEnd;

            //Act
            bool expectedOutput = InputValidator.ValidateUserInput(inputStringArray,
                out methodOutputStart, out methodOutputEnd);

            //Assert
            Assert.IsFalse(expectedOutput);
        }
    }
}
