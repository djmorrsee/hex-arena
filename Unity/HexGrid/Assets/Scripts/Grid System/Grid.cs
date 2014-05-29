//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

[System.Serializable]
public class Grid : ScriptableObject
{

    ////////////////////////////////
    //// Class Variables 
    ////////////////////////////////
    // Public


    // Private
    [SerializeField]Tile[,] grid;

    List<Tile> teamOneEndZone;
    List<Tile> teamTwoEndZone;

    [SerializeField]int gridHeight;
    public int GetHeight()
    {
        return gridHeight;
    }
    [SerializeField]int gridWidth;
    public int GetWidth()
    {
        return gridWidth;
    }

    [SerializeField]float hexSize;


    ////////////////////////////////
    //// Class Methods 
    ////////////////////////////////
    // Public
    public void CreateGrid(int _gridHeight, int _gridWidth, float _hexSize)
    {
        gridHeight = _gridHeight;
        gridWidth = _gridWidth;
        hexSize = _hexSize;

        GameObject g = new GameObject("Grid");
        g.transform.position = Vector3.zero;

        float height = 2 * hexSize;
        float width = Mathf.Sqrt(3f) / 2f * height;

        float dw = width;
        float dh = (3f / 4f) * height;

        Tile[,] newGrid = new Tile[gridWidth, gridHeight];

        for (int i = 0; i < gridHeight; ++i)
        {
            for (int j = 0; j < gridWidth; ++j)
            {

                Tile thisTile = ScriptableObject.CreateInstance<Tile>();

                float yPos = i * -dh;
                float xPos = j * dw;
                if ((i & 1) == 1)
                {
                    xPos += 0.5f * dw;
                }
                Vector3 wp = new Vector3(xPos, 0, yPos);
                XYZCoordinates xy = CoordsFromIndices(j, i);


                thisTile.Init(this, wp, xy, true, true, g.transform);
                newGrid[j, i] = thisTile;
            }
        }
        this.grid = newGrid;
        SetActiveTiles();
        SetEndZones();
    }

    public Tile TileFromAxialCoordinates(AxialCoordinates coord)
    {
        XYZCoordinates xy = CoordinateSystems.AxialToXY(coord);
        Vector2 ind = IndicesFromCoords(xy);

        if (!(ind.x < 0 || ind.y < 0 || ind.x >= gridWidth || ind.y >= gridHeight))
        {
            Tile t = grid[(int)ind.x, (int)ind.y];
            return t;
        }

        return null;
    }

    public Tile TileInDirectionFromTile(Tile t, MoveDirection dir)
    {
        AxialCoordinates ax = t.GetAxialCoords();

        switch (dir)
        {
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
        return TileFromAxialCoordinates(ax);
    }


    // Private Methods
    XYZCoordinates CoordsFromIndices(int x, int y)
    {
        x -= gridWidth / 2;
        y -= gridHeight / 2;
        return new XYZCoordinates(x, y, 0);
    }

    Vector2 IndicesFromCoords(XYZCoordinates coords)
    {
        coords.x += gridWidth / 2;
        coords.y += gridHeight / 2;

        if (coords.x < 0)
        {
            coords.x = 0;
        }
        if (coords.y < 0)
        {
            coords.y = 0;
        }
        return new Vector2(coords.x, coords.y);
    }

    void SetActiveTiles()
    {
        List<Tile> activeTiles = RangeFinder.TilesInRangeFromTile(TileFromAxialCoordinates(new AxialCoordinates()), gridWidth / 2);
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                if (!activeTiles.Contains(grid[i, j]))
                {
                    Tile t = grid[i, j];
                    t.Deactivate();
                }
            }

        }
    }

    void SetEndZones()
    {
        List<Tile> endZones = new List<Tile>();
        
        teamOneEndZone = RangeFinder.TilesInRangeFromTile(TileFromAxialCoordinates(new AxialCoordinates(-gridWidth / 2, 0, 0)), gridHeight / 4 + 1);
        teamTwoEndZone = RangeFinder.TilesInRangeFromTile(TileFromAxialCoordinates(new AxialCoordinates(gridWidth / 2, 0, 0)), gridHeight / 4 + 1);
        foreach (Tile t in teamOneEndZone.Concat(teamTwoEndZone))
        {
            t.Radiate();
        }
    }
}