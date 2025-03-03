using Godot;
using System;

public partial class Label : Godot.Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	public override void _PhysicsProcess(double delta)
	{
		string display_stamina = Convert.ToString(CharacterBody3d.current_stamina);
		Text = ("Stamina: " + display_stamina);
	}
}
