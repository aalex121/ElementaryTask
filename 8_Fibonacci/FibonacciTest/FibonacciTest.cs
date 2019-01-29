﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using _8_Fibonacci;

namespace FibonacciTest
{
    [TestClass]
    public class FibonacciRowGenerationTest
    {
        private FibonacciRow _testRow;
        private SortedSet<int> _expectedRow;

        [TestInitialize]
        public void TestInitialize()
        {
            _testRow = new FibonacciRow();        
        }

        [TestMethod]
        public void TestPositiveRowGenerationExpectPositiveRow1To8()
        {
            //Arrange
            int testLimitPositive = 8;
            _expectedRow = new SortedSet<int> { 1, 2, 3, 5, 8 };
            bool isSame = false;            

            //Act            
            SortedSet<int> actualRow = _testRow.GenerateFibonacciRow(1, testLimitPositive);
            isSame = _expectedRow.SetEquals(actualRow);

            //Assert            
            Assert.IsTrue(isSame);
        }

        [TestMethod]
        public void TestNegativeRowGenerationExpectNegativeRow1To8()
        {
            //Arrange
            int testLimitNegative = -8;
            _expectedRow = new SortedSet<int> { -1, -2, -3, -5, -8 };
            bool isSame = false;

            //Act            
            SortedSet<int> actualRow = _testRow.GenerateFibonacciRow(-1, testLimitNegative);
            isSame = _expectedRow.SetEquals(actualRow);

            //Assert            
            Assert.IsTrue(isSame);
        }

        [TestMethod]
        public void TestMixedRowGenerationExpectMixedRowMinus8To8()
        {
            //Arrange
            int testLimitPositive = 8;
            int testLimitNegative = -8;
            _expectedRow = new SortedSet<int> { -1, -2, -3, -5, -8, 1, 2, 3, 5, 8 };
            bool isSame = false;

            //Act            
            SortedSet<int> actualRow = _testRow.GenerateFibonacciRow(testLimitPositive, testLimitNegative);
            isSame = _expectedRow.SetEquals(actualRow);

            //Assert            
            Assert.IsTrue(isSame);
        }
    }

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