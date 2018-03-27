using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
	public delegate void StateFunc();
	private  List<State> stack;

	public State CurrentState { get { return stack[stack.Count - 1]; } }

	public FSM(State startState)
	{
		stack = new List<State> { startState };
	}

	public FSM(StateFunc startStateMainFunc)
	{
		stack = new List<State> { new State(startStateMainFunc) };
	}

	public void Update()
	{
		CurrentState.state();
	}

	public void Pop()
	{
		CurrentState.exitState();
		stack.RemoveAt(stack.Count - 1);
	}

	public void Push(State state)
	{
		stack.Add(state);
		CurrentState.enterState();
	}

	public void PopPush(State state)
	{
		Pop();
		Push(state);
	}

	public class State
	{
		public StateFunc enterState;
		public StateFunc exitState;
		public StateFunc state;

		public State(StateFunc main)
		{
			state = main;
		}

		public State(StateFunc enter, StateFunc exit, StateFunc main)
		{
			enterState = enter;
			exitState = exit;
			state = main;
		}
	}
}