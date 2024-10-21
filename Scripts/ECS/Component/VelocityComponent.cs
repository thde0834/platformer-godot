using Godot;
using System;

public partial class VelocityComponent : BaseComponent<RigidBody2D> 
{
	[Export] private float maxSpeed = 300.0f;
	[Export] private float acceleration = 200.0f;
	[Export] private float jumpVelocity = -400.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	public void Move() {

	}
}
