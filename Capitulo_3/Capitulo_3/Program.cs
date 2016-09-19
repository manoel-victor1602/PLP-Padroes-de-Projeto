using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo_3
{
    abstract class Beverage
    {
        public string description = "Unknown Beverage";

        public String getDescription()
        {
            return description;
        }
        public abstract Double cost();
    }
    abstract class CondimentDecorator : Beverage
    {
        public abstract new string getDescription();
    }
    class Expresso : Beverage
    {
        public Expresso()
        {
            description = "Expresso";
        }
        public override double cost()
        {
            return 1.99;
        }
    }
    class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            description = "House Blend Coffee";
        }
        public override double cost()
        {
            return 0.89;
        }
    }
    class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            description = "DarkRoast Coffee";
        }
        public override double cost()
        {
            return 0.50;
        }
        
    }
    class Mocha : CondimentDecorator
    {
        Beverage beverage;

        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override double cost()
        {
            return 0.20 + beverage.cost();
        }
        public override string getDescription()
        {
            return (beverage.getDescription() + ", Mocha");
        }
    }
    class Soy : CondimentDecorator
    {
        Beverage beverage;

        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override double cost()
        {
            return 0.15 + beverage.cost();
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Soy";
        }
        

    }
    class Whip : CondimentDecorator
    {
        Beverage beverage;

        public Whip(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override double cost()
        {
            return 0.25 + beverage.cost();
        }
        public override string getDescription()
        {
            return beverage.getDescription() + ", Whip";
        }
    }
    public class StarbuzzCoffee
    {
        public static void Main(string[] args)
        {
            Beverage beverage = new Expresso();
            Console.WriteLine(beverage.getDescription() + " R$" + beverage.cost());

            Beverage beverage2 = new DarkRoast();
            beverage2 = new Mocha(beverage2);
            beverage2 = new Mocha(beverage2);
            beverage2 = new Whip(beverage2);
            Console.WriteLine(beverage2.getDescription() + " R$" + beverage2.cost());

            Beverage beverage3 = new HouseBlend();
            beverage3 = new Soy(beverage3);
            beverage3 = new Mocha(beverage3);
            beverage3 = new Whip(beverage3);
            Console.WriteLine(beverage3.getDescription() + " R$" + beverage3.cost());

            Console.ReadLine();
        }
    }
}