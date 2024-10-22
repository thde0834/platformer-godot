using Godot;
using System;
using System.Linq;
using System.Collections.Generic;

public partial class InputComponent : BaseComponent<Node2D> 
{	
	private Dictionary<InputType, float> activeInput = new();

	private Dictionary<InputEvent, InputType> actionCache = new();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		Enumeration.GetAll<InputType>()
			.ToList()
			.ForEach(value => activeInput.Add(value, 0f));
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		Enumerable.Repeat(@event, 1)
			.Where(it => !it.IsEcho())
			.Select(it => GetCachedType(it))
			.Where(type => type != null)
			.ToList()
			.ForEach(type => {
				activeInput[type] = @event.IsActionPressed(type.Name, true) 
					? 1f 
					: 0f;
				GD.Print(type + ": " + activeInput[type]);
			});
	}

	private InputType GetCachedType(InputEvent @event) {
		InputType value;
		return actionCache.TryGetValue(@event, out value)
			? value
			: actionCache[@event] = InputType.GetAll<InputType>()
					.FirstOrDefault(value => @event.IsAction(value.Name, true));
	}

	public List<KeyValuePair<InputType, float>> GetActiveInput() {
		return activeInput
			.Where(pair => pair.Value != 0f)
			.ToList();
	}
	
}
