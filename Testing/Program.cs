using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
            TestingGC();


            //ListDat03<Dog> Dogs = new ListDat03<Dog>();

            //Dogs.Add(new Dog());
            //Dogs.Add(new Dog());
            //Dogs.Add(new Dog());
            //Dogs.Add(new Dog());
            //Dogs.Add(new Dog());
            //Dogs.Add(new Dog());
            //Dogs.Add(new Dog());
            //Dogs.Add(new Dog());
            //Console.WriteLine(Dogs.Count);
            //Dogs.RemoveAt(5);
            //Console.WriteLine(Dogs.Count);




            //List<Dog> Dogs2 = new List<Dog>();
            ////Dogs2.Add(new Dog());
            ////Dogs2.Add(new Dog());
            ////Dogs2.Add(new Dog());
            ////Console.WriteLine(Dogs2.Count);

            ////Dogs2.RemoveAt(0);

            ////Console.WriteLine(Dogs2.Count);





            Console.ReadKey();
        }

        private static void TestingGC()
        {
            while (true)
            {
                Timer timer = new Timer();
                timer.Dispose();
                GC.Collect();


            }
        }


        public class Dog
        {
            const int CID = 10;
            public static int ID;
            public Dog(int name = CID)
            {
                ID++;
            }

            public override string ToString()
            {
                return ID.ToString();
            }
        }
    }
}
