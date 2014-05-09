//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{

	////////////////////////////////
	//// Class Variables 
	////////////////////////////////
	// Public
	public int gridHeight;
	public int gridWidth;
	
	public float hexSize;

	// Private
	Tile[,] grid;
	List<Entity> enitites = new List<Entity> ();

	////////////////////////////////
	//// Mono Methods
	////////////////////////////////
	void Start ()
	{
		grid = CreateGrid ();
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		djmorrseeEntity dj = cube.AddComponent<djmorrseeEntity> ();
		cube.renderer.material.color = Color.red;
		
		SpawnEntity (dj, new AxialCoordinates (0, 0, 0));
		
	}

	void Update ()
	{

	}
	/*
	void FixedUpdate () {

	}

	void OnGUI () {

	}
	*/
	
	////////////////////////////////
	//// Class Methods 
	////////////////////////////////
	// Public



	// Private
	Tile[,] CreateGrid ()
	{
		float height = 2 * hexSize;
		float width = Mathf.Sqrt (3f) / 2f * height;
		
		float dw = width;
		float dh = (3f / 4f) * height;
		
		Tile[,] newGrid = new Tile[gridWidth, gridHeight];
		
		for (int i = 0; i < gridHeight; ++i) {
			for (int j = 0; j < gridWidth; ++j) {
			
				Tile thisTile = new Tile ();
				
				float yPos = i * -dh;
				float xPos = j * dw;
				if ((i & 1) == 1) {
					xPos += 0.5f * dw;
				}
				
				thisTile.worldLocation = new Vector3 (xPos, 0, yPos);
				thisTile.xyCoord = CoordsFromIndices (j, i);
				thisTile.aCoord = CoordinateSystems.XYToAxial (thisTile.xyCoord);
				
				thisTile.SpawnCube ();
				thisTile.active = true;
				
				newGrid [j, i] = thisTile;
			}
		}
		return newGrid;
	}
	
	Tile TileFromAxialCoordinates (AxialCoordinates coord)
	{
		XYZCoordinates xy = CoordinateSystems.AxialToXY (coord);
		Vector2 ind = IndicesFromCoords (xy);
		return grid [(int)ind.x, (int)ind.y];
	}
	
	XYZCoordinates CoordsFromIndices (int x, int y)
	{
		x -= gridWidth / 2;
		y -= gridHeight / 2;
		return new XYZCoordinates (x, y, 0);
	}
	
	Vector2 IndicesFromCoords (XYZCoordinates coords)
	{
		coords.x += gridWidth / 2;
		coords.y += gridHeight / 2;
		return new Vector2 (coords.x, coords.y);
	}
	
	public Tile TileInDirectionFromTile (Tile t, MoveDirection dir)
	{
		AxialCoordinates ax = t.aCoord;
		
		switch (dir) {
		case MoveDirection.downl:
			ax.q -= 1;
			ax.r += 1;
			break;
		case MoveDirection.downr:
			ax.r += 1;
			break;
		case MoveDirection.left:
			ax.q -= 1;
			break;
		case MoveDirection.right:
			ax.q += 1;		
			break;
		case MoveDirection.upl:
			ax.r -= 1;
			break;
		case MoveDirection.upr:
			ax.q += 1; 
			ax.r -= 1;
			break;
		}
		return TileFromAxialCoordinates (ax);
	}
	
	void SpawnEntity (Entity e, AxialCoordinates location)
	{
		e.grid = this;
		
		Tile thisTile = TileFromAxialCoordinates (location);
		if (thisTile.Occupy (e)) {
			e.currentTile = thisTile;
		}
	}

	
}