using System;

namespace Facade
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}

	class ComplexClass1
	{
		public void ComplexOperation1()
		{
		}
	}

	class ComplexClass2
	{
		public void ComplexOperation2()
		{
		}
	}

	class Facade
	{
		readonly ComplexClass1 _complexClass1;
		readonly ComplexClass2 _complexClass2;
		public Facade()
		{
			_complexClass1 = new ComplexClass1();
			_complexClass2 = new ComplexClass2();
		}
		public void Operation()
		{
			_complexClass1.ComplexOperation1();
			_complexClass2.ComplexOperation2();
		}
	}
}
