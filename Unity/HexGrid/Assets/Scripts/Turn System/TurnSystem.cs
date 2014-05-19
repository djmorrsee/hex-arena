//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnSystem : MonoBehaviour
{

    ////////////////////////////////
    //// Class Variables 
    ////////////////////////////////
    // Public



    // Private
    List<IActiveEntity> teamOne = new List<IActiveEntity>();
    List<IActiveEntity> teamTwo = new List<IActiveEntity>();

    bool teamTurn = false;
    bool teamReset = false;

    ////////////////////////////////
    //// Mono Methods
    ////////////////////////////////
    void Start()
    {

    }

    void Update()
    {

        if (teamReset)
        {
            if (WaitForTurn(teamTurn))
            {
                teamReset = false;
                teamTurn = !teamTurn;
            }
        }
        else
        {
            TakeTurn(teamTurn);
            teamReset = true;
        }

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
    public void RegisterEntity(IActiveEntity entity, bool teamA)
    {
        if (teamA)
            teamOne.Add(entity);
        else
            teamTwo.Add(entity);
    }

    public void TakeTurn(bool teamA)
    {
        List<IActiveEntity> thisTeam;
        if (teamA)
        {
            thisTeam = teamOne;
        }
        else
        {
            thisTeam = teamTwo;
        }
        foreach (IActiveEntity e in thisTeam)
        {
            e.ResetUP();
            // Setup control passing here
        }
    }

    // Private
    bool WaitForTurn(bool teamA)
    {
        List<IActiveEntity> thisTeam;

        if (teamA)
        {
            thisTeam = teamOne;
        }
        else
        {
            thisTeam = teamTwo;
        }
        foreach (IActiveEntity e in thisTeam)
        {
            if (!e.DoneWithTurn)
            {
                return false;
            }
        }
        return true;
    }



}
