using System;
using System.Collections.Generic;

namespace Messaging
{
    /// <summary>
    /// http://www.dofactory.com/net/mediator-design-pattern
    /// </summary>
    class MainApp
    {
        static void Main()
        {
            // Create chatroom (Mediator)
            Chatroom chatroom = new Chatroom();

            // Create participants (ConcreteColleague) and register them (in Mediator)
            Participant george = new Beatle("George");
            Participant paul = new Beatle("Paul");
            Participant ringo = new Beatle("Ringo");
            Participant john = new Beatle("John");
            Participant yoko = new NonBeatle("Yoko");

            chatroom.Register(george);
            chatroom.Register(paul);
            chatroom.Register(ringo);
            chatroom.Register(john);
            chatroom.Register(yoko);

            yoko.Send("John", "Hi John!");
            paul.Send("Ringo", "All you need is love");
            ringo.Send("George", "My sweet Lord");
            paul.Send("John", "Can't buy me love");
            john.Send("Yoko", "My sweet love");

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Mediator' abstract class
    /// </summary>
    internal abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);
        public abstract void Send(
          string from, string to, string message);
    }

    /// <summary>
    /// The 'ConcreteMediator' class
    /// </summary>
    internal class Chatroom : AbstractChatroom
    {
        private readonly Dictionary<string, Participant> _participants = new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        public override void Send(string from, string to, string message)
        {
            var participant = _participants[to];

            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }

    /// <summary>
    /// The 'AbstractColleague' class
    /// </summary>
    internal class Participant
    {
        public Participant(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public Chatroom Chatroom { set; get; }

        // Sends message to given participant
        public void Send(string to, string message)
        {
            Chatroom.Send(Name, to, message);
        }

        // Receives message from given participant
        public virtual void Receive(
          string from, string message)
        {
            Console.WriteLine($"{from} to {Name}: '{message}'");
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    internal class Beatle : Participant
    {
        // Constructor
        public Beatle(string name)
          : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    internal class NonBeatle : Participant
    {
        // Constructor
        public NonBeatle(string name)
          : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
}
