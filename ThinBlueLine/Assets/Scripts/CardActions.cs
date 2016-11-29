using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using Assets.Scripts;

/// <summary>
/// Class which holds all of the actions of cards
/// </summary>
public class CardActions
{
    #region Changes to Random Players Stats

    /// <summary>
    /// Changes a random players moxie by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeRandomPlayerMoxie(int amt)
    {
        // Get random player, modify their moxie by amt
        GameLibrary.instance.Players[(Players)Random.Range(0, Constants.MAX_PLAYER_COUNT)].Moxie += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes a random players muscle by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeRandomPlayerMuscle(int amt)
    {
        // Get random player, modify their muscle by amt
        GameLibrary.instance.Players[(Players)Random.Range(0, Constants.MAX_PLAYER_COUNT)].Muscle += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes a random players smarts by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeRandomPlayerSmarts(int amt)
    {
        // Get random player, modify their smarts by amt
        GameLibrary.instance.Players[(Players)Random.Range(0, Constants.MAX_PLAYER_COUNT)].Smarts += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes a random players stats by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeRandomPlayerStats(int amt)
    {
        // Get random player, modify their stats by amt
        int i = Random.Range(0, 4);

        GameLibrary.instance.Players[(Players)i].Moxie += amt;
        GameLibrary.instance.Players[(Players)i].Moxie += amt;
        GameLibrary.instance.Players[(Players)i].Moxie += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    #endregion

    #region Changes to Current Player Stats

    /// <summary>
    /// Changes the current players moxie by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeCurrentPlayerMoxie(int amt)
    {
        // Get current player, modify their moxie by amt
        GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Moxie += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes the current players muscle by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeCurrentPlayerMuscle(int amt)
    {
        // Get current player, modify their muscle by amt
        GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Muscle += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes the current players smarts by the given amount
    /// </summary>
    /// <param name="amt">thr amount to change</param>
    public static void ChangeCurrentPlayerSmarts(int amt)
    {
        // Get current player, modify their smarts by amt
        GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].Smarts += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes random stats of the current player by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeRandomCurrentPlayerStats(int amt)
    {
        // Get current player, change random stats by amt
        GameLibrary.instance.Players[GameManager.Instance.CurrentPlayer].RandomStat += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    #endregion Stats 

    #region Changes to All Players Stats

    /// <summary>
    /// Changes all of the players moxie
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeAllPlayersMoxie(int amt)
    {
        // for each player in the game library, modify moxie pool by amt
        foreach (KeyValuePair<Players, PlayerScript> player in GameLibrary.instance.Players)
        { player.Value.Moxie += amt; }

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes all of the players muscle
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeAllPlayersMuscle(int amt)
    {
        //for each player in the game library, modify muscle pool by amt
        foreach (KeyValuePair<Players, PlayerScript> player in GameLibrary.instance.Players)
        { player.Value.Muscle += amt; }

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes all of the players smarts
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeAllPlayersSmarts(int amt)
    {
        // for each player in the game library, modify Smarts pools by amt
        foreach (KeyValuePair<Players, PlayerScript> player in GameLibrary.instance.Players)
        { player.Value.Smarts += amt; }

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes all of the players stats
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeAllPlayersStats(int amt)
    {
        //for each player in the game library, modify all stat pools by amt
        foreach (KeyValuePair<Players, PlayerScript> player in GameLibrary.instance.Players)
        {
            player.Value.Muscle += amt;
            player.Value.Moxie += amt;
            player.Value.Muscle += amt;
        }

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes random stats of all players by the given amount
    /// </summary>
    /// <param name="amt"></param>
    public static void ChangeAllPlayersRandomStats(int amt)
    {
        //for each player in the game library, modify all players stats at random by amt
        foreach (KeyValuePair<Players, PlayerScript> player in GameLibrary.instance.Players)
        { player.Value.RandomStat += amt; }

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    #endregion

    #region Changes to Current Neighborhood Stats

    /// <summary>
    /// Changes the current neighborhoods mafia presence by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeCurrentMafiaPresence(int amt)
    {
        // Modify the current Neighborhoods Mafia Presence by amt
        GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].MafiaPresence += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes the current neighborhoods police corruption by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeCurrentPoliceCorruption(int amt)
    {
        // Modify the current Neighborhoods Police Corruption by amt
        GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Corruption += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes the current neighborhoods chaos by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeCurrentChaos(int amt)
    {
        // Modify the current neighborhoods Chaos by amt
        GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Chaos += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes all of the current neighborhoods crime categories by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeCurrentCrimes(int amt)
    {
        // Modify all crime categories in the current neighborhood by amt
        GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Corruption += amt;
        GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Chaos += amt;
        GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].MafiaPresence += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);

    }

    /// <summary>
    /// Changes a random crime category in the current neighborhood by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeCurrentRandomCrime(int amt)
    {
        //modify a Random Crime Category in the current neighborhood
        GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].RandomCrimeCategory += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);

    }

    #endregion

    #region Changes to All Neighborhood Stats

    /// <summary>
    /// Changes all of the neighborhoods mafia presence by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeAllNeighborhoodMafiaPresence(int amt)
    {
        // for each neighborhood in the game library
        foreach (KeyValuePair<Neighborhood, NeighborhoodData> neighborhood in GameLibrary.instance.Neighborhoods)
        {
            // if the neighborhood is not the overall city, modify all neighborhoods mafia presence
            if (neighborhood.Key != Neighborhood.Overall)
            { GameLibrary.instance.Neighborhoods[neighborhood.Key].MafiaPresence += amt; }
        }

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes all of the neighborhoods police corruption by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeAllNeighborhoodPoliceCorruption(int amt)
    {
        // for each neighborhood in the game library
        foreach (KeyValuePair<Neighborhood, NeighborhoodData> neighborhood in GameLibrary.instance.Neighborhoods)
        {
            // if the niehgborhood is not the overall city, modify all neighborhoods police corruption
            if (neighborhood.Key != Neighborhood.Overall)
            { GameLibrary.instance.Neighborhoods[neighborhood.Key].Corruption += amt; }
        }

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes all of the neighborhoods mafia presence by the given amount
    /// </summary>
    /// <param name="amt"></param>
    public static void ChangeAllNeighborhoodChaos(int amt)
    {
        // for each neighborhood in the game library
        foreach (KeyValuePair<Neighborhood, NeighborhoodData> neighborhood in GameLibrary.instance.Neighborhoods)
        {
            //if the neighborhood is not the overall city, modify all neighborhoods chaos
            if (neighborhood.Key != Neighborhood.Overall)
            { GameLibrary.instance.Neighborhoods[neighborhood.Key].Chaos += amt; }
        }

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes each city crime category of all of the neighborhoods by the given amount
    /// </summary>
    /// <param name="amt"></param>
    public static void ChangeAllNeighborhoodCrimes(int amt)
    {
        // for each neighborhood in the game library
        foreach (KeyValuePair<Neighborhood, NeighborhoodData> neighborhood in GameLibrary.instance.Neighborhoods)
        {
            // if the neighborhood is not the overall city, modify all crimes of all neighborhoods
            if (neighborhood.Key != Neighborhood.Overall)
            {
                GameLibrary.instance.Neighborhoods[neighborhood.Key].Chaos += amt;
                GameLibrary.instance.Neighborhoods[neighborhood.Key].Corruption += amt;
                GameLibrary.instance.Neighborhoods[neighborhood.Key].MafiaPresence += amt;
            }
        }

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes a random crime category in all of the neighborhoods by the given amount
    /// </summary>
    /// <param name="amt"></param>
    public static void ChangeAllNeighborhoodRandomCrime(int amt)
    {
        // for each neighborhood in the game library
        foreach (KeyValuePair<Neighborhood, NeighborhoodData> neighborhood in GameLibrary.instance.Neighborhoods)
        {
            // if the neighborhood is not the overall city, modify a random crime category in all neighborhoods
            if (neighborhood.Key != Neighborhood.Overall)
            { GameLibrary.instance.Neighborhoods[neighborhood.Key].RandomCrimeCategory += amt; }
        }

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes the stats given to the major crime by the given amount
    /// </summary>
    /// <param name="amt"></param>
    public static void ChangeMajorCrimeProgress(int amt)
    {
        // modify progress toward the major crime by amt
    }

    #endregion

    #region Changes to the City Stats

    /// <summary>
    /// Changes the City's mafia presence by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeCityMafiaPresence(int amt)
    {
        // Modify the City's Mafia Presence
        GameLibrary.instance.Neighborhoods[Neighborhood.Overall].MafiaPresence += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes the City's police corruption by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeCityPoliceCorruption(int amt)
    {
        // Modify the city's police corruption
        GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Corruption += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes the City's chaos by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeCityChaos(int amt)
    {
        // Modify the city's chaos
        GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Chaos += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes all of the City's crime categories by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeCityCrimes(int amt)
    {
        // Modify all crime categories in the city by amt
        GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Chaos += amt;
        GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Corruption += amt;
        GameLibrary.instance.Neighborhoods[Neighborhood.Overall].MafiaPresence += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    /// <summary>
    /// Changes a random crime category in the city by the given amount
    /// </summary>
    /// <param name="amt">the amount to change</param>
    public static void ChangeCityRandomCrime(int amt)
    {
        // modify a Random Crime Category in the city
        GameLibrary.instance.Neighborhoods[Neighborhood.Overall].RandomCrimeCategory += amt;

        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    #endregion

    #region Player Specials

    /// <summary>
    /// 
    /// </summary>
    public static void CrusherSpecial()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public static void DetectiveSpecial()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public static void FedSpecial()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public static void InformantSpecial()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public static void RookieSpecial()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public static void PowerLusterSpecial()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public static void OldDogSpecial()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public static void PISpecial()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public static void UndercoverSpecial()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public static void DriverSpecial()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public static void WardenSpecial()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public static void BookieSpecial()
    {

    }

    #endregion
}