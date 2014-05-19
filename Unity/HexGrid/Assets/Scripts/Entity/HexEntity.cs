﻿//// Created By Daniel Morrissey
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
    public HexEntity(int _id, string _name, Grid _grid, bool _teamA)
    {
        entityID = _id;
        grid = _grid;
        entityName = _name;
        teamA = _teamA;
    }


    // Private
    protected int entityID;
    protected string entityName;
    protected bool teamA;
    protected Grid grid;
    protected List<Tile> tilesOccupied = new List<Tile>();


    ////////////////////////////////
    //// Class Methods 
    ////////////////////////////////
    // Public
    public int EntityID
    {
        get
        {
            return entityID;
        }
        set
        {
            entityID = value;
        }
    }

    public string EntityName
    {
        get { return entityName; }
        set { entityName = value;  }
    }

    public Grid Grid
    {
        get
        {
            return grid;
        }
        set
        {
            grid = value;
        }
    }

    public bool TeamA
    {
        get { return teamA; }
        set { teamA = value; }
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

    // Private

}

public interface IActiveEntity
{
    // An Entity That has UP to perform actions

    int UPMax
    {
        get;
        set;
    }

    int UPCurrent
    {
        get;
        set;
    }

    bool DoneWithTurn
    {
        get;
        set;
    }

    void InitializeUPValues(int amount);

    void DoAction(int cost);
    void ChangeMaxUP(int amount);

    bool CanDoAction(int cost);
    void ResetUP();
}

public interface IMoveableEntity
{
    // An Entity That Can Move Tiles
    int MoveCost
    {
        get;
        set;
    }
    void Move(MoveDirection direction);
    void InitMoveCost(int cost);
}

public interface IDamageableEntity
{
    // An Entity that has hp and takes damage

    int HPMax
    {
        get;
        set;
    }
    int HPCurrent
    {
        get;
        set;
    }

    int DefensePower
    {
        get;
        set;
    }

    void InitializeHPValues(int startingHP, int startingDP);

    int DoDamage(int damage);
    int ChangeMaxHealth(int amount);

    void BeDestroyed();
}

public interface IAttackableEntity
{
    // An Entity that can attack

    int AttackPower
    {
        get;
        set;
    }
    int AttackCost
    {
        get;
        set;
    }
    int AttackRange
    {
        get;
        set;
    }
    void AttackEntity(IDamageableEntity entity);
    void InitAttackValues(int cost, int power, int range);
    List<HexEntity> EntitiesInRange();
}

public delegate void Skill(MoveDirection dir);
public interface ISkillableEntity
{
    // An Entity with an array of skills 

    int[] SkillCosts
    {
        get;
        set;
    }

    int[] SkillLevels
    {
        get;
        set;
    }

    Skill Skill01
    {
        get;
        set;
    }
    Skill Skill02
    {
        get;
        set;
    }

    Skill Skill03
    {
        get;
        set;
    }
}

