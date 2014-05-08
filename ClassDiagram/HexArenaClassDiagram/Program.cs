using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexArenaClassDiagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This Project Stores the Class Diagram for the HexArena Unity Project");
            Console.ReadKey();
        }
    }

    public class Grid
    {
        private Tile[][] tiles;

        public Tile TileFromAxialCoord(AxialCoordinates coord)
        {
            throw new System.NotImplementedException();
        }

        public void TileInDirection(AxialCoordinates origin, MoveDirection direction)
        {
            throw new System.NotImplementedException();
        }
    }

    public struct AxialCoordinates
    {
        private int q;
        private int r;
    }

    public enum MoveDirection
    {
        up,
        upr,
        upl,
        down,
        downl,
        downr,
    }

    public class Tile
    {
        private AxialCoordinates coord;
        private bool occupied;
        private Vector3 location;
        private Entity occupant;
    }

    public struct Vector3
    {
    }

    public struct Vector2
    {
    }

    public class HAInput
    {
        private UIContext inputContext;
    }

    public enum UIContext
    {
        WelcomeScreen,
        MainMenu,
        GameScreen,
    }

    public interface IAttackable
    {
        int target
        {
            get;
            set;
        }

        void Attack();
    }

    public class StationaryEntity : ActiveEntity
    {
    }

    public class MovableEntity : ActiveEntity
    {
        public void Move(MoveDirection direction)
        {
            throw new System.NotImplementedException();
        }
    }
}
