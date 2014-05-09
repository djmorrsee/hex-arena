//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;

public class Tile : Object
{

	////////////////////////////////
	//// Class Variables 
	////////////////////////////////
	// Public
	public bool active;
	
	public bool occupied;
	public Entity occupant = null;
	
	public AxialCoordinates aCoord;
	public XYZCoordinates xyCoord;
	
	public Vector3 worldLocation;


	// Private


	
	// Temp
	public void SpawnCube ()
	{
		GameObject cube = (GameObject)GameObject.CreatePrimitive (PrimitiveType.Quad);
		cube.transform.parent = Camera.main.transform;
		cube.transform.position = worldLocation;
		cube.transform.Rotate (Vector3.right * 90);
		cube.name = string.Format ("{0} --- {1}", xyCoord, aCoord);
	}
	
	public override string ToString ()
	{
		return string.Format ("XY: {0} A: {1}", xyCoord, aCoord);
	}

	// Private
	public bool Occupy (Entity e)
	{
		if (occupied) {
			
			return false;
		}
		occupant = e;
		occupied = true;
		
		return true;
	}
	
	public void Vacate ()
	{
		occupant = null;
		occupied = false;
	}


	
}
