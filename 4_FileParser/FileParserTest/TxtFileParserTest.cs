using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using _4_FileParser;

namespace FileParserTest
{
    [TestClass]
    public class TxtFileParserTest
    {
        private string[] _fakeFileContent;        

        [TestInitialize]
        public void TestInitialize()
        {
            _fakeFileContent = new string[] 
            {
                "Cats",
                "Dogs",
                "Cats",
                "Cats",
                "Dogs",
                "Horse"
            };
        }

        [TestMethod]
        public void TestCountLineEntriesExpected3()
        {
            //Arrange
            TxtFileParser parser = new TxtFileParser(FakeFileProcessor.VALID_FAKE_FILE, DataProviderTypes.Fake);
            FakeFileProcessor processor = parser.CurrentFileProcessor as FakeFileProcessor;
            processor.Data = _fakeFileContent;

            string testLine = "Cats";
            int expectedEntries = 3;

            //Act
            int actualEntries = parser.CountLineEntries(testLine);

            //Assert
            Assert.AreEqual(expectedEntries, actualEntries);
        }

        [TestMethod]
        public void TestReplaceLinesSmallFileExpectTrue()
        {
            //Arrange
            TxtFileParser parser = new TxtFileParser(FakeFileProcessor.VALID_FAKE_FILE, DataProviderTypes.Fake);
            FakeFileProcessor processor = parser.CurrentFileProcessor as FakeFileProcessor;
            processor.Data = _fakeFileContent;
            processor.LargeFile = false;

            string searchedLine = "Cats";
            string newLine = "Mice";

            string[] expectedOutput = new string[]
            {
                "Mice",
                "Dogs",
                "Mice",
                "Mice",
                "Dogs",
                "Horse"
            };

            //Act
            parser.ReplaceLine(searchedLine, newLine);
            string[] actualContent = parser.CurrentFileProcessor.ReadAllFile();
            bool expectedResult = CheckArraysEquality(expectedOutput, actualContent);

            //Assert
            Assert.IsTrue(expectedResult);
        }

        [TestMethod]
        public void TestReplaceLinesLargeFileExpectTrue()
        {
            //Arrange
            TxtFileParser parser = new TxtFileParser(FakeFileProcessor.VALID_FAKE_FILE, DataProviderTypes.Fake);
            FakeFileProcessor processor = parser.CurrentFileProcessor as FakeFileProcessor;
            processor.Data = _fakeFileContent;
            processor.LargeFile = true;

            string searchedLine = "Cats";
            string newLine = "Mice";

            string[] expectedOutput = new string[]
            {
                "Mice",
                "Dogs",
                "Mice",
                "Mice",
                "Dogs",
                "Horse"
            };

            //Act
            parser.ReplaceLine(searchedLine, newLine);
            string[] actualContent = parser.CurrentFileProcessor.ReadAllFile();
            bool expectedResult = CheckArraysEquality(expectedOutput, actualContent);

            //Assert
            Assert.IsTrue(expectedResult);
        }

        [TestMethod]
        public void TestCountLinesInInvalidFileExpected0()
        {
            //Arrange
            TxtFileParser parser = new TxtFileParser("invalidFile.jpg", DataProviderTypes.Fake);
            string searchedLine = "Cats";

            //Act
            int actualOutput = parser.CountLineEntries(searchedLine);

            //Assert
            Assert.AreEqual(0, actualOutput);
        }

        [TestMethod]
        public void TestRepalceInInvalidFileExpectedFalse()
        {
            //Arrange
            TxtFileParser parser = new TxtFileParser("invalidFile.jpg", DataProviderTypes.Fake);

            string searchedLine = "Cats";
            string newLine = "Mice";

            //Act
            bool actualOutput = parser.ReplaceLine(searchedLine, newLine);

            //Assert
            Assert.IsFalse(actualOutput);
        }

        private bool CheckArraysEquality(string[] expected, string[] actual)
        {
            bool areEqual = true;

            for (int i = 0; i < actual.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    areEqual = false;
                    break;
                }
            }

            if (expected.Length != actual.Length)
            {
                areEqual = false;
            }

            return areEqual;
        }
    }
}
