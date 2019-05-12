using System;
using System.Collections.Generic;

namespace Visitor
{
    // https://stackoverflow.com/questions/2604169/visitor-patterns-purpose-with-examples

    namespace NoVisitorPattern
    {
        abstract class Fruit { }
        class Orange : Fruit { }
        class Apple : Fruit { }
        class Banana : Fruit { }

        class Example
        {
            public static void DoIt()
            {
                var fruits = new Fruit[]
                {
                    new Orange(),
                    new Apple(),
                    new Banana(),
                    new Banana(),
                    new Banana(),
                    new Orange()
                };

                var oranges = new List<Orange>();
                var apples = new List<Apple>();
                var bananas = new List<Banana>();

                // No es mantenible, si añadimos una nueva clase derivada de Fruit,
                // necesitamos hacer una búsqueda global donde se haga este "fruit type-test",
                // en caso contrario podríamos perder algún tipo
                foreach (Fruit fruit in fruits)
                {
                    // pattern-matching 
                    //if (fruit is Orange orange)
                    //    oranges.Add(orange);

                    if (fruit is Orange)
                        oranges.Add((Orange)fruit);
                    else if (fruit is Apple)
                        apples.Add((Apple)fruit);
                    else if (fruit is Banana)
                        bananas.Add((Banana)fruit);
                }

                Console.WriteLine("Oranges.Count: {0}", oranges.Count);
                Console.WriteLine("Apples.Count: {0}", apples.Count);
                Console.WriteLine("Bananas.Count: {0}", bananas.Count);
            }
        }
    }

    abstract class Fruit { public abstract void Accept(IFruitVisitor visitor); }
    class Orange : Fruit { public override void Accept(IFruitVisitor visitor) { visitor.Visit(this); } }
    class Apple : Fruit { public override void Accept(IFruitVisitor visitor) { visitor.Visit(this); } }
    class Banana : Fruit { public override void Accept(IFruitVisitor visitor) { visitor.Visit(this); } }

    interface IFruitVisitor
    {
        void Visit(Orange fruit);
        void Visit(Apple fruit);
        void Visit(Banana fruit);
    }

    class FruitPartitioner : IFruitVisitor
    {
        public List<Orange> Oranges { get; private set; }
        public List<Apple> Apples { get; private set; }
        public List<Banana> Bananas { get; private set; }

        // Es mantenible,
        // Si se añaden o eliminan frutas concretas,
        // debería bastar con modificar la interface IFruitVisitor para manejar el nuevo tipo
        public FruitPartitioner()
        {
            Oranges = new List<Orange>();
            Apples = new List<Apple>();
            Bananas = new List<Banana>();
        }

        public void Visit(Orange fruit) { Oranges.Add(fruit); }
        public void Visit(Apple fruit) { Apples.Add(fruit); }
        public void Visit(Banana fruit) { Bananas.Add(fruit); }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var fruits = new Fruit[]
            {
                new Orange(),
                new Apple(),
                new Banana(),
                new Banana(),
                new Banana(),
                new Orange()
            };

            FruitPartitioner partitioner = new FruitPartitioner();
            foreach (Fruit fruit in fruits)
            {
                fruit.Accept(partitioner);
            }
            Console.WriteLine("Oranges.Count: {0}", partitioner.Oranges.Count);
            Console.WriteLine("Apples.Count: {0}", partitioner.Apples.Count);
            Console.WriteLine("Bananas.Count: {0}", partitioner.Bananas.Count);
        }
    }

}
