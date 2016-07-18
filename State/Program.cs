using System;

namespace State
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var context = new Context();
			Console.WriteLine(context.GetEstado());
			context.Operacion1();
			context.EstadoSiguiente();
			Console.WriteLine(context.GetEstado());
			context.Operacion2();
		}
	}

	class Context
	{
		private Estado estado;
		public Context()
		{
			estado = new EstadoConcreto1(this);
		}
		public void Operacion1()
		{
			estado.Operacion1();
		}
		public void Operacion2()
		{
			estado.Operacion2();
		}
		public void EstadoSiguiente()
		{
			estado = estado.EstadoSiguiente();
		}
		public string GetEstado()
		{
			return estado.GetType().Name;
		}
	}

	interface Estado
	{
		void Operacion1();
		void Operacion2();
		Estado EstadoSiguiente();
	}

	class EstadoConcreto1 : Estado
	{
		readonly Context context;

		public EstadoConcreto1(Context context)
		{
			this.context = context;
		}
		public Estado EstadoSiguiente()
		{
			return new EstadoConcreto2(context);
		}

		public void Operacion1()
		{
			Console.WriteLine("EstadoConcreto1.Operacion1");
		}

		public void Operacion2()
		{
			throw new NotSupportedException();
		}
	}

	class EstadoConcreto2 : Estado
	{
		readonly Context context;

		public EstadoConcreto2(Context context)
		{
			this.context = context;
		}
		public Estado EstadoSiguiente()
		{
			throw new NotSupportedException();
		}

		public void Operacion1()
		{
			throw new NotSupportedException();
		}

		public void Operacion2()
		{
			Console.WriteLine("EstadoConcreto2.Operacion2");
		}
	}
}
