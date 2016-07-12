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
		protected abstract IProduct FactoryMethod();
		public void AnOperation()
		{
			IProduct product = FactoryMethod();
			product.Foo();
		}
	}

	class ConcreteCreatorA : Creator
	{
		protected override IProduct FactoryMethod()
		{
			return new ConcreteProductA();
		}
	}

	class ConcreteCreatorB : Creator
	{
		protected override IProduct FactoryMethod()
		{
			return new ConcreteProductB();
		}
	}

	interface IProduct
	{
		void Foo();
	}

	class ConcreteProductA : IProduct
	{
		public void Foo()
		{
			Console.WriteLine("ConcreteProductA.Foo");
		}
	}

	class ConcreteProductB : IProduct
	{
		public void Foo()
		{
			Console.WriteLine("ConcreteProductB.Foo");
		}
	}
}
