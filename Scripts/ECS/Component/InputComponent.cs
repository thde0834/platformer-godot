using Godot;
using System;
using System.Linq;

public partial class InputComponent : BaseComponent<Node2D> 
{	
	private enum InputEnum
    {
        ui_left, ui_right,
        ui_up, ui_down,
    }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		string input = Enum.GetNames(typeof(InputEnum)).FirstOrDefault(val => @event.IsActionPressed(val));
		HandleMovement(@event);
	}

	public void HandleMovement(InputEvent @event) {
		GD.Print(new InputAxis(
			(@event.IsActionPressed(InputEnum.ui_right.ToString())) ? 1f : 0f,
			(@event.IsActionPressed(InputEnum.ui_left.ToString())) ? 1f : 0f
		).Value);
	}
	
}
