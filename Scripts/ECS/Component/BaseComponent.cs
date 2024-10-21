using Godot;
using System;

public abstract partial class BaseComponent<T> : Node where T : Node {
    protected T Entity;

    public override void _Ready() {
        this.Entity = this.GetOwner<T>();
        GD.Print(this.Entity);
    }
}