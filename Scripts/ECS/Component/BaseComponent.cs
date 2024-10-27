using Godot;
using System;

public abstract partial class BaseComponent : Node {
    public abstract BaseComponent Initialize(Entity entity);
}

public abstract partial class BaseComponent<T> : BaseComponent where T : Node {
    protected T Entity;
    public override BaseComponent<T> Initialize(Entity entity)
    {
        this.Entity = entity as T;
        return this;
    }
}