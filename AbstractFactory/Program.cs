using System;

namespace AbstractFactory
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var client = new Client(new ConcreteFactory1());
			client = new Client(new ConcreteFactory2());
			Console.ReadKey();
		}
	}

	/// <summary>
	/// Client does not know the family of the products
	/// </summary>
	class Client
	{
		public Client(AbstractFactory factory)
		{
			ProductA productA = factory.CreateProductA();
			ProductB productB = factory.CreateProductB();
		}
	}

	/// <summary>
	/// Abstract factory
	/// One factory method for each kind of abstract product
	/// </summary>
	abstract class AbstractFactory
	{
		public abstract ProductA CreateProductA();
		public abstract ProductB CreateProductB();
	}

	/// <summary>
	/// Concrete factory of products of family 1
	/// </summary>
	class ConcreteFactory1 : AbstractFactory
	{
		public override ProductA CreateProductA()
		{
			return new ProductA1();
		}

		public override ProductB CreateProductB()
		{
			return new ProductB1();
		}
	}

	/// <summary>
	/// Concrete factory of products of family 2
	/// </summary>
	class ConcreteFactory2 : AbstractFactory
	{
		public override ProductA CreateProductA()
		{
			return new ProductA2();
		}

		public override ProductB CreateProductB()
		{
			return new ProductB2();
		}
	}

	/// <summary>
	/// Abstract product A
	/// </summary>
	abstract class ProductA
	{
	}

	/// <summary>
	/// Concrete product A with familiy 1
	/// </summary>
	class ProductA1:ProductA
	{

	}

	/// <summary>
	/// Concrete product A with family 2
	/// </summary>
	class ProductA2 : ProductA
	{

	}

	/// <summary>
	/// Abstract product B
	/// </summary>
	abstract class ProductB
	{

	}

	/// <summary>
	/// Concrete product B with familiy 1
	/// </summary>
	class ProductB1 : ProductB
	{

	}

	/// <summary>
	/// Concrete product B with family 2
	/// </summary>
	class ProductB2 : ProductB
	{

	}
}
