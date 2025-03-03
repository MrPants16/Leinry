using Godot;
using System;

public partial class CameraControllerNode : Node3D
{
	[Export]
	public int Sensitivity = 5;
	CharacterBody3d character;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		character = GetTree().GetNodesInGroup("Player")[0] as CharacterBody3d;
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition = character.GlobalPosition;
		GlobalPosition += new Vector3(0, 1.5f, -0.34f);
	}
	
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		
		if (Input.IsActionPressed("MouseCapture"))
			{
				Input.MouseMode = Input.MouseModeEnum.Captured;
			}
			
		if (Input.IsActionPressed("MouseRelease"))
			{
				Input.MouseMode = Input.MouseModeEnum.Visible;
			}
		
		if(@event is InputEventMouseMotion)
		{
			InputEventMouseMotion motion = (InputEventMouseMotion) @event;
			Rotation = new Vector3(Mathf.Clamp(Rotation.X - motion.Relative.Y / 1000 * Sensitivity, -1, 1f),
				Rotation.Y - motion.Relative.X / 1000 * Sensitivity, 0);
		
		}
	}
}
