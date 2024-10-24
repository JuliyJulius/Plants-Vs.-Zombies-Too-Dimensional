using Godot;
using System;

public partial class Lawn : Sprite2D
{
	// The size of the lawn in tiles
	public Vector2 lawnSize = new Vector2(
		x: 9,
		y: 5
	);

	// The 0,0 point for tiles
	public Vector2 origin;

	// The size for each tile
	public float tileSize = 80f;

	// The offset for the origin
	private const int ORIGIN_OFFSET = 56;

	// Checks whether a position is within the lawn
	public bool IsPositionWithinLawn(Vector2 rawPosition) {
        // Convert to tile position
        rawPosition -= origin;
        rawPosition /= tileSize;

        // Round the position to the nearest whole number then clamp it within the lawn
        rawPosition = new Vector2(
            x: Mathf.Round(rawPosition.X),
            y: Mathf.Round(rawPosition.Y)
        );

		return rawPosition.X >= 0 && rawPosition.X < lawnSize.X &&
			rawPosition.Y >= 0 && rawPosition.Y < lawnSize.Y;
    }

	// Converts a position to a tile position
	public Vector2 GetTilePosition(Vector2 rawPosition) {
		// Convert to tile position
		rawPosition -= origin;
		rawPosition /= tileSize;

		// Round the position to the nearest whole number then clamp it within the lawn
        rawPosition = new Vector2(
            x: Mathf.Clamp(Mathf.Round(rawPosition.X), 0, lawnSize.X - 1),
            y: Mathf.Clamp(Mathf.Round(rawPosition.Y), 0, lawnSize.Y - 1)
        );

		// Convert back to raw position
		rawPosition *= tileSize;
		rawPosition += origin;

		return rawPosition;
    }

	public override void _Ready()
	{
		origin = new Vector2(
			x: Position.X + ORIGIN_OFFSET,
			y: Position.Y + ORIGIN_OFFSET
        );
    }

	public override void _Process(double delta)
	{

	}
}
