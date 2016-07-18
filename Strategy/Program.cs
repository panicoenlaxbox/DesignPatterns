using System;

namespace Strategy
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var entidad = new Entidad(new EstrategiaConcretaA());
			entidad.Operacion();
			entidad = new Entidad(new EstrategiaConcretaB());
			entidad.Operacion();
		}
	}

	class Entidad
	{
		readonly Estrategia estrategia;

		public Entidad(Estrategia estrategia)
		{
			this.estrategia = estrategia;
		}
		public void Operacion()
		{
			estrategia.Calcula();
		}
	}

	interface Estrategia
	{
		void Calcula();
	}

	class EstrategiaConcretaA : Estrategia
	{
		public void Calcula()
		{
			Console.WriteLine("EstrategiaConcretaA");
		}
	}

	class EstrategiaConcretaB : Estrategia
	{
		public void Calcula()
		{
			Console.WriteLine("EstrategiaConcretaB");
		}
	}
}
