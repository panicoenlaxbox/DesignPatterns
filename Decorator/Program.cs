using System;

namespace Decorator
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			AbstractComponent abstractComponent = new ConcreteDecoratorA(new ConcreteDecoratorB(new ConcreteComponent()));
			abstractComponent.Operation();
		}
	}

	interface AbstractComponent
	{
		void Operation();
	}

	class ConcreteComponent : AbstractComponent
	{
		public void Operation()
		{
			Console.WriteLine("ConcreteComponent.Operation");
		}
	}

	abstract class Decorator : AbstractComponent
	{
		private readonly AbstractComponent _abstractComponent;

		public Decorator(AbstractComponent abstractComponent)
		{
			_abstractComponent = abstractComponent;
		}

		public virtual void Operation()
		{
			_abstractComponent.Operation();
		}
	}

	class ConcreteDecoratorA : Decorator
	{
		public ConcreteDecoratorA(AbstractComponent abstractComponent) : base(abstractComponent)
		{

		}
		public override void Operation()
		{
			Console.WriteLine("ConcreteDecoratorA.Operation");
			base.Operation();
		}
	}

	class ConcreteDecoratorB : Decorator
	{
		public ConcreteDecoratorB(AbstractComponent abstractComponent) : base(abstractComponent)
		{

		}
		public override void Operation()
		{
			Console.WriteLine("ConcreteDecoratorB.Operation");
			base.Operation();
		}
	}
}
