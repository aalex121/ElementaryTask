using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using _8_Fibonacci;

namespace FibonacciTest
{
    [TestClass]
    public class FibonacciRowGenerationTest
    {
        private FibonacciRow _testRow;
        private int[] _expectedRow;

        [TestInitialize]
        public void TestInitialize()
        {
            _testRow = new FibonacciRow();
        }

        [TestMethod]
        public void TestPositiveRowGenerationExpectPositiveRow0To8()
        {
            //Arrange
            int testLimitPositive = 8;
            _expectedRow = new int[] { 0, 1, 1, 2, 3, 5, 8 };
            bool isSame = false;

            //Act            
            IEnumerable<int> actualRow = _testRow.GenerateFibonacciRow(0, testLimitPositive);
            isSame = CheckNumberRowEquality(_expectedRow, actualRow);

            //Assert            
            Assert.IsTrue(isSame);
        }

        [TestMethod]
        public void TestNegativeRowGenerationExpectNegativeRow8To1()
        {
            //Arrange
            int testLimitNegative = -8;
            _expectedRow = new int[] { -8, -5, -3, -2, -1, -1 };
            bool isSame = false;

            //Act            
            IEnumerable<int> actualRow = _testRow.GenerateFibonacciRow(-1, testLimitNegative);
            isSame = CheckNumberRowEquality(_expectedRow, actualRow);

            //Assert            
            Assert.IsTrue(isSame);
        }

        [TestMethod]
        public void TestMixedRowGenerationExpectMixedRowMinus8To8()
        {
            //Arrange
            int testLimitPositive = 8;
            int testLimitNegative = -8;
            _expectedRow = new int[] { -8, -5, -3, -2, -1, -1, 0, 1, 1, 2, 3, 5, 8 };
            bool isSame = false;

            //Act            
            IEnumerable<int> actualRow = _testRow.GenerateFibonacciRow(testLimitNegative, testLimitPositive);
            isSame = CheckNumberRowEquality(_expectedRow, actualRow);

            //Assert            
            Assert.IsTrue(isSame);
        }

        private bool CheckNumberRowEquality(int[] expectedRow, IEnumerable<int> actualRow)
        {
            bool areEqual = true;
            int position = 0;

            foreach (int item in actualRow)
            {
                if (item != expectedRow[position])
                {
                    areEqual = false;
                    break;
                }

                position++;
            }

            return areEqual;
        }
    }


}
