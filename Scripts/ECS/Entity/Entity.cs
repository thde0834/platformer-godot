using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Entity : RigidBody2D
{
	private List<BaseSystem> Systems;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		Systems = GetChildren().Where(child => child is BaseSystem).Cast<BaseSystem>().ToList();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public override void _PhysicsProcess(double delta)
	{
		Systems.ForEach(system => system.OnTickPhysics(delta));

	}
}
