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

    [SerializeField]Grid grid;

    ////////////////////////////////
    //// Mono Methods
    ////////////////////////////////
    void Start()
    {
        grid = ScriptableObject.CreateInstance<Grid>();
        RangeFinder.grid = grid;

        // Existing Bug!! //
        // Grid does not work if height (first number) is in the sequence (3, 7, 11, 15... ) : No idea why....
        // Grid Width does not appear to have effect on this bug
        grid.CreateGrid(9, 23, 1);

        turnController = ScriptableObject.CreateInstance<TurnSystem>();
        entityController = ScriptableObject.CreateInstance<EntityController>();

        entityController.SetGrid(grid);
        //turnController.InitializeTeams(entityController.GetTeamOne(), entityController.GetTeamTwo());

        HeroEntity dj = new HeroEntity(0, "dj", 10, 10, 10, 0, 10, 10, 6);
        HeroEntity Hondune = new HeroEntity(0, "Hondune", 10, 10, 10, 0, 10, 10, 6);

        entityController.AddEntityToTeam(dj, true);
        entityController.AddEntityToTeam(Hondune);


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
