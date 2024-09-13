// using Godot;
// using System;

// public partial class puck : RigidBody2D
// {
// 	// Called when the node enters the scene tree for the first time.
// 	public override void _Ready()
// 	{
// 	}

// 	// Called every frame. 'delta' is the elapsed time since the previous frame.
// 	public override void _Process(double delta)
// 	{
// 	}
// }


using Godot;
using System;

public partial class stick : RigidBody2D
{
    [Flags]
    public enum Colors
    {
        Blue = 1 << 1,
        Red = 1 << 2
    }

    [Flags]
    public enum Sides
    {
        Left = 1 << 1,
        Right = 1 << 2
    }

    [Export]
	public float Speed = 200f;
    [Export]
    public Colors color { get; set; }
    [Export]
    public Sides side { get; set; }
    public String sideStr;

    public override void _Ready()
    {
        var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        if(color == Colors.Blue){
            animatedSprite2D.Play("blue");
        }
        else if(color == Colors.Red){
            animatedSprite2D.Play("red");
        }

        if(side == Sides.Left)
        {
            sideStr =  "left";
        }
        else if(side == Sides.Right)
        {
            sideStr = "right";
        }
    }

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction;

        // Получаем оси джойстика
        direction.X = Input.GetActionStrength(sideStr + "PlayerRight") - Input.GetActionStrength(sideStr + "PlayerLeft");
        direction.Y = Input.GetActionStrength(sideStr + "PlayerBottom") - Input.GetActionStrength(sideStr + "PlayerUp");
        Vector2 forceImpulse = new Vector2(0, 0);
        
        //forceImpulse = LinearVelocity * 10.7f;
        //ApplyForce(forceImpulse);
        LinearVelocity *= 0.9f;
        ApplyForce(direction * Speed * (float)delta * 10000);
        //LinearVelocity += direction * Speed * (float)delta;
        

	}
}