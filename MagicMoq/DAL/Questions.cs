using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicMoq.DAL
{
    // 1. Implement the IQuestions Interface
    // 2. Use the methods in your Answers class to address tasks/questions posed by this class
    // 3. Access an instance of your Answers class using the "Wand"
    public class Questions : IQuestions
    {
        public Answers Wand { get; set; } // This is important. Do not delete this.

        public Questions()
        {
            Wand = new Answers();
        }

        public Questions(Answers answers)
        {
            Wand = answers;
        }

        public int OnePlusOne()
        {
            //Option 1:
            return Wand.Two();

            //Option 2:
            //return Wand.One() + Wand.One();
        }

        public int ZeroPlusZero()
        {
            return Wand.Zero();
        }

        public int FourPlusZero()
        {
            return Wand.Four();
        }

        public int TwoMinusZero()
        {
            return Wand.Two();
        }

        public int OnePlusTwo()
        {
            return Wand.Three();
        }

        public int TwoPlusTwo()
        {
            return Wand.Four();
        }

        public int OneMinusOne()
        {
            //Option 1:
            return Wand.Zero(); //Passes without Mocking as a false positive

            //Option 2:
            //return Wand.One() - Wand.One();
        }

        public int FourMinusTwo()
        {
            return Wand.Two();
        }

        public int FourMinusTwoPlusOne()
        {
            return Wand.Three();
        }

        public string SayNothing()
        {
            return Wand.EmptyString();
        }

        public bool ReturnFalse()
        {
            return Wand.False();
        }

        public bool ReturnTrue()
        {
            return Wand.True();
        }

        public string SayHelloWorld()
        {
            return Wand.HelloWorld();
        }

        public List<int> CountToFive()
        {
            return Wand.ListOfNInts(5);

        }

        public List<int> FirstThreeEvenInts()
        {
            List<int> numbers = Wand.ListOfNInts(10);
            //use numbers.Sort() if ListOfNInts doesn't return sorted items
            List<int> result = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    result.Add(number);
                }

                if (result.Count == 3)
                {
                    break;
                }
            }

            return result;
        }

        public List<int> FirstThreeOddInts()
        {
            List<int> numbers = Wand.ListOfNInts(10);
            List<int> result = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 != 0)
                {
                    result.Add(number);
                }

                if (result.Count == 3)
                {
                    break;
                }
            }

            return result;
        }
    }
}