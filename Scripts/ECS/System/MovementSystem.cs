using Godot;
using System;

public partial class MovementSystem : BaseSystem
{
	public override Type[] DefineComponents()
    {
        return new Type[] { typeof(InputComponent), };
    }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		// fails if system ready() runs before component ready()
		// move init logic to constructor?
	}
	
	public override void OnTickPhysics(double delta)
	{
		GetComponent<InputComponent>().GetActiveInput().ForEach(kv => GD.Print(kv));
	}
}
