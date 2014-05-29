//// Created By Daniel Morrissey
////////////////////////////////

using System.Collections;
using System.Collections.Generic;

public class HexEntity : object
{
    //// Summary
    // Defines an object which occupies a tile within our grid

    ////////////////////////////////
    //// Class Variables 
    ////////////////////////////////
    // Public
    public HexEntity(int _id, string _name)
    {
        entityID = _id;
        entityName = _name;
    }


    // Private ivars
    protected int entityID;
    protected string entityName;

    protected List<Tile> tilesOccupied = new List<Tile>();

    ////////////////////////////////
    //// Class Methods 
    ////////////////////////////////
    // Public Properties
    public int EntityID
    {
        get { return entityID; }
        set { entityID = value; }
    }

    public string EntityName
    {
        get { return entityName; }
        set { entityName = value; }
    }



    public override string ToString()
    {
        string s = "";
        foreach (Tile t in this.tilesOccupied)
        {
            s += t.ToString() + " ";
        }

        return s;
    }

    /////////////////
    // Public Methods
    public void OccupyTile(Tile t)
    {
        tilesOccupied.Add(t);
        t.Occupy(this);
    }

    public void VacateTile(Tile t)
    {
        if (tilesOccupied.Contains(t))
        {
            tilesOccupied.Remove(t);
            t.Vacate();
        }
    }

    public Tile GetMainTile()
    {
        return this.tilesOccupied[0];
    }
}

public interface IActiveEntity
{
    // An Entity That has UP and takes a turn

    // Interface Properties
    int UPMax { get; set; }
    int UPCurrent { get; set; }

    bool IsThisTurn { get; set; }

    // Interface Methods
    void InitializeUPValues(int amount);

    void DoAction(int cost);
    void ChangeMaxUP(int amount);

    bool CanDoAction(int cost);

    void ResetUP();


    void EndTurn();
    void StartTurn();
}

public interface IMoveableEntity
{
    // An Entity That Can Move Tiles
    int MoveCost { get; set; }

    void Move(MoveDirection direction);
    void InitMoveCost(int cost);
}

public interface IDamageableEntity
{
    // An Entity that has hp and takes damage
    // Interface Properties
    int HPMax { get; set; }
    int HPCurrent { get; set; }

    int DefensePower { get; set; }

    // Interface Methods
    void InitializeHPValues(int startingHP, int startingDP);

    int DoDamage(int damage);
    int ChangeMaxHealth(int amount);

    void BeDestroyed();
}

public interface IAttackableEntity
{
    // An Entity that can attack
    // Interface Properties
    int AttackPower { get; set; }
    int AttackCost { get; set; }
    int AttackRange { get; set; }

    // Interface Methods
    void AttackEntity(IDamageableEntity entity);
    void InitAttackValues(int cost, int power, int range);
    List<HexEntity> EntitiesInRange();
}

public delegate void Skill(MoveDirection dir);
public interface ISkillableEntity
{
    // An Entity with an array of skills 

    int[] SkillCosts { get; set; }

    int[] SkillLevels { get; set; }

    Skill Skill01 { get; set; }
    Skill Skill02 { get; set; }


}

