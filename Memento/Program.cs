using System;

namespace Memento
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var o = new Originator();
			o.Foo = "Foo";
			o.Bar = "Bar";
			Console.WriteLine(o);
			var c = new Caretaker();
			c.Memento = o.CreateMemento();
			o.Foo = "Baz";
			o.Bar = "Qux";
			Console.WriteLine(o);
			o.SetMemento(c.Memento);
			Console.WriteLine(o);
		}
	}

	class Originator
	{
		public string Foo { get; set; }
		public string Bar { get; set; }
		public Memento CreateMemento()
		{
			Console.WriteLine("Capturing memento");
			return new Memento(Foo, Bar);
		}
		public void SetMemento(Memento memento)
		{
			Console.WriteLine("Restoring memento");
			Foo = memento.Foo;
			Bar = memento.Bar;
		}
		public override string ToString()
		{
			return string.Format("[Originator: Foo={0}, Bar={1}]", Foo, Bar);
		}
	}

	class Memento
	{
		public Memento(string foo, string bar)
		{
			Foo = foo;
			Bar = bar;
		}
		public string Foo { get; }
		public string Bar { get; }

	}

	class Caretaker
	{
		public Memento Memento { get; set; }
	}
}
