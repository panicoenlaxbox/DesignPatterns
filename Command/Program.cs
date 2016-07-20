﻿using System;

namespace Command
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Receiver receiver = new Receiver();
			Command command = new ConcreteCommand(receiver);
			Invoker invoker = new Invoker();
			invoker.SetCommand(command);
			invoker.ExecuteCommand();
		}
	}

	abstract class Command
	{
		protected readonly Receiver receiver;

		public Command(Receiver receiver)
		{
			this.receiver = receiver;
		}

		public abstract void Execute();
	}

	class ConcreteCommand : Command
	{
		public ConcreteCommand(Receiver receiver) : base(receiver)
		{

		}
		public override void Execute()
		{
			receiver.Action();
		}
	}

	class Receiver
	{
		public void Action()
		{
			Console.WriteLine("Receiver.Action");
		}
	}

	class Invoker
	{
		private Command command;

		public void SetCommand(Command command)
		{
			this.command = command;
		}

		public void ExecuteCommand()
		{
			this.command.Execute();
		}
	}
}
