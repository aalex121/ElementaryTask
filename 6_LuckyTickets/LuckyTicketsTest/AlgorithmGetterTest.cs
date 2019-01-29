using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _6_LuckyTickets;

namespace LuckyTicketsTest
{
    [TestClass]
    public class AlgorhitmGetterTest
    {
        private const string VALID_FILE_NAME = "fakefile.txt";
        private const string INVALID_FILE_NAME = "fakefile.jpg";

        private AlgorithmFileReaderStub validDataProvider;
        private AlgorithmFileReaderStub invalidDataProvider;

        [TestInitialize]
        public void TestInitialize()
        {
            validDataProvider = new AlgorithmFileReaderStub("Moscow", "Piter");
            invalidDataProvider = new AlgorithmFileReaderStub("New York", "London");
        }

        [TestMethod]
        public void TestAlgorithmGetterValidExpectAlgorithmTypeMoscow()
        {
            //Arrange            
            AlgorithmGetter getter = new AlgorithmGetter(validDataProvider);
            TicketCountAlgorithms expectedAlgorithm = TicketCountAlgorithms.Moscow;

            //Act
            TicketCountAlgorithms actualAlgorhitm = getter.GetAlgorhytm(VALID_FILE_NAME);

            //Assert
            Assert.AreEqual(expectedAlgorithm, actualAlgorhitm);
        }

        [TestMethod]
        public void TestAlgorithmGetterInvalidExpectAlgorithmTypeNone()
        {
            //Arrange            
            AlgorithmGetter getter = new AlgorithmGetter(invalidDataProvider);
            TicketCountAlgorithms expectedAlgorithm = TicketCountAlgorithms.None;

            //Act
            TicketCountAlgorithms actualAlgorhitm = getter.GetAlgorhytm(VALID_FILE_NAME);

            //Assert
            Assert.AreEqual(expectedAlgorithm, actualAlgorhitm);
        }
    }
}
