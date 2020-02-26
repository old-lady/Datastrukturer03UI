using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryDat03;


namespace Testing
{
    class Program
    {

        public int MyProperty
        {
            get { return MyProperty; }

        }



        static void Main(string[] args)
        {
            ListDat03<Dog> Dogs = new ListDat03<Dog>();
            Dogs.Add(new Dog(), new Dog(), new Dog(), new Dog(), new Dog(), new Dog(), new Dog(), new Dog(), new Dog(), new Dog());

            Console.WriteLine(Dogs.Count);


            Console.ReadKey();
        }

        public class Dog
        {

        }
    }
}
