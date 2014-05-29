//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TurnSystem : ScriptableObject
{

    ////////////////////////////////
    //// Class Variables 
    ////////////////////////////////
    // Public


    // Private
    Grid grid;

    bool isTeamOneTurn = true;

    List<IActiveEntity> teamOne;
    List<IActiveEntity> teamTwo;

    List<bool> turnFinished;


    ////////////////////////////////
    //// Class Methods 
    ////////////////////////////////
    // Public
    public void StartTurnForTeam (bool _teamOne)  
    {
        List<IActiveEntity> activeTeam = GetActiveTeam();

        turnFinished = new List<bool>(activeTeam.Count);

    }

    public void EntityFinishedTurned(IActiveEntity e)
    {
        List<IActiveEntity> activeTeam = GetActiveTeam();
        if (!activeTeam.Contains(e))
        {
            throw new System.Exception("Entity not on Active Team");
        }

        int idx = activeTeam.IndexOf(e);
        turnFinished.Insert(idx, true);

        if (TeamIsDone())
        {
            isTeamOneTurn = !isTeamOneTurn;
            StartTurnForTeam(isTeamOneTurn);
        }
    }

    // Private
    void RefreshTeams()
    {

    }

    bool TeamIsDone()
    {
        foreach (bool b in turnFinished)
        {
            if (!b)
            {
                return false;
            }
        }
        return true;
    }

    List<IActiveEntity> GetActiveTeam()
    {
        if (isTeamOneTurn)
        {
            return teamOne;
        }
        else
        {
            return teamTwo;
        }
    }
}
