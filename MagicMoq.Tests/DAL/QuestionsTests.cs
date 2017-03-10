using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicMoq.DAL;
using Moq;
using System.Collections.Generic;

namespace MagicMoq.Tests.DAL
{
    [TestClass]
    public class QuestionsTests
    {
        [TestMethod]
        public void EnsureICanCreateQuestionsInstance()
        {
            Questions questions = new Questions();

            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void EnsureICanCreateAnswersInstance()
        {
            Answers answers = new Answers();
            Assert.IsNotNull(answers);
        }

        [TestMethod]
        public void EnsureQuestionsReturnsAnswersInstance()
        {
            // Hint: Implement a Constructor (for Questions class)
            Questions questions = new Questions();

            Assert.IsNotNull(questions.Wand);
        }

        [TestMethod]
        public void EnsureQuestionsReturnsInjectedAnswersInstance()
        {

            // Hint 1: Create an instance of your Answers class
            Answers answers = new Answers();

            // Hint 2: Implement another Constructor (for Questions class)
            Questions questions = new Questions(answers);

            Assert.IsNotNull(questions.Wand);
        }

        [TestMethod]
        public void EnsureSayHelloReturnsHelloWorld()
        {
            // Arrange
            Mock<Answers> mock_answers = new Mock<Answers>(); //Creates the Mock
            mock_answers.Setup(a => a.HelloWorld()).Returns("Hello World"); //How to "hijack" the method call

            /*a => a.something()
             * function (a) {
             * return a.something();
             * }
             */
;            
            // Add code that mocks the "HelloWorld" method response

            Questions questions = new Questions(mock_answers.Object); // Inject the "fake" answers instance into Questions constructor

            // Act
            string expected_result = "Hello World";
            string actual_result = questions.SayHelloWorld();

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureOneMinusOneReturnsZero()
        {
            // Arrange
            Mock<Answers> mock_answers = new Mock<Answers>();
            mock_answers.Setup(a => a.Zero()).Returns(0);
            // Add code that mocks the "Zero" method response

            Questions questions = new Questions(mock_answers.Object);

            // Act
            int expected_result = 0;
            int actual_result = questions.OneMinusOne();

            // Assert
            Assert.AreEqual(expected_result, actual_result);

            //Bug.  Submit issue/PR
            //mock_answers.Verify(a => a.Zero());
        }

        [TestMethod]
        public void EnsureOnePlusOneReturnsTwo()
        {
            // Arrange
            Mock<Answers> mock_answers = new Mock<Answers>();
            //mock_answers.Setup(a => a.One()).Returns(1);
            mock_answers.Setup(a => a.Two()).Returns(2);
            
            // Add code that mocks the "Two" method response

            Questions questions = new Questions(mock_answers.Object);

            // Act
            int expected_result = 2;
            int actual_result = questions.OnePlusOne();

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureOnePlusTwoReturnsThree()
        {
            // Arrange
            Mock<Answers> mock_answers = new Mock<Answers>();
            // Add code that mocks the "Three" method response
            Questions questions = new Questions(mock_answers.Object);
            mock_answers.Setup(a => a.Three()).Returns(3);

            // Act
            int expected_result = 3;
            int actual_result = questions.OnePlusTwo();

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureThisReturnsTrue()
        {
            // Arrange
            Mock<Answers> mock_answers = new Mock<Answers>();
            // Add code that mocks the "True" method response
            Questions questions = new Questions(mock_answers.Object);
            mock_answers.Setup(a => a.True()).Returns(true);

            // Act
            bool expected_result = true;
            bool actual_result = questions.ReturnTrue();

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureThisReturnsFalse()
        {
            // Arrange
            Mock<Answers> mock_answers = new Mock<Answers>();
            // Add code that mocks the "False" method response
            Questions questions = new Questions(mock_answers.Object);
            mock_answers.Setup(a => a.False()).Returns(false);

            // Act
            bool expected_result = false;
            bool actual_result = questions.ReturnFalse();

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureSayNothingReturnsEmptyString()
        {
            // Arrange
            Mock<Answers> mock_answers = new Mock<Answers>();
            
            // Add code that mocks the "EmptyString" method response
            Questions questions = new Questions(mock_answers.Object);
            mock_answers.Setup(a => a.EmptyString()).Returns("");

            // Act
            string expected_result = "";
            string actual_result = questions.SayNothing();
            
            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureTwoPlusTwoReturnsFour()
        {
            //Arrange
            Mock<Answers> mock_answers = new Mock<Answers>();
            Questions questions = new Questions(mock_answers.Object);
            mock_answers.Setup(a => a.Four()).Returns(4);

            //Act
            int expected_result = 4;
            int actual_result = questions.TwoPlusTwo();

            //Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureFourMinusTwoPlusOneReturnsThree()
        {
            //Arrange
            Mock<Answers> mock_answers = new Mock<Answers>();
            Questions questions = new Questions(mock_answers.Object);
            mock_answers.Setup(a => a.Three()).Returns(3);

            //Act
            int expected_result = 3;
            int actual_result = questions.FourMinusTwoPlusOne();

            //Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureFourMinusTwoReturnsTwo()
        {
            //Arrange
            Mock<Answers> mock_answers = new Mock<Answers>();
            Questions questions = new Questions(mock_answers.Object);
            mock_answers.Setup(a => a.Two()).Returns(2);

            //Act
            int expected_result = 2;
            int actual_result = questions.FourMinusTwo();

            //Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureCountToFiveReturnsListOfFiveInts()
        {
            Mock<Answers> mock_answers = new Mock<Answers>();
            mock_answers.Setup(a => a.ListOfNInts(It.IsAny<int>())).Returns(new List<int> { });
        }

        [TestMethod]
        public void EnsureFirstThreeEvenIntsReturnsListOfThreeEvenInts()
        {
            Mock<Answers> mock_answers = new Mock<Answers>();
            mock_answers.Setup(a => a.ListOfNInts(It.IsAny<int>())).Returns(new List<int> { });
        }

        [TestMethod]
        public void EnsureFirstThreeOddIntsReturnsListOfThreeOddInts()
        {
            Mock<Answers> mock_answers = new Mock<Answers>();
            mock_answers.Setup(a => a.ListOfNInts(It.IsAny<int>())).Returns(new List<int> { });
        }

        [TestMethod]
        public void EnsureZeroPlusZeroReturnsZero()
        {
            //Arrange
            Mock<Answers> mock_answers = new Mock<Answers>();
            Questions questions = new Questions(mock_answers.Object);
            mock_answers.Setup(a => a.Zero()).Returns(0);

            //Act
            int expected_result = 0;
            int actual_result = questions.ZeroPlusZero();

            //Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureFourPlusZeroReturnsFour()
        {
            //Arrange
            Mock<Answers> mock_answers = new Mock<Answers>();
            Questions questions = new Questions(mock_answers.Object);
            mock_answers.Setup(a => a.Four()).Returns(4);

            //Act
            int expected_result = 4;
            int actual_result = questions.FourPlusZero();

            //Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureTwoMinusZeroReturnsTwo()
        {
            //Arrange
            Mock<Answers> mock_answers = new Mock<Answers>();
            Questions questions = new Questions(mock_answers.Object);
            mock_answers.Setup(a => a.Two()).Returns(2);


            //Act
            int expected_result = 2;
            int actual_result = questions.TwoMinusZero();

            //Assert
            Assert.AreEqual(expected_result, actual_result);
        }

    }
}
