using NUnit.Framework;
using Moq;

namespace FirstTest
{
    public class FirstTest
    {
        private NumCheck.NumChercker numCheck;
        private NumCheck.ScanRepository scanRep;
        [SetUp]
        public void Setup()
        {
            numCheck = new NumCheck.NumChercker();
            scanRep = new NumCheck.ScanRepository();
        }

        [Test]
        [TestCase(5)]
        [TestCase(10000)]
        [TestCase(2)]
        public void IsGreaterThanOneTest(int testcase)
        {
            var check = numCheck.isGreaterThanOne(testcase);
            Assert.IsTrue(check);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        public void IsLessThanOneTest(int testcase)
        {
            var check = numCheck.isGreaterThanOne(testcase);
            Assert.IsFalse(check);
        }



        [Test]
        [TestCase ("TestScanner",           ExpectedResult = "Test Scanner")]
        [TestCase ("MobileScanner",         ExpectedResult = "Mobile Scanner")]
        [TestCase ("TestScannerPref",       ExpectedResult = "Test Scanner Pref")]
        [TestCase ("TestScannerPref123",    ExpectedResult = "Test Scanner Pref 1 2 3")]
        [TestCase ("testScannerPref123",    ExpectedResult = "test Scanner Pref 1 2 3")]
        [TestCase ("testscannerpref",       ExpectedResult = "testscannerpref")]
        [TestCase ("TEST",                  ExpectedResult = "T E S T")]
        public string ScanRepositoryCheck(string pass)
        {
            //Setup
            Mock<NumCheck.IScanner> scannerMock = new Mock<NumCheck.IScanner>();
            scannerMock.Setup(a => a.Scanner()).Returns(pass);

            //Act
            string actual = scanRep.ScanSplitter(scannerMock.Object);

            //Assert
            return actual;

        }
    }
}