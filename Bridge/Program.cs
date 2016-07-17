using System;

namespace Bridge
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var concreteAbstraction = new ConcreteAbstraction(new ConcreteImplementor());
			concreteAbstraction.Operation();
		}
	}

	abstract class Abstraction
	{
		protected readonly Implementor implementor;

		protected Abstraction(Implementor implementor)
		{
			this.implementor = implementor;
		}
		public virtual void Operation()
		{
			this.implementor.Implementation();
		}
	}

	class ConcreteAbstraction : Abstraction
	{
		public ConcreteAbstraction(Implementor implementor) : base(implementor)
		{
		}
	}

	interface Implementor
	{
		void Implementation();
	}

	class ConcreteImplementor : Implementor
	{
		public void Implementation()
		{
			Console.WriteLine("ConcreteImplementor.Implementation");
		}
	}
}
