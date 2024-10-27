using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public partial class Entity : RigidBody2D
{
	public Dictionary<Type, BaseComponent> Components { get; private set;}
	public List<BaseSystem> Systems { get; private set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();

		var children = GetChildren();

		Components = children.OfType<BaseComponent>()
			.Select(component => component.Initialize(this))
			.ToDictionary(component => component.GetType());

		Systems = children.OfType<BaseSystem>()
			.Select(system => system.Initialize(this))
			.ToList();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Systems.ForEach(system => system.OnProcess(delta));
	}

	public override void _PhysicsProcess(double delta)
	{
		Systems.ForEach(system => system.OnPhysicsProcess(delta));
	}
}
