using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using _4_FileParser;

namespace FileParserTest
{
    [TestClass]
    public class TxtFileParserTest
    {
        private string[] _fakeFileContent;
        private string fakeFileName = "fake.txt";

        [TestInitialize]
        public void TestInitialize()
        {
            _fakeFileContent = new string[] 
            {
                "Cats",
                "Dogs",
                "Cats",
                "Cats",
                "Dogs"
            };
        }

        [TestMethod]
        public void TestCountLineEntriesExpected3()
        {
            //Arrange
            TxtFileParser parser = new TxtFileParser(fakeFileName, DataProviderTypes.Fake);
            FakeFileProcessor processor = parser.GetFileProcessor() as FakeFileProcessor;
            processor.Data = _fakeFileContent;

            string testLine = "Cats";
            int expectedEntries = 3;

            //Act
            int actualEntries = parser.CountLineEntries(testLine);

            //Assert
            Assert.AreEqual(expectedEntries, actualEntries);
        }

        //[TestMethod]
        //public void TestReplaceLinesSmallFile()
        //{
        //    //Arrange
        //    TxtFileParser parser = new TxtFileParser(fakeFileName, DataProviderTypes.Fake);
        //    FakeFileProcessor processor = parser.GetFileProcessor() as FakeFileProcessor;
        //    processor.Data = _fakeFileContent;
        //    processor.LargeFile = false;

        //    string searchedLine = "Cats";
        //    string newLine = "Mice";

        //    string[] expectedOutput = new string[]
        //    {
        //        "Mice",
        //        "Dogs",
        //        "Mice",
        //        "Mice",
        //        "Dogs"
        //    };

        //    //Act
        //    parser.ReplaceLine(searchedLine, newLine);
        //    bool expectedResult = CheckArraysEquality(expectedOutput, parser.CurrentFileProcessor.ReadAllFile());

        //    foreach (string item in parser.CurrentFileProcessor.ReadAllFile())
        //    { 
        //        Console.WriteLine(item);
        //    }

        //    //Assert
        //    Assert.IsTrue(expectedResult);
        //}

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
