using System;

namespace FactoryMethod
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Creator creator = new ConcreteCreatorA();
			creator.AnOperation();
			creator = new ConcreteCreatorB();
			creator.AnOperation();
		}
	}

	abstract class Creator
	{
		protected abstract Product FactoryMethod();
		public void AnOperation()
		{
			Product product = FactoryMethod();
			product.Foo();
		}
	}

	class ConcreteCreatorA : Creator
	{
		protected override Product FactoryMethod()
		{
			return new ConcreteProductA();
		}
	}

	class ConcreteCreatorB : Creator
	{
		protected override Product FactoryMethod()
		{
			return new ConcreteProductB();
		}
	}

	interface Product
	{
		void Foo();
	}

	class ConcreteProductA : Product
	{
		public void Foo()
		{
			Console.WriteLine("ConcreteProductA.Foo");
		}
	}

	class ConcreteProductB : Product
	{
		public void Foo()
		{
			Console.WriteLine("ConcreteProductB.Foo");
		}
	}
}
