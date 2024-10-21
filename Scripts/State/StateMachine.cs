using System.Collections.Generic;
using System;

public class StateMachine
{
    private StateNode _current;
    private Dictionary<Type, StateNode> _nodes = new();
    private List<ITransition> _anyTransitions = new();
    private List<ITransition> _activeTransitions = new();

    private void SetActiveTransitions()
    {
        _activeTransitions.Clear();
        _activeTransitions.AddRange(_anyTransitions);
        _activeTransitions.AddRange(_current.Transitions);
    }

    public void Process(double delta)
    {
        IState state = _activeTransitions.Find(t => t.Condition.Evaluate())?.To;
        if (state != null) ChangeState(state);
        _current.State.Process(delta);
    }

    public void PhysicsProcess(double delta) => _current.State.PhysicsProcess(delta);

    public void SetState(IState state)
    {
        _current = _nodes[state.GetType()];
        SetActiveTransitions();
        _current.State.OnEnter();
    }

    public void ChangeState(IState state)
    {
        if (state == _current.State) return;
        _current?.State.OnExit();
        _current = _nodes[state.GetType()];
        SetActiveTransitions();
        _current.State.OnEnter();
    }

    public void AddTransition(IState from, IState to, IPredicate condition)
    {
        GetOrCreateNode(from).AddTransition(GetOrCreateNode(to).State, condition);
    }

    public void AddAnyTransition(IState to, IPredicate condition)
    {
        Transition transition = new Transition(GetOrCreateNode(to).State, condition);
        _anyTransitions.Add(transition);
    }

    private StateNode GetOrCreateNode(IState state)
    {
        var node = _nodes.GetValueOrDefault(state.GetType());

        if (node == null)
        {
            node = new StateNode(state);
            _nodes.Add(state.GetType(), node);
        }

        return node;
    }

    private class StateNode
    {
        public IState State { get; }
        public List<ITransition> Transitions { get; }

        public StateNode(IState state)
        {
            State = state;
            Transitions = new List<ITransition>();
        }

        public void AddTransition(IState to, IPredicate condition)
        {
            Transitions.Add(new Transition(to, condition));
        }

    }
}

