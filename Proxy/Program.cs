using System;

namespace Proxy
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Foo(new RealSubject());
			Foo(new Proxy());
		}

		public static void Foo(Subject subject)
		{
			subject.Operation();
		}
	}

	interface Subject
	{
		void Operation();
	}

	class RealSubject : Subject
	{
		public void Operation()
		{
			Console.WriteLine("Operation in RealSubject");
		}
	}

	class Proxy : Subject
	{
		private Subject _realSubject;
		public void Operation()
		{
			Console.WriteLine("Operation in proxy");
			if (_realSubject == null) {
				_realSubject = new RealSubject();
			}
			_realSubject.Operation();
		}
	}
}
