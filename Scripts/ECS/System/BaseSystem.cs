using Godot;
using System;

public abstract partial class BaseSystem : Node {
    public virtual void OnTick(double delta) {}
    public virtual void OnTickPhysics(double delta) {}
}