using Godot;
using System;
using System.Collections.Generic;

public abstract partial class BaseSystem : Node {
    public virtual void OnTick(double delta) {}
    public virtual void OnTickPhysics(double delta) {}


}