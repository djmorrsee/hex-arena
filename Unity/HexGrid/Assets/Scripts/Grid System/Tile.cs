//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;

[System.Serializable]
public class Tile : ScriptableObject
{
    ////////////////////////////////
    //// Class Variables 
    ////////////////////////////////
    bool active;
    bool occupied;

    HexEntity occupant = null;

    AxialCoordinates aCoord;
    public AxialCoordinates GetAxialCoords()
    {
        return aCoord;
    }

    XYZCoordinates xyCoord;
    public XYZCoordinates GetXYCoords()
    {
        return xyCoord;
    }

    Vector3 worldLocation;
    public Vector3 GetWorldLocation()
    {
        return worldLocation;
    }

    Grid grid;
    GameObject go = null;

    // Public Methods
    public void Init(Grid _grid, Vector3 worldPos, XYZCoordinates _xyCoord, bool _active = true, bool createObject = false, Transform _p = null)
    {
        grid = _grid;
        worldLocation = worldPos;
        xyCoord = _xyCoord;
        aCoord = CoordinateSystems.XYToAxial(_xyCoord);
        active = _active;

        if (createObject)
        {
            SpawnGameObjectForTile(_p);
        }
    }

    public Tile TileInDirection(MoveDirection dir)
    {
        return grid.TileInDirectionFromTile(this, dir);
    }
    
    // Occupant Methods
    public bool IsOpen()
    {
        return active && !occupied;
    }

    public HexEntity OccupantOrNull()
    {
        if (!occupied)
        {
            return null;
        }
        else
        {
            return occupant;
        }
    }

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

    public void Deactivate()
    {
        active = false;
        if (go != null)
        {
            Destroy(go);
        }
    }

    public void Radiate()
    {
        go.renderer.material.color = Color.blue;
    }

    // Private Methods
    void SpawnGameObjectForTile (Transform p = null) {
        GameObject cube = (GameObject)HexTileGameObject.HexTileGO();
        cube.transform.parent = p;
        cube.transform.position = worldLocation;
        cube.transform.Rotate(Vector3.right * 90);
        cube.name = string.Format("{0} --- {1}", xyCoord, aCoord);
        go = cube;
    }

}
