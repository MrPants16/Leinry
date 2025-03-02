using Godot;
using System;

public partial class CharacterBody3d : CharacterBody3D
{
	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;
	public const float max_stamina = 100.0f;
	public const float current_stamina = 100.0f;
	public const float stamina_recovery_rate = 1.0f;  // How fast stamina recovers over time

	public override void _Ready()
	{
		
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;
		
		//if (current_stamina < max_stamina)
			{
			//float current_stamina = current_stamina + stamina_recovery_rate * Convert.ToSingle(delta);
			//GD.Print("Stamina: ", current_stamina);
			//current_stamina = clamp(current_stamina, 0, max_stamina);
			}
			
		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
			//float stamina_cost = 10.0f;
			//float new_stamina = current_stamina - stamina_cost;
			//float current_stamina = new_stamina;
		}
		
			
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			if (Input.IsActionPressed("ui_run"))
				{
				float Speed = 8.5f;
				velocity.X = direction.X * Speed;
				velocity.Z = direction.Z * Speed;
				}
			else
				{
				float Speed = 5.0f;
				velocity.X = direction.X * Speed;
				velocity.Z = direction.Z * Speed;
				}
			
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
