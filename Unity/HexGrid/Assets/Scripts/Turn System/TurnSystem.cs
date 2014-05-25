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
    public void InitializeTeams(List<IActiveEntity> _teamOne, List<IActiveEntity> _teamTwo)
    {
        teamOne = _teamOne;
        teamTwo = _teamTwo;
    }

    public void EndTurn(IActiveEntity e)
    {
        if (isTeamOneTurn)
        {
            if (!teamOne.Contains(e))
            {
                Console.WriteLine("Error: Not E's Turn!");
            }
            else
            {
                turnFinished.Insert(teamOne.IndexOf(e), true);
            }
        }
    }

    public bool EntitiesAreTeamMembers(IActiveEntity e0, IActiveEntity e1)
    {
        if (teamOne.Contains(e0))
        {
            return teamOne.Contains(e1);
        }
        else if (teamTwo.Contains(e0))
        {
            return teamTwo.Contains(e1);
        }
        return false;
    }

    // Private
    void StartTurnForTeam(bool isTeamOne)
    {
        List<IActiveEntity> team = GetTeam(isTeamOne);
        turnFinished = new List<bool>(team.Count);

        foreach (IActiveEntity e in team)
        {
            e.StartTurn();
        }
    }

    bool TurnIsDone(bool isTeamOne)
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

    List<IActiveEntity> GetTeam(bool isTeamOne)
    {
        List<IActiveEntity> team;
        if (isTeamOne)
            team = teamOne;
        else
            team = teamTwo;

        return team;
    }

    bool AssertNoTeamOverlap()
    {
        foreach (IActiveEntity e in teamOne)
        {
            foreach (IActiveEntity e1 in teamTwo)
            {
                if (e.Equals(e1))
                {
                    return false;
                }
            }
        }
        return true;
    }
}
