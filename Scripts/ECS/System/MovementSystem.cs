using Godot;
using System;
using System.Linq;

public partial class MovementSystem : BaseSystem
{
	public override Type[] DefineComponentTypes()
    {
        return new Type[] { typeof(InputComponent), typeof(VelocityComponent) };
    }
	
	public override void OnPhysicsProcess(double delta)
	{
		GetComponent<InputComponent>()
			.GetActiveInput()
			.Where(input => input.Key == InputType.Space)
			.ToList()
			.ForEach(_ => GetComponent<VelocityComponent>().Jump());
	}
}
