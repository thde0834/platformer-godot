using Godot;
using System;

public abstract partial class BaseComponent : Node, IUniqueNode {}

public abstract partial class BaseComponent<T> : BaseComponent where T : Node {
    protected T Entity;

    public override void _Ready() {
        base._Ready();
        this.Entity = this.GetOwner<T>();
        GD.Print(this.Entity);
    }
}