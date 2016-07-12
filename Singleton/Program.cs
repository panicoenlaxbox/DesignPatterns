using System;

namespace Singleton
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Singleton.Instance().Foo();
		}
	}

	class Singleton
	{
		private static Singleton _instance;
		private Singleton()
		{

		}
		public static Singleton Instance()
		{
			return _instance ?? (_instance = new Singleton());
		}
		public void Foo()
		{
			Console.WriteLine("Foo");
		}
	}
}
