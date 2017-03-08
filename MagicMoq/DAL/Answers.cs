using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicMoq.DAL
{
    // 1. Implement the IAnswers interface
    // 2. add 'virtual' to all the generated methods 
    // 3. Do NOT remove any lines that say: "throw new NotImplementedExeception();"
    public class Answers : IAnswers
    {
        virtual public string EmptyString()
        {
            throw new NotImplementedException();
        }

        virtual public bool False()
        {
            throw new NotImplementedException();
        }

        virtual public int Four()
        {
            throw new NotImplementedException();
        }

        virtual public string HelloWorld()
        {
            throw new NotImplementedException();
        }

        virtual public List<int> ListOfNInts(int n)
        {
            throw new NotImplementedException();
        }

        virtual public int One()
        {
            throw new NotImplementedException();
        }

        virtual public int Three()
        {
            throw new NotImplementedException();
        }

        virtual public bool True()
        {
            throw new NotImplementedException();
        }

        virtual public int Two()
        {
            throw new NotImplementedException();
        }

        virtual public int Zero()
        {
            throw new NotImplementedException();
        }
    }
}