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
		var puckStartPosition = GetNode<Marker2D>("PuckStartPosition");
		puck.Position = puckStartPosition.Position;

	}




	public override void _Ready()
	{
		NewGame();
	}




	public override void _Process(double delta)
	{
	}
}
