using Godot;
using System;

public partial class VelocityComponent : BaseComponent<RigidBody2D> 
{
	[Export] private float maxSpeed = 300.0f;
	[Export] private float acceleration = 200.0f;
	[Export] private float jumpVelocity = -50.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	public void Move(float direction) {
		Entity.ApplyCentralImpulse(new Vector2(direction * acceleration, 0f));
	}

	public void Jump() {
		Entity.ApplyCentralImpulse(new Vector2(0f, jumpVelocity));
	}
}
