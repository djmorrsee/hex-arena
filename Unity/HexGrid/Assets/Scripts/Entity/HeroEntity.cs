//// Created By Daniel Morrissey
////////////////////////////////

using System;
using System.Collections.Generic;

public class HeroEntity : HexEntity, IActiveEntity, IMoveableEntity, IDamageableEntity, IAttackableEntity
{

    ////////////////////////////////
    //// Class Variables 
    ////////////////////////////////
    // Public


    // Private
    private int upMax;
    private int upCurrent;

    private int moveCost;

    private int hpMax;
    private int hpCurrent;

    private int defensePower;

    private int attackPower;
    private int attackCost;
    private int attackRange;

    private bool doneWithTurn;


    ////////////////////////////////
    //// Class Methods 
    ////////////////////////////////
    // Public
    public HeroEntity(int _id, string _name, int _utilityPoints, int _healthPoints, int _defensePower, int _moveCost, int _attackCost, int _attackPower, int _attackRange)
        : base(_id, _name)
    {

        InitializeUPValues(_utilityPoints);
        InitializeHPValues(_healthPoints, _defensePower);

        InitMoveCost(_moveCost);

        InitAttackValues(_attackCost, _attackPower, _attackRange);
    }


    // Private
    public int UPMax
    {
        get
        {
            return upMax;
        }
        set
        {
            upMax = value;
        }
    }

    public int UPCurrent
    {
        get
        {
            return upCurrent;
        }
        set
        {
            upCurrent = value;
        }
    }

    public void InitializeUPValues(int amount)
    {
        this.UPMax = amount;
        this.UPCurrent = amount;
    }

    public void DoAction(int cost)
    {
        if (!CanDoAction(cost))
        {
            throw new System.Exception();
        }
        this.UPCurrent -= cost;

        if (this.UPCurrent <= 0)
        {
            this.UPCurrent = 0;
            this.IsThisTurn = true;
        }
    }

    public void ChangeMaxUP(int amount)
    {
        float ratio = (1f * this.UPCurrent) / this.UPMax;
        this.UPMax -= amount;
        this.UPCurrent = (int)(this.UPMax * ratio);
    }

    public bool CanDoAction(int cost)
    {
        return cost <= this.UPCurrent;
    }


    public void ResetUP()
    {
        this.UPCurrent = this.UPMax;
        this.IsThisTurn = false;
    }

    public bool IsThisTurn
    {
        get
        {
            return doneWithTurn;
        }
        set
        {
            doneWithTurn = value;
        }
    }

    public void StartTurn()
    {
        return;
    }

    public void EndTurn()
    {
        return;
    }

    public int MoveCost
    {
        get
        {
            return moveCost;
        }
        set
        {
            moveCost = value;
        }
    }

    public void InitMoveCost(int cost)
    {
        this.MoveCost = cost;
    }

    public void Move(MoveDirection direction)
    {
        if (!CanDoAction(this.moveCost))
        {
            return;
        }

        bool canMove = true;
        List<Tile> requestedTiles = new List<Tile>();

        foreach (Tile t in this.tilesOccupied)
        {
            Tile requestedTile = t.grid.TileInDirectionFromTile(t, direction);
            if (!requestedTile.active || requestedTile.occupied)
            {
                canMove = false;
            }
            else
            {
                requestedTiles.Add(requestedTile);
            }
        }
        if (canMove)
        {
            foreach (Tile t in this.tilesOccupied)
            {
                t.Vacate();
            }
            this.tilesOccupied = requestedTiles;
            foreach (Tile t in this.tilesOccupied)
            {
                t.Occupy(this);
            }
        }

        DoAction(this.moveCost);
    }

    public int HPMax
    {
        get
        {
            return hpMax;
        }
        set
        {
            hpMax = value;
        }
    }

    public int HPCurrent
    {
        get
        {
            return hpCurrent;
        }
        set
        {
            hpCurrent = value;
        }
    }

    public int DefensePower
    {
        get
        {
            return defensePower;
        }
        set
        {
            defensePower = value;
        }
    }

    public void InitializeHPValues(int startingHP, int startingDP)
    {
        this.HPMax = startingHP;
        this.HPCurrent = startingHP;

        this.defensePower = startingDP;
    }

    public int DoDamage(int damage)
    {
        this.HPCurrent -= damage;
        if (this.HPCurrent <= 0)
        {
            BeDestroyed();
        }
        return this.HPCurrent;
    }

    public int ChangeMaxHealth(int amount)
    {
        float ratio = (1f * this.HPCurrent) / this.HPMax;
        this.HPMax -= amount;
        this.HPCurrent = (int)(this.HPMax * ratio);
        return this.HPMax;
    }

    public void BeDestroyed()
    {
        Console.WriteLine("Destroyed!");
    }

    public int AttackPower
    {
        get
        {
            return attackPower;
        }
        set
        {
            attackPower = value;
        }
    }

    public int AttackCost
    {
        get
        {
            return attackCost;
        }
        set
        {
            attackCost = value;
        }
    }

    public int AttackRange
    {
        get
        {
            return attackRange;
        }
        set
        {
            attackRange = value;
        }
    }

    public void AttackEntity(IDamageableEntity entity)
    {
        if (CanDoAction(this.AttackCost))
        {
            entity.DoDamage(this.AttackPower);
            DoAction(this.attackCost);
        }
    }

    public List<HexEntity> EntitiesInRange()
    {
        return RangeFinder.EntitiesInRangeOfTile(this.GetMainTile(), this.AttackRange);
    }

    public void InitAttackValues(int cost, int power, int range)
    {
        this.AttackCost = cost;
        this.AttackPower = power;
        this.AttackRange = range;
    }

}
