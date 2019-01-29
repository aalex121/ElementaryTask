using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _7_NumberRow;

namespace NumberRowTest
{
    [TestClass]
    public class NaturalNumberRowTest
    {
        [TestMethod]
        public void TestGenerateEmptyNumberRowExpectedOnlyZero()
        {
            //Arrange
            NaturalNumberRow testRow = new NaturalNumberRow();
            bool hasRowOnlyZero = true;            

            //Act
            if (testRow.GetRowLength() > 1)
            {
                hasRowOnlyZero = false;
            }
            else
            {
                foreach (int item in testRow)
                {
                    if (item != 0)
                    {
                        hasRowOnlyZero = false;
                        break;
                    }
                }
            }            

            //Assert
            Assert.IsTrue(hasRowOnlyZero);
        }

        [TestMethod]
        public void TestNonEmptyNumberRowTo144Expected12InRow()
        {
            //Arrange
            NaturalNumberRow testRow = new NaturalNumberRow(144);
            int[] expectedRow = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};

            //Act           
            bool areRowsSame = CheckRowEquality(testRow, expectedRow);

            //Assert
            Assert.IsTrue(areRowsSame);
        }

        [TestMethod]
        public void TestNumberRowResizeTo16Expected4InRow()
        {
            //Arrange
            NaturalNumberRow testRow = new NaturalNumberRow(144);
            int[] expectedRow = new int[] { 0, 1, 2, 3 };            

            //Act
            testRow.SetNewTargetNumber(16);
            bool areRowsSame = CheckRowEquality(testRow, expectedRow);

            //Assert
            Assert.IsTrue(areRowsSame);
        }

        private bool CheckRowEquality(NaturalNumberRow testRow, int[] expectedRow)
        {
            if (testRow.GetRowLength() != expectedRow.Length)
            {
                return false;
            }

            bool areRowsSame = true;
            int position = 0;

            foreach (int item in testRow)
            {
                if (item != expectedRow[position])
                {
                    areRowsSame = false;
                    break;
                }

                position++;
            }

            return areRowsSame;
        }
    }
}
