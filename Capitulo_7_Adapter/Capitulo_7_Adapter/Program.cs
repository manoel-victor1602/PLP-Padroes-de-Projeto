using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo_7_Adapter
{
    public interface Duck
    {
        void quack();
        void fly();
    }
    public class MallardDuck : Duck
    {
        public void fly()
        {
            Console.WriteLine("I'm flying");
        }
        public void quack()
        {
            Console.WriteLine("Quack");
        }
    }
    public interface Turkey
    {
        void gobble();
        void fly();
    }
    public class WildTurkey : Turkey
    {
        public void gobble()
        {
            Console.WriteLine("Gobble gobble");
        }

        public void fly()
        {
            Console.WriteLine("I'm flying a short distance");
        }
    }
    public class TurkeyAdapter : Duck
    {
        Turkey turkey;

        public TurkeyAdapter(Turkey turkey)
        {
            this.turkey = turkey;
        }
        public void fly()
        {
           for(int i = 0; i < 5; i++)
            {
                turkey.fly();
            }
        }
        public void quack()
        {
            turkey.gobble();
        }
    }
    public class DuckTestDrive
    {
        public static void Main(string[] args)
        {
            MallardDuck duck = new MallardDuck();

            WildTurkey turkey = new WildTurkey();
            Duck turkeyAdapter = new TurkeyAdapter(turkey);

            Console.WriteLine("The Turkey says...");
            turkey.gobble();
            turkey.fly();

            Console.WriteLine("\nThe Duck says...");
            testDuck(duck);

            Console.WriteLine("\nThe Turkey Adapter says...");
            testDuck(turkeyAdapter);

            Console.ReadLine();
        }

        public static void testDuck(Duck duck)
        {
            duck.quack();
            duck.fly();
        }
    }
}