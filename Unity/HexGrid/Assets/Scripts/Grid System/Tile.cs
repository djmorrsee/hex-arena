//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
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


    // Private
    public void SpawnCube()
    {
        GameObject cube = (GameObject)GameObject.CreatePrimitive(PrimitiveType.Quad);
        cube.transform.parent = Camera.main.transform;
        cube.transform.position = worldLocation;
        cube.transform.Rotate(Vector3.right * 90);
        cube.name = string.Format("{0} --- {1}", xyCoord, aCoord);
    }

    public void SetGrid(Grid _grid)
    {
        grid = _grid;
    }

    public override string ToString()
    {
        return string.Format("XY: {0} A: {1}", xyCoord, aCoord);
    }

    // Private
    public bool Occupy(HexEntity e)
    {
        if (occupied)
        {

            return false;
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

}
