using Godot;
using System;
using System.Collections.Generic;

public abstract partial class BaseSystem : Node {
    protected Dictionary<Type, BaseComponent> Components;
    public abstract Type[] DefineComponents();
    public void SetComponents(Dictionary<Type, BaseComponent> components) {
        Components = components;
    }
    protected T GetComponent<T>() where T : BaseComponent {
        return Components[typeof(T)] as T;
    }

    public virtual void OnTick(double delta) {}
    public virtual void OnTickPhysics(double delta) {}
}