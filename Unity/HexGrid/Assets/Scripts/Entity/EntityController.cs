//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityController : ScriptableObject
{

    ////////////////////////////////
    //// Class Variables 
    ////////////////////////////////
    // Public

    // Private
    Grid grid;

    List<IActiveEntity> teamOne = new List<IActiveEntity>();
    List<IActiveEntity> teamTwo = new List<IActiveEntity>();


    ////////////////////////////////
    //// Class Methods 
    ////////////////////////////////
    // Public
    public void SetGrid(Grid _grid)
    {
        grid = _grid;
    }

    public void AddEntityToTeam(IActiveEntity e, bool isTeamOne)
    {
        if (isTeamOne)
        {
            teamOne.Add(e);
            SpawnEntity((HexEntity)(e), new AxialCoordinates(0, 0, 0), true);
        }
        else
        {
            teamTwo.Add(e);
            SpawnEntity((HexEntity)(e), new AxialCoordinates(-1, 0, 0));
        }

    }

    public List<IActiveEntity> GetTeamOne()
    {
        return teamOne;
    }

    public List<IActiveEntity> GetTeamTwo()
    {
        return teamTwo;
    }

    // Private
    void SpawnEntity(HexEntity e, AxialCoordinates location, bool controllable = false)
    {
        GameObject newEntity = GameObject.CreatePrimitive(PrimitiveType.Cube);
        HexEntityGameObject newEntityGO = newEntity.AddComponent<HexEntityGameObject>();
        newEntityGO.controllable = controllable;

        e.OccupyTile(grid.TileFromAxialCoordinates(location));
        newEntityGO.SetEntity(e);
    }
}
