using System;

namespace Adapter
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var adapter = new ConcreteAdapter(new Adaptee());
			adapter.Operation();
		}
	}

	interface Adapter {
		void Operation();
	}

	class ConcreteAdapter : Adapter
	{
		readonly Adaptee _adaptee;

		public ConcreteAdapter(Adaptee adaptee)
		{
			_adaptee = adaptee;
		}
		public void Operation()
		{
			_adaptee.AdaptedOperation();
		}
	}

	class Adaptee
	{
		public void AdaptedOperation()
		{
			Console.WriteLine("Operación adaptada");
		}
	}
}
