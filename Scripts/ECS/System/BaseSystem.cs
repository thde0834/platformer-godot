using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public abstract partial class BaseSystem : Node {
    protected Dictionary<Type, BaseComponent> Components;
    protected T GetComponent<T>() where T : BaseComponent {
        return Components[typeof(T)] as T;
    }
    
    public abstract Type[] DefineComponentTypes();
    public BaseSystem Initialize(Entity entity) {
        var types = DefineComponentTypes();
        this.Components = entity.Components
            .Join(
                types,
                component => component.GetType(),
                type => type,
                (component, type) => component
            )
            .ToDictionary(component => component.GetType());

        return this;
    }

    public virtual void OnTick(double delta) {}
    public virtual void OnTickPhysics(double delta) {}
}