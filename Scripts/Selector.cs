using Godot;
using System;

public partial class Selector : Sprite2D
{
	// The speed at which the selector smooths out its position and alpha values
	// Higher = faster
	private float positionSmoothingSpeed = 10f;
	private float alphaSmoothingSpeed = 5f;

	//Todo: fix the weird warping this does 
    public override void _Process(double delta)
	{
		// Get the Lawn script
		Lawn lawnScript = GetNode<Lawn>($"../Lawn");

		// Get the current mouse position
		Vector2 mousePos = GetViewport().GetMousePosition();

		// Check if the mouse is on the lawn
		bool mouseOnLawn = lawnScript.IsPositionWithinLawn(mousePos);

		// Get the lawn position at the current mouse position then smooth between the current position and the returned position
		Position = Position.Lerp(
			lawnScript.GetTilePosition(mousePos), 
			(float)delta * positionSmoothingSpeed
		);

		// Sets the alpha value to 1 if the mouse is on the lawn and 0 if it is not
		Modulate = Modulate.Lerp(
			new Color(Modulate.R, Modulate.G, Modulate.B, mouseOnLawn ? 1f : 0f), 
			(float)delta * alphaSmoothingSpeed
		);
	}
}
