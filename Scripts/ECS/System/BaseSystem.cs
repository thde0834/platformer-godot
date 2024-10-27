using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public abstract partial class BaseSystem : Node {
    private Entity Entity;
    protected Dictionary<Type, BaseComponent> Components;
    public abstract Type[] DefineComponentTypes();
    public BaseSystem Initialize(Entity entity) {
        this.Entity = entity;
        this.Components = DefineComponentTypes()
            .Join(
                Entity.Components,
                type => type,
                component => component.Key,
                (type, component) => component.Value
            )
            .ToDictionary(component => component.GetType());
        
        return this;
    }

    protected T GetComponent<T>() where T : BaseComponent {
        return Components[typeof(T)] as T;
    }

    public virtual void OnProcess(double delta) {}
    public virtual void OnPhysicsProcess(double delta) {}
}