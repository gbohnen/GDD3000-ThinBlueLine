﻿using UnityEngine;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class CardActions
{
	public static void ChangeRandomPlayerMoxie(int val)
    {
        //Get random player, modify their moxie by val
		GameLibrary.instance.Players[(Players)Random.Range(0, 4)].Moxie += val;

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeRandomPlayerMuscle(int val)
    {
        //Get random player, modify their muscle by val
		GameLibrary.instance.Players[(Players)Random.Range(0, 4)].Strength += val;

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeRandomPlayerSmarts(int val)
    {
        //get random player, modify their smarts by val
		GameLibrary.instance.Players[(Players)Random.Range(0, 4)].Smarts += val;

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeRandomPlayerStats(int val)
    {
        // get random player, modify their stats by val
		int i = Random.Range(0, 4);

		GameLibrary.instance.Players[(Players)i].Moxie += val;
		GameLibrary.instance.Players[(Players)i].Moxie += val;
		GameLibrary.instance.Players[(Players)i].Moxie += val;

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }
		
    public static void ChangeCurrentPlayerMoxie(int val)
    {
        //get current player, modify their moxie by val
		GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Moxie += val;

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeCurrentPlayerMuscle(int val)
    {
		//get current player, modify their muscle by val
		GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Strength += val;

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeCurrentPlayerSmarts(int val)
    {
		//get current player, modify their smarts by val
		GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Smarts += val;

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeRandomCurrentPlayerStats(int val)
    {
        // get current player, change random stats by val
    }

    public static void ChangeAllPlayersMoxie(int val)
    {
        //modify all players moxie pool by val
		foreach (KeyValuePair<Players, PlayerScript> player in GameLibrary.instance.Players) {
			player.Value.Moxie += val;
		}

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeAllPlayersMuscle(int val)
    {
		//modify all players muscle pool by val
		foreach (KeyValuePair<Players, PlayerScript> player in GameLibrary.instance.Players) {
			player.Value.Strength += val;
		}

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeAllPlayersSmarts(int val)
    {
		//modify all players Smarts pools by val
		foreach (KeyValuePair<Players, PlayerScript> player in GameLibrary.instance.Players) {
			player.Value.Smarts += val;
		}

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeAllPlayersStats(int val)
    {
		//modify all stat pools of all players by val
		foreach (KeyValuePair<Players, PlayerScript> player in GameLibrary.instance.Players) {
			player.Value.Strength += val;
			player.Value.Moxie += val;
			player.Value.Strength += val;
		}

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeAllPlayersRandomStats(int val)
    {
        // modify all players stats at random by val
    }

    public static void ChangeCurrentMafiaPresence(int val)
    {
        //modify the current Neighborhoods Mafia Presence by val
		GameLibrary.instance.Neighborhoods[GameManager.Instance.activeNeighborhood].MafiaPresence += val;

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }
    public static void ChangeCurrentPoliceCorruption(int val)
    {
        //modify the current Neighborhoods Police Corruption by val
		GameLibrary.instance.Neighborhoods[GameManager.Instance.activeNeighborhood].Corruption += val;

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeCurrentChaos(int val)
    {
        //modify the current neighborhoods Chaos by val
		GameLibrary.instance.Neighborhoods[GameManager.Instance.activeNeighborhood].Chaos += val;

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeCurrentCrimes(int val)
    {
        //modify all crime categories in the current neighborhood by val
    }

    public static void ChangeCityMafiaPresence(int val)
    {
        //modify the City's Mafia Presence
		GameLibrary.instance.Neighborhoods[Neighborhood.Overall].MafiaPresence += val;

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }
    public static void ChangeCityPoliceCorruption(int val)
    {
		//modify the city's police corruption
		GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Corruption += val;

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeCityChaos(int val)
    {
		//modify the city's chaos
		GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Chaos += val;

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeCityCrimes(int val)
    {
        //modify all crime categories in the city by val
    }

    public static void ChangeAllNeighborhoodMafiaPresence(int val)
    {
        //modify all neighborhoods mafia presence
		foreach (KeyValuePair<Neighborhood, NeighborhoodData> neighborhood in GameLibrary.instance.Neighborhoods) {
			if (neighborhood.Key != Neighborhood.Overall)
				GameLibrary.instance.Neighborhoods[neighborhood.Key].MafiaPresence += val;		
		}

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeAllNeighborhoodPoliceCorruption(int val)
    {
		//modify all neighborhoods police corruption
		foreach (KeyValuePair<Neighborhood, NeighborhoodData> neighborhood in GameLibrary.instance.Neighborhoods) {
			if (neighborhood.Key != Neighborhood.Overall)
				GameLibrary.instance.Neighborhoods[neighborhood.Key].Corruption += val;		
		}

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeAllNeighborhoodChaos(int val)
    {
		//modify all neighborhoods chaos
		foreach (KeyValuePair<Neighborhood, NeighborhoodData> neighborhood in GameLibrary.instance.Neighborhoods) {
			if (neighborhood.Key != Neighborhood.Overall)
				GameLibrary.instance.Neighborhoods[neighborhood.Key].Chaos += val;		
		}

		Debug.Log (MethodBase.GetCurrentMethod ().Name);
    }

    public static void ChangeAllNeighborhoodCrimes(int val)
    {
        //modify all crimes of all neighborhoods
    }

    public static void ChangeMajorCrimeProgress(int val)
    {
        //modify progress toward the major crime by val
    }

    public static void ChangeCurrentRandomCrime(int val)
    {
        //modify a Random Crime Category in the current neighborhood
    }

    public static void ChangeCityRandomCrime(int val)
    {
        //modify a Random Crime Category in the city
    }

    public static void ChangeAllNeighborhoodRandomCrime(int val)
    {
        //modify a random crime category in all neighborhoods
    }

    public static void CrusherSpecial()
    {
        //Do Crusher special here... And so on for the other Specials.
    }
    public static void DetectiveSpecial()
    {

    }
    public static void FedSpecial()
    {

    }
    public static void InformantSpecial()
    {

    }
    public static void RookieSpecial()
    {

    }
    public static void PowerLusterSpecial()
    {

    }
    public static void OldDogSpecial()
    {

    }
    public static void PISpecial()
    {

    }
    public static void UndercoverSpecial()
    {

    }
    public static void DriverSpecial()
    {

    }
    public static void WardenSpecial()
    {

    }
    public static void BookieSpecial()
    {

    }

	public static void DebugLine(string str)
	{
		Debug.Log(str);
	}
}
