//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityController : MonoBehaviour
{

	////////////////////////////////
	//// Class Variables 
	////////////////////////////////
	// Public
	public Grid grid;

	// Private

	

	////////////////////////////////
	//// Mono Methods
	////////////////////////////////
	void Start ()
	{
        grid = GetComponent<Grid>();
        HeroEntity dj = new HeroEntity(0, "dj", grid, true, 10, 10, 1, 5, 3, 2, 1);
        HeroEntity Hondune = new HeroEntity(1, "Hondune", grid, false, 10, 10, 2, 2, 5, 1, 1);

        SpawnEntity(dj, new AxialCoordinates(1, 0, 0), true);
        SpawnEntity(Hondune, new AxialCoordinates(0, 0, 0));
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
	void SpawnEntity (HexEntity e, AxialCoordinates location, bool controllable=false)
	{
        GameObject newEntity = GameObject.CreatePrimitive(PrimitiveType.Cube);
        HexEntityGameObject newEntityGO = newEntity.AddComponent<HexEntityGameObject>();
        newEntityGO.controllable = controllable;

        e.OccupyTile(grid.TileFromAxialCoordinates(location));
        newEntityGO.SetEntity(e);
	}


	
}
