using Godot;
using System;

public partial class MovementSystem : BaseSystem
{
	[Export] private InputComponent inputComponent;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		// fails if system ready() runs before component ready()
		// move init logic to constructor?
		GD.Print(IUniqueNode.GetUniqueName<InputComponent>());
	}
	
	public override void OnTickPhysics(double delta)
	{
		inputComponent.GetActiveInput().ForEach(kv => GD.Print(kv));
	}
}
