using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Entity : RigidBody2D
{
	private Dictionary<Type, BaseComponent> Components;
	private Dictionary<Type, BaseSystem> Systems;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		Components = GetChildren().OfType<BaseComponent>().ToDictionary(child => child.GetType());
		Systems = GetChildren().OfType<BaseSystem>().ToDictionary(child => child.GetType());

		Systems.Values.ToList().ForEach(system => 
			system.SetComponents(
				Components
					.Where(kv => system.DefineComponents().Contains(kv.Key))
					.ToDictionary(kv => kv.Key, kv => kv.Value)
			)
		);	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public override void _PhysicsProcess(double delta)
	{
		Systems.Values.ToList().ForEach(system => system.OnTickPhysics(delta));
	}
}
