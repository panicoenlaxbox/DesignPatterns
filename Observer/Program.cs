using System;
using System.Collections.Generic;

namespace Observer
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var subject = new ConcreteSubject();
			var observer1 = new ConcreteObserver(subject);
			var observer2 = new ConcreteObserver(subject);
			subject.Name = "panicoenlaxbox";
		}
	}

	abstract class Subject
	{
		readonly List<Observer> observers;
		public Subject()
		{
			observers = new List<Observer>();
		}
		public void Attach(Observer observer)
		{
			observers.Add(observer);
		}
		public void Detach(Observer observer)
		{
			observers.Remove(observer);
		}
		protected void Notify()
		{
			foreach (var o in observers)
			{
				o.Update();
			}
		}
	}

	interface Observer
	{
		void Update();
	}

	class ConcreteSubject : Subject
	{
		string _name;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				Notify();
			}
		}
	}

	class ConcreteObserver : Observer
	{
		readonly ConcreteSubject subjet;

		public ConcreteObserver(ConcreteSubject subjet)
		{
			this.subjet = subjet;
			subjet.Attach(this);
		}

		public void Update()
		{
			Console.WriteLine("Observer has been notified");
			Console.WriteLine("New name of subject is " + subjet.Name);
		}
	}
}
