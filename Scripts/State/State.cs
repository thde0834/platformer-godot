using System.Collections;
using System.Collections.Generic;

public interface IState
{
    void OnEnter();
    void Process(double delta);
    void PhysicsProcess(double delta);
    void OnExit();
}

public abstract class BaseState : IState
{
    public virtual void OnEnter() { }
    public virtual void Process(double delta) { }
    public virtual void PhysicsProcess(double delta) { }
    public virtual void OnExit() { }
}
