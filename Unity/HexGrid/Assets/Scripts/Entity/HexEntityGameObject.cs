//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;

public class HexEntityGameObject : MonoBehaviour
{

    ////////////////////////////////
    //// Class Variables 
    ////////////////////////////////
    // Public
    public bool controllable = false;
    public int health;
    public int UP;
    public AxialCoordinates coord;

    // Private
    HexEntity thisEntity;


    ////////////////////////////////
    //// Mono Methods
    ////////////////////////////////
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (thisEntity != null)
        {
            MoveToTile();
        }

        if (controllable)
        {
            MoveEntity();
        }
        UpdateValues();
        HighlightTilesInRange();
    }
    /*
    void FixedUpdate () {

    }

    void OnGUI () {

    }
    */

    ////////////////////////////////
    //// Class Methods 
    ////////////////////////////////
    // Public
    public void SetEntity(HexEntity e)
    {
        thisEntity = e;
        name = e.EntityName;
        renderer.material.color = Color.red;
    }

    public void MoveToTile()
    {
        gameObject.transform.position = thisEntity.GetMainTile().worldLocation;
    }

    // Private
    void UpdateValues()
    {
        health = ((IDamageableEntity)thisEntity).HPCurrent;
        UP = ((IActiveEntity)thisEntity).UPCurrent;
        coord = thisEntity.GetMainTile().aCoord;
    }

    void MoveEntity()
    {
        if (((IActiveEntity)thisEntity).CanDoAction(((IMoveableEntity)thisEntity).MoveCost))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                ((IMoveableEntity)thisEntity).Move(MoveDirection.upl);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                ((IMoveableEntity)thisEntity).Move(MoveDirection.upr);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                ((IMoveableEntity)thisEntity).Move(MoveDirection.left);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                print("move");
                ((IMoveableEntity)thisEntity).Move(MoveDirection.right);
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                ((IMoveableEntity)thisEntity).Move(MoveDirection.downl);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                ((IMoveableEntity)thisEntity).Move(MoveDirection.downr);
            }
        }




        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (HexEntity he in ((IAttackableEntity)thisEntity).EntitiesInRange())
            {
                ((IAttackableEntity)thisEntity).AttackEntity(((IDamageableEntity)he));
            }
        }
    }

    void HighlightTilesInRange()
    {
        Tile tile = thisEntity.GetMainTile();
        tile.grid.DehighlightGrid();
        
        foreach (Tile t in RangeFinder.TilesInRangeFromTile(tile, ((IAttackableEntity)thisEntity).AttackRange))
        {
            t.Highlight();
        }

    }

}
