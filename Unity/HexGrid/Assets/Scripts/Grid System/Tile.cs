//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System;
using System.Collections;

public class Tile : ScriptableObject
{

    ////////////////////////////////
    //// Class Variables 
    ////////////////////////////////
    // Public
    public bool active;

    public bool occupied;
    public HexEntity occupant = null;

    public AxialCoordinates aCoord;
    public XYZCoordinates xyCoord;

    public Vector3 worldLocation;

    public Grid grid;

    GameObject tileObject;


    // Private
    public void SpawnCube(Transform _parent = null)
    {
        tileObject = (GameObject)GameObject.CreatePrimitive(PrimitiveType.Quad);
        tileObject.transform.parent = _parent;
        tileObject.transform.position = worldLocation;
        tileObject.transform.Rotate(Vector3.right * 90);
        tileObject.name = string.Format("{0} --- {1}", xyCoord, aCoord);
    }

    public void SetGrid(Grid _grid)
    {
        grid = _grid;
    }

    public override string ToString()
    {
        return string.Format("XY: {0} A: {1}", xyCoord, aCoord);
    }

    public Tile TileInDirection(MoveDirection dir)
    {
        return grid.TileInDirectionFromTile(this, dir);
    }

    // Private
    public bool Occupy(HexEntity e)
    {
        if (occupied)
        {

            throw new System.Exception("Already Occupied!");
        }
        occupant = e;
        occupied = true;

        return true;
    }

    public void Vacate()
    {
        occupant = null;
        occupied = false;
    }

    public void Highlight()
    {
        tileObject.renderer.material.color = Color.white;
    }

    public void Dehighlight()
    {
        tileObject.renderer.material.color = Color.red;
    }

}
