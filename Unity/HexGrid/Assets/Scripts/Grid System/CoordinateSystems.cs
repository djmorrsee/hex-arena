//// Created By Daniel Morrissey
////////////////////////////////
//// Structs Define Coordinate Systems for the Hex Grid
//// Class Contains Conversion Behaviour
using System;
using UnityEngine;

public enum MoveDirection
{
    upr,
    right,
    downr,
    downl,
    left,
    upl,
}

[System.Serializable]
public class XYZCoordinates
{
    public int x;
    public int y;
    public int height;

    public XYZCoordinates(int _x = 0, int _y = 0, int _height = 0)
    {
        x = _x;
        y = _y;
        height = _height;
    }

    public static bool operator ==(XYZCoordinates x, XYZCoordinates y)
    {
        return x.x == y.x && x.y == y.y && x.height == y.height;
    }
    public static bool operator !=(XYZCoordinates x, XYZCoordinates y)
    {
        return x.x != y.x || x.y != y.y || x.height != y.height;
    }

    public override bool Equals(System.Object o)
    {
        if (o is XYZCoordinates)
        {
            XYZCoordinates _o = (XYZCoordinates)o;
            return x == _o.x && y == _o.y && height == _o.height;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return x ^ y ^ height;
    }

    public override string ToString()
    {
        return string.Format("({0}, {1}, {2})", x, y, height);
    }
}

[System.Serializable]
public class CubeCoordinates
{
    public int x;
    public int y;
    public int z;

    public int height;

    public CubeCoordinates(int _x = 0, int _y = 0, int _z = 0, int _h = 0)
    {
        x = _x;
        y = _y;
        z = _z;
        height = _h;
    }

    public static bool operator ==(CubeCoordinates x, CubeCoordinates y)
    {
        return x.x == y.x && x.y == y.y && x.z == y.z && x.height == y.height;
    }
    public static bool operator !=(CubeCoordinates x, CubeCoordinates y)
    {
        return x.x != y.x || x.y != y.y || x.z != y.z || x.height != y.height;
    }

    public override bool Equals(System.Object o)
    {
        if (o is CubeCoordinates)
        {
            CubeCoordinates _o = (CubeCoordinates)o;
            return x == _o.x && y == _o.y && z == _o.z && height == _o.height;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return x ^ y ^ z ^ height;
    }

    public override string ToString()
    {
        return string.Format("({0}, {1}, {2}, {3})", x, y, z, height);
    }
}

[System.Serializable]
public class AxialCoordinates
{
    public int q;
    public int r;
    public int h;

    public AxialCoordinates(int _q = 0, int _r = 0, int _h = 0)
    {
        q = _q;
        r = _r;
        h = _h;
    }

    public static bool operator ==(AxialCoordinates x, AxialCoordinates y)
    {
        return x.q == y.q && x.r == y.r && x.h == y.h;
    }
    public static bool operator !=(AxialCoordinates x, AxialCoordinates y)
    {
        return x.q != y.q || x.r != y.r || x.h != y.h;
    }

    public override bool Equals(System.Object o)
    {
        if (o is AxialCoordinates)
        {
            AxialCoordinates _o = (AxialCoordinates)o;
            return q == _o.q && r == _o.r && h == _o.h;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return q ^ r ^ h;
    }

    public override string ToString()
    {
        return string.Format("({0}, {1}, {2})", q, r, h);
    }
}

public static class CoordinateSystems : object
{
    public static AxialCoordinates XYToAxial(XYZCoordinates coord)
    {
        CubeCoordinates cube = XYToCube(coord);
        AxialCoordinates ax = CubeToAxial(cube);

        return ax;
    }

    public static AxialCoordinates CubeToAxial(CubeCoordinates coord)
    {
        AxialCoordinates ax = new AxialCoordinates();

        ax.q = coord.x;
        ax.r = coord.z;
        ax.h = coord.height;

        return ax;
    }

    public static XYZCoordinates AxialToXY(AxialCoordinates coord)
    {

        CubeCoordinates cube = AxialToCube(coord);
        XYZCoordinates xy = CubeToXY(cube);

        return xy;
    }

    public static XYZCoordinates CubeToXY(CubeCoordinates coord)
    {
        XYZCoordinates xy = new XYZCoordinates();

        xy.x = coord.x + (coord.z - (coord.z & 1)) / 2;
        xy.y = coord.z;
        xy.height = coord.height;

        return xy;
    }

    public static CubeCoordinates AxialToCube(AxialCoordinates coord)
    {
        CubeCoordinates cube = new CubeCoordinates();
        cube.x = coord.q;
        cube.z = coord.r;
        cube.y = -cube.x - cube.z;

        cube.height = coord.h;
        return cube;
    }

    public static CubeCoordinates XYToCube (XYZCoordinates coord)
    {
        CubeCoordinates cube = new CubeCoordinates();
        cube.x = coord.x - (coord.y - (coord.y & 1)) / 2;
        cube.z = coord.y;
        cube.y = -cube.x - cube.z;

        cube.height = coord.height;
        return cube;
    }

}
