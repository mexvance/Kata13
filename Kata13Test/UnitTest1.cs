using Kata13.Services;
using NUnit.Framework;
using System.IO;

namespace Kata13Test
{
    public class Tests
    {
        string FileContents;
        string FileContentsComments;
        string FileContentsMultilineComments;
        LineCounter lineCounter;
        [SetUp]
        public void Setup()
        {
            FileContents = "       This is a test \n\r  \n  With    different\t kinds of whitespace    ";
            FileContentsComments = "//Thisisacomment\nThisisnotacomment\nThisis//Notacomment\n//Thisis//acomment\n";
            FileContentsMultilineComments = "/*Thisisacomment*/\n/*Multiline!\nmorecomment\nevenmorecomment\n*//*****//***/\nSystem./*wait*/out./*for*/println/*it*/('Hello/*')\n";
            lineCounter = new LineCounter();
        }

        [Test]
        public void TestRemoveWhiteSpace()
        {
            var returnFile = lineCounter.RemoveWhiteSpace(FileContents);
            Assert.AreEqual("Thisisatest\n\r\nWithdifferentkindsofwhitespace", returnFile);
        }

        [Test]
        public void TestRemoveSingleLineComments()
        {
            var returnFile = lineCounter.RemoveSingleLineComments(FileContentsComments);
            Assert.AreEqual("Thisisnotacomment\nThisis//Notacomment\n", returnFile);
        }

        [Test]
        public void TestRemoveMultilineComments()
        {
            var returnFile = lineCounter.RemoveMultilineComments(FileContentsMultilineComments);
            Assert.AreEqual("System.out.println('Hello/*')\n", returnFile);
        }
        [Test]
        public void TestCalculateTotalLinesOfCode()
        {

            var fileContent = File.ReadAllText("../../../SampleText.txt");
            var numberOfLines = lineCounter.ReturnTotalLinesOfCode(fileContent);
            Assert.AreEqual(5, numberOfLines);
        }
    }
}