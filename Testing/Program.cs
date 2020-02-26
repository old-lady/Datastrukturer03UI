using System;
using System.Collections;
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
            //CustomSet();
            SetTestUnion();




            Console.ReadKey();
        }

        private static void SetTestUnion()
        {
            Set<int> set1 = new Set<int>();
            set1.Add(1);
            set1.Add(2);
            set1.Add(3);
            set1.Add(4);
            Set<int> set2 = new Set<int>();
            set2.Add(1);
            set2.Add(3);
            set2.Add(9);
            set2.Add(42);

            Set<int> resultUnion = (Set<int>)set1.Union(set2);
            Set<int> resultInstersect = (Set<int>)set1.Intersect(set2);
            Set<int> resultDifference = (Set<int>)set1.Difference(set2);

            //Console.WriteLine(set1.Contains(1));
            //Console.WriteLine(resultInstersect.Count);

            foreach (var item in resultDifference)
            {
                Console.WriteLine(item);
            }
        }

        private static void CustomSet()
        {
            Set<Dog> dogs = new Set<Dog>();
            Dog dog = new Dog();
            Dog dog2 = dog;
            Console.WriteLine(dogs.Count);

            dogs.Add(dog);
            dogs.Add(dog2);
            Console.WriteLine(dogs.Count);
            Console.WriteLine(dogs[0]);

            dogs.Remove(dog);

            Console.WriteLine(dogs.Count);



        }

        private static void CustomList()
        {
            ListDat03<Dog> Dogs = new ListDat03<Dog>();

            Dogs.Add(new Dog());
            Dogs.Add(new Dog());
            Dogs.Add(new Dog());
            Dogs.Add(new Dog());
            Dogs.Add(new Dog());
            Dogs.Add(new Dog());
            Dogs.Add(new Dog());
            Dogs.Add(new Dog());

            Console.WriteLine(Dogs[1]);

            //IEnumerator test = Dogs.GetEnumerator();

            //Console.WriteLine(test);

            //foreach (var item in Dogs)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(Dogs.Count);
            //Dogs.RemoveAt(5);
            //Console.WriteLine(Dogs.Count);




            //List<Dog> Dogs2 = new List<Dog>();
            //Dogs2.Add(new Dog());

            //foreach (object item in Dogs2)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(Dogs2[0]);
            ////Dogs2.Add(new Dog());
            ////Dogs2.Add(new Dog());
            ////Console.WriteLine(Dogs2.Count);

            ////Dogs2.RemoveAt(0);

            ////Console.WriteLine(Dogs2.Count);




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

            private static int ID = 0;
            public int myID;
            public Dog()
            {
                myID = ID;
                ID++;
            }

            public override string ToString()
            {
                return myID.ToString();
            }
        }
    }
}
