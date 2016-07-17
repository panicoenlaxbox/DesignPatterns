using System;
using System.Collections.Generic;

namespace Composition
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var hoja1 = new Hoja("Hoja1");
			var hoja2 = new Hoja("Hoja2");
			var compuesto1 = new Compuesto("Compuesto1");
			var compuesto2 = new Compuesto("Compuesto2");
			compuesto1.AgregaComponente(compuesto2);
			compuesto2.AgregaComponente(hoja1);
			compuesto2.AgregaComponente(hoja2);
			compuesto1.WriteNombre();
		}
	}

	abstract class Componente
	{
		public abstract void AgregaComponente(Componente componente);
		public abstract void SuprimeComponente(Componente componente);
		public abstract void WriteNombre();
		public string Nombre { get; set; }
	}

	class Hoja : Componente
	{
		public Hoja(string nombre)
		{
			Nombre = nombre;
		}
		public override void AgregaComponente(Componente componente)
		{
			throw new NotImplementedException();
		}

		public override void WriteNombre()
		{
			Console.WriteLine(Nombre);
		}

		public override void SuprimeComponente(Componente componente)
		{
			throw new NotImplementedException();
		}
	}

	class Compuesto : Componente
	{
		private readonly List<Componente> _componentes;
		public Compuesto(string nombre)
		{
			Nombre = nombre;
			_componentes = new List<Componente>();
		}
		public override void AgregaComponente(Componente componente)
		{
			_componentes.Add(componente);
		}

		public override void WriteNombre()
		{
			Console.WriteLine(Nombre);
			foreach (var componente in _componentes)
			{
				componente.WriteNombre();
			}
		}

		public override void SuprimeComponente(Componente componente)
		{
			_componentes.Remove(componente);
		}
	}
}
