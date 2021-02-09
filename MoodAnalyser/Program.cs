using System;
using System.Reflection;
namespace MoodAnalyser
{
    class Program
    {

        public static void TestCustomerClassByReflections()
        {
            Type type = Type.GetType("MoodAnalyserTesting.Customer");

            Console.WriteLine("Full Name is {0}"+type.FullName);

            Console.WriteLine("Class Name is "+type.Name);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestCustomerClassByReflections();
        }
    }
}
