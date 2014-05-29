//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;

public class ArenaGame : MonoBehaviour
{

    ////////////////////////////////
    //// Class Variables 
    ////////////////////////////////
    // Public



    // Private
    EntityController entityController;
    TurnSystem turnController;

    Grid grid;

    ////////////////////////////////
    //// Mono Methods
    ////////////////////////////////
    void Start()
    {
        grid = GetComponent<Grid>();
        turnController = ScriptableObject.CreateInstance<TurnSystem>();
        entityController = ScriptableObject.CreateInstance<EntityController>();

        entityController.SetGrid(grid);
        turnController.InitializeTeams(entityController.GetTeamOne(), entityController.GetTeamTwo());

        HeroEntity dj = new HeroEntity(0, "dj", 10, 10, 10, 10, 10, 10, 10);
        entityController.AddEntityToTeam(dj, true);
    }

    void Update()
    {

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



    // Private




}
