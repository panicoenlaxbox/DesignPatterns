using System;
using System.Collections.Generic;

namespace Prototype
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var client = new Client();
			client.AnOperation();
		}
	}

	class Client
	{
		private IList<Prototype> prototypes;

		public Client()
		{
			prototypes = new List<Prototype>();
			prototypes.Add(new ConcretePrototypeA("A"));
			prototypes.Add(new ConcretePrototypeB("B"));
			Console.WriteLine("Original");
			PrintPrototypes(prototypes);
		}

		public void AnOperation()
		{
			IList<Prototype> cloned = new List<Prototype>();
			foreach (var prototype in prototypes)
			{
				cloned.Add(prototype.Clone());
			}
			Console.WriteLine("Cloned");
			PrintPrototypes(cloned);
		}

		void PrintPrototypes(IEnumerable<Prototype> prototypes)
		{
			foreach (var prototype in prototypes)
			{
				Console.WriteLine(prototype.Tag);
			}
		}
	}

	abstract class Prototype
	{
		public Prototype(string tag)
		{
			Tag = tag;
		}
		public abstract Prototype Clone();
		public string Tag { get; set; }
	}

	class ConcretePrototypeA : Prototype
	{
		public ConcretePrototypeA(string tag) : base(tag)
		{

		}
		public override Prototype Clone()
		{
			return (Prototype)this.MemberwiseClone();
		}
	}

	class ConcretePrototypeB : Prototype
	{
		public ConcretePrototypeB(string tag) : base(tag)
		{

		}
		public override Prototype Clone()
		{
			return (Prototype)this.MemberwiseClone();
		}
	}
}
