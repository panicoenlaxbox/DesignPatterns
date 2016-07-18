using System;

namespace ChainOfResponsability
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var a = new ConcreteHandler1();
			var b = new ConcreteHandler2();
			a.NextHandler = b;
			Console.WriteLine(a.HandleRequest());
		}

		abstract class Handler
		{

			protected abstract string Name { get; }

			public virtual string HandleRequest()
			{
				string name = Name;
				if (name != null)
					return name;
				if (NextHandler != null)
					return NextHandler.HandleRequest();
				return "default name";

			}
			public Handler NextHandler { get; set; }
		}

		class ConcreteHandler1 : Handler
		{
			protected override string Name
			{
				get
				{
					return null;
				}
			}

		}

		class ConcreteHandler2 : Handler
		{
			protected override string Name
			{
				get
				{
					return "ConcreteHandler2";
				}
			}

		}
	}
}
