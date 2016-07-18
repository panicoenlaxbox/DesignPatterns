using System;

namespace TemplateMethod
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var claseConcreta = new ClaseConcreta();
			claseConcreta.TemplateMethod();
		}
	}

	abstract class ClaseAbstracta
	{
		public void TemplateMethod()
		{
			Console.WriteLine("Step1");
			Step2();
			Step3();
			Console.WriteLine("Step4");
		}
		protected abstract void Step2();
		protected abstract void Step3();
	}

	class ClaseConcreta : ClaseAbstracta
	{
		protected override void Step2()
		{
			Console.WriteLine("Step2");
		}

		protected override void Step3()
		{
			Console.WriteLine("Step3");
		}
	}
}
