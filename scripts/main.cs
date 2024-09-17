using Godot;
using System;

public partial class main : Node2D
{
	[Export]
    public PackedScene puckScene { get; set; }

    private int redScore = 0, blueScore = 0;


	public void NewGame()
	{
		redScore = blueScore = 0;

		var puck = GetNode<RigidBody2D>("puck");
		var leftStick = GetNode<RigidBody2D>("blue");
		var rightStick = GetNode<RigidBody2D>("red");

		var puckStartPosition = GetNode<Marker2D>("PuckStartPosition");
		var leftStickStartPosition = GetNode<Marker2D>("LeftStickStartPosition");
		var rightStickStartPosition = GetNode<Marker2D>("RightStickStartPosition");

		
        // Перемещаем объекты на стартовые позиции
        puck.Position = puckStartPosition.Position;
        leftStick.Position = leftStickStartPosition.Position;
        rightStick.Position = rightStickStartPosition.Position;


	}

	public override void _Ready()
	{
		NewGame();
	}

	public override void _Process(double delta)
	{

	}

	public void onLeftGatesEntered(Node2D body)
	{
		NewGame();
	}

	public void onRightGatesEntered(Node2D body)
	{
		NewGame();
	}
}
