using MathsQuiz;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        QuestionElementsToCheck __questionElementsToCheck;
        QuestionChecker __questionChecker = new QuestionChecker();

        [TestMethod]
        public void QuestionChecker_MakeLargerNumberOne_TestFirstNumberIsLarger()
        {
            //arrange
            QuestionNumbers _questionNumbers = new QuestionNumbers();
            _questionNumbers.__FirstNumber = 2;
            _questionNumbers.__SecondNumber = 4;
            //act
            QuestionNumbers _Actual =  __questionChecker.MakeLargerNumberOne(_questionNumbers);
            //assert
            Assert.AreEqual(4, _Actual.__FirstNumber);
            Assert.AreEqual(2, _Actual.__SecondNumber);
        }

        [TestMethod]
        public void QuestionChecker_CheckQuestionResults_TestAddition()
        {
            __questionElementsToCheck = new QuestionElementsToCheck(0, 5, 3);
            QuestionCheckResults _Actual = __questionChecker.CheckQuestionResults(__questionElementsToCheck);

            Assert.AreEqual(null, _Actual.__ChangeIdentifier);
            Assert.AreEqual(-1, _Actual.__ChangedProperty);
        }

        [TestMethod]
        public void QuestionChecker_CheckQuestionResults_TestSubtraction()
        {
            __questionElementsToCheck = new QuestionElementsToCheck(1, 5, 3);
            QuestionCheckResults _Actual = __questionChecker.CheckQuestionResults(__questionElementsToCheck);

            Assert.AreEqual(null, _Actual.__ChangeIdentifier);
            Assert.AreEqual(-1, _Actual.__ChangedProperty);
        }

        [TestMethod]
        public void QuestionChecker_CheckQuestionResults_TestMultiplication()
        {
            __questionElementsToCheck = new QuestionElementsToCheck(2, 5, 3);
            QuestionCheckResults _Actual = __questionChecker.CheckQuestionResults(__questionElementsToCheck);

            Assert.AreEqual(null, _Actual.__ChangeIdentifier);
            Assert.AreEqual(-1, _Actual.__ChangedProperty);
        }

        [TestMethod]
        public void QuestionChecker_CheckQuestionResults_TestDivision()
        {
            __questionElementsToCheck = new QuestionElementsToCheck(3, 5, 3);
            QuestionCheckResults _Actual = __questionChecker.CheckQuestionResults(__questionElementsToCheck);

            Assert.AreEqual("firstNum", _Actual.__ChangeIdentifier);
            Assert.AreEqual(15, _Actual.__ChangedProperty);
        }

        [TestMethod]
        public void QuestionChecker_CheckQuestionResults_TestSquareRootWhenNotRoot()
        {
            __questionElementsToCheck = new QuestionElementsToCheck(4, 5, 0);
            QuestionCheckResults _Actual = __questionChecker.CheckQuestionResults(__questionElementsToCheck);

            Assert.AreEqual("operatorsIndex", _Actual.__ChangeIdentifier);
            Assert.AreEqual(2, _Actual.__ChangedProperty);
        }

        [TestMethod]
        public void QuestionChecker_CheckQuestionResults_TestSquareRootWhenRoot()
        {
            __questionElementsToCheck = new QuestionElementsToCheck(4, 9, 0);
            QuestionCheckResults _Actual = __questionChecker.CheckQuestionResults(__questionElementsToCheck);

            Assert.AreEqual(null, _Actual.__ChangeIdentifier);
            Assert.AreEqual(-1, _Actual.__ChangedProperty);
        }

    }
}
