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

    internal abstract class Subject
    {
        private readonly List<Observer> _observers;

        protected Subject()
        {
            _observers = new List<Observer>();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        protected void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    internal interface Observer
    {
        void Update();
    }

    internal class ConcreteSubject : Subject
    {
        private string _name;

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

    internal class ConcreteObserver : Observer
    {
        private readonly ConcreteSubject _subjet;

        public ConcreteObserver(ConcreteSubject subjet)
        {
            _subjet = subjet;
            subjet.Attach(this);
        }

        public void Update()
        {
            Console.WriteLine("Observer has been notified");
            Console.WriteLine("New name of subject is " + _subjet.Name);
        }
    }
}
