using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTest
{
    class CSharpHelloPerf
    {

        public CSharpHelloPerf() {

            //displayHelloWorld();
            Hello();
        }

        public void displayHelloWorld()
        {
           Console.WriteLine("Hello Java, I'm C#!.. Displaying stuff from Performance..");
        }
        [TestCase]
        public void Hello()
        {
            Console.WriteLine("Tested From  C#");

        }


    }
}
