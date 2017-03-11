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
        private Mock<Answers> mock_answers { get; set; }

        [TestInitialize]
        public void Setup() //Name doesn't matter
        {
            //Runs before every test
            mock_answers = new Mock<Answers>();

        }

        [TestCleanup]
        public void Cleanup()
        {
            //runs after every test
            mock_answers = null;
        }


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
            mock_answers.Setup(a => a.ListOfNInts(It.Is<int>(i => i == 5))).Returns(new List<int> { 1, 2, 3, 4, 5 });
            Questions questions = new Questions(mock_answers.Object);

            List<int> expected_result = new List<int> { 1, 2, 3, 4, 5 };
            List<int> actual_result = questions.CountToFive();

            CollectionAssert.AreEqual(expected_result, actual_result);
            
        }

        [TestMethod]
        public void EnsureFirstThreeEvenIntsReturnsListOfThreeEvenInts()
        {
            //Arrange
            //i needs to be large enough so you get a list that CONTAINS 3 even numbers
            mock_answers.Setup(a => a.ListOfNInts(It.Is<int>(i => i == 10))).Returns(new List<int> {1, 2, 3, 4, 5, 6 });
            Questions questions = new Questions(mock_answers.Object);

            //Act
            List<int> expected_result = new List<int> { 2, 4, 6 };
            List<int> actual_result = questions.FirstThreeEvenInts();

            //Assert
            // 1. Collection Assert
            CollectionAssert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureFirstThreeOddIntsReturnsListOfThreeOddInts()
        {
            //Arrange
            //i needs to be large enough so you get a list that CONTAINS 3 odd numbers
            mock_answers.Setup(a => a.ListOfNInts(It.Is<int>(i => i == 10))).Returns(new List<int> { 1, 2, 3, 4, 5, 6 });
            Questions questions = new Questions(mock_answers.Object);

            //Act
            List<int> expected_result = new List<int> { 1, 3, 5 };
            List<int> actual_result = questions.FirstThreeOddInts();

            //Assert
            // 1. Collection Assert
            CollectionAssert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureZeroPlusZeroReturnsZero()
        {
            //Arrange
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
