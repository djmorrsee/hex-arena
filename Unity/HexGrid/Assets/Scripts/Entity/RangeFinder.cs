//// Created By Daniel Morrissey
////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using System;

public static class RangeFinder : object
{

    ////////////////////////////////
    //// Class Variables 
    ////////////////////////////////
    // Public
    public static Grid grid;


    // Private


    ////////////////////////////////
    //// Class Methods 
    ////////////////////////////////
    // Public
    public static List<Tile> TilesInRangeFromTile(Tile t, int range)
    {
        List<Tile> tiles = new List<Tile>();

        CubeCoordinates tileCoord = CoordinateSystems.AxialToCube(t.GetAxialCoords());

        for (int i = -range; i <= range; ++i)
        {
            int _i = i + tileCoord.x;
            for (int j = -range; j <= range; ++j)
            {
                int _j = j + tileCoord.y;
                for (int k = -range; k <= range; ++k)
                {
                    int _k = k + tileCoord.z;
                    if (i + j + k == 0)
                    {
                        CubeCoordinates cube = new CubeCoordinates(_i, _j, _k, 0);
                        AxialCoordinates ax = CoordinateSystems.CubeToAxial(cube);

                        Tile _t = grid.TileFromAxialCoordinates(ax);
                        if (_t != null)
                        {
                            tiles.Add(_t);
                        }
                    }
                }
            }
        }


        return tiles;
    }

    public static List<HexEntity> EntitiesInRangeOfTile(Tile t, int range, bool includeSource=false)
    {
        List<HexEntity> entities = new List<HexEntity>();
        foreach (Tile _t in TilesInRangeFromTile(t, range))
        {
            if (!includeSource)
            {
                if (_t == t)
                {
                    continue;
                }
            }

            HexEntity he = _t.OccupantOrNull();
            if (he != null)
            {
                entities.Add(he);
            }
        }
        return entities;
    }

    // Private




}
