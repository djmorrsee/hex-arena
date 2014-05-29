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

    public void AddEntityToTeam(IActiveEntity e, bool isTeamOne = false)
    {
        if (isTeamOne)
        {
            teamOne.Add(e);
            SpawnEntity((HexEntity)(e), OpenAxialCoordForTeam(isTeamOne), true);
        }
        else
        {
            teamTwo.Add(e);
            SpawnEntity((HexEntity)(e), OpenAxialCoordForTeam(isTeamOne));
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

    AxialCoordinates OpenAxialCoordForTeam(bool teamOne)
    {
        AxialCoordinates ax;

        if (teamOne)
        {

            ax =  new AxialCoordinates(-grid.GetWidth() / 2, 0, 0);
        }
        else
        {
            ax =  new AxialCoordinates(grid.GetWidth() / 2, 0, 0);
        }


        return ax;
    }

}
