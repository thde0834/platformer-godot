using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Entity : RigidBody2D
{
	public List<BaseComponent> Components { get; private set; }
	public List<BaseSystem> Systems { get; private set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		Components = GetChildren().OfType<BaseComponent>().ToList();
		Systems = GetChildren()
			.OfType<BaseSystem>()
			.Select(system => system.Initialize(this))
			.ToList();
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
