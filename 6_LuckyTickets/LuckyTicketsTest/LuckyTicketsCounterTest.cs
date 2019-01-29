using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _6_LuckyTickets;

namespace LuckyTicketsTest
{
    [TestClass]
    public class LuckyTicketsCounterTest
    {
        [ExpectedException(typeof(InvalidTicketDigitsCountException), "Invalid digits count!")]
        [TestMethod]
        public void TestNewTicketsCounterMoscow0DigitsExpectException()
        {
            LuckyTicketsCounterMoscow counter = new LuckyTicketsCounterMoscow(0);
        }

        [ExpectedException(typeof(InvalidTicketDigitsCountException), "Invalid digits count!")]
        [TestMethod]
        public void TestNewTicketsCounterPiter0DigitsExpectException()
        {
            LuckyTicketsCounterPiter counter = new LuckyTicketsCounterPiter(0);
        }

        [ExpectedException(typeof(InvalidTicketDigitsCountException), "Invalid digits count!")]
        [TestMethod]
        public void TestNewTicketsCounterMoscowOddDigitsExpectException()
        {
            int oddValue = 3;
            LuckyTicketsCounterMoscow counter = new LuckyTicketsCounterMoscow(oddValue);
        }

        [ExpectedException(typeof(InvalidTicketDigitsCountException), "Invalid digits count!")]
        [TestMethod]
        public void TestNewTicketsCounterPiterOddDigitsExpectException()
        {
            int oddValue = 3;
            LuckyTicketsCounterPiter counter = new LuckyTicketsCounterPiter(oddValue);
        }

        [TestMethod]
        public void TestGetLuckyTicketsCountMoscow6DigitsExpected55252()
        {
            //Arrange
            int digitsCount = 6;
            ulong expectedLuckyTicketsCount = 55252;

            //Act
            LuckyTicketsCounterMoscow ticketCounterMoscow = new LuckyTicketsCounterMoscow(digitsCount);
            ulong actualLuckyTicketsCount = ticketCounterMoscow.GetLuckyTicketsQuantity();           

            //Assert
            Assert.AreEqual(expectedLuckyTicketsCount, actualLuckyTicketsCount);
        }

        [TestMethod]
        public void TestGetLuckyTicketsCountPiter6DigitsExpected55252()
        {
            //Arrange
            int digitsCount = 6;
            ulong expectedLuckyTicketsCount = 55252;

            //Act
            LuckyTicketsCounterPiter ticketCounterPiter = new LuckyTicketsCounterPiter(digitsCount);
            ulong actualLuckyTicketsCount = ticketCounterPiter.GetLuckyTicketsQuantity();

            //Assert
            Assert.AreEqual(expectedLuckyTicketsCount, actualLuckyTicketsCount);
        }
    }
}
