//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;

[System.Serializable]
public class S_XYCoords : object
{
    [SerializeField]
    private int x;
    [SerializeField]
    private int y;
    [SerializeField]
    private int h;

    public S_XYCoords(int _x, int _y, int _h)
    {
        x = _x;
        y = _y;
        h = _h;
    }

    public S_XYCoords() : this(0, 0, 0) { }
    public S_XYCoords(XYZCoordinates coord) : this(coord.x, coord.y, coord.height) { }

    public void SetCoords(int _x, int _y, int _h)
    {
        x = _x;
        y = _y;
        h = _h;
    }
    public void SetCoords(XYZCoordinates coord)
    {
        SetCoords(coord.x, coord.y, coord.height);
    }


    public override string ToString()
    {
        return string.Format("({0}, {1}, {2})", x, y, h);
    }
}

[System.Serializable]
public class S_CubeCoords : object
{
    [SerializeField]
    private int x;
    [SerializeField]
    private int y;
    [SerializeField]
    private int z;
    [SerializeField]
    private int h;

    public S_CubeCoords(int _x, int _y, int _z, int _h)
    {
        x = _x;
        y = _y;
        z = _z;
        h = _h;
    }

    public S_CubeCoords() : this(0, 0, 0, 0) { }
    public S_CubeCoords(CubeCoordinates coord) : this(coord.x, coord.y, coord.z, coord.height) { }


    public void SetCoords(int _x, int _y, int _z, int _h)
    {
        x = _x;
        y = _y;
        z = _z;
        h = _h;
    }
    public void SetCoords(CubeCoordinates coord)
    {
        SetCoords(coord.x, coord.y, coord.z, coord.height);
    }

    public override string ToString()
    {
        return string.Format("({0}, {1}, {2}, {3})", x, y, z, h);
    }
}

[System.Serializable]
public class S_AxialCoords : object
{
    [SerializeField]
    private int q;
    [SerializeField]
    private int r;
    [SerializeField]
    private int h;

    public S_AxialCoords(int _q, int _r, int _h)
    {
        q = _q;
        r = _r;
        h = _h;
    }

    public S_AxialCoords() : this(0, 0, 0) { }
    public S_AxialCoords(AxialCoordinates coord) : this(coord.q, coord.r, coord.h) { }

    public void SetCoords(int _q, int _r, int _h)
    {
        q = _q;
        r = _r;
        h = _h;
    }
    public void SetCoords(AxialCoordinates coords)
    {
        SetCoords(coords.q, coords.r, coords.h);
    }

    public override string ToString()
    {
        return string.Format("({0}, {1}, {2})", q, r, h);
    }
}