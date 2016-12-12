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
        int i = Random.Range(0, Constants.MAX_PLAYER_COUNT);

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
        // for each player in the game library, modify muscle pool by amt
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
        // for each player in the game library, modify all stat pools by amt
        foreach (KeyValuePair<Players, PlayerScript> player in GameLibrary.instance.Players)
        {
            player.Value.Smarts += amt;
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
        // for each player in the game library, modify all players stats at random by amt
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
        // Modify a Random Crime Category in the current neighborhood
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
    /// The Crushers special, which allows substitution of stats for Muscle
    /// Setback: Chaos +1
    /// </summary>
    public static void CrusherSpecial()
    {
        // Once every three turns the Crusher can substitute Smarts or Moxie with Muscle in a situation. 
        // When using this ability chaos goes up by 1.
    }

    /// <summary>
    /// The Detectives special, which allows nullification of ongoing effects
    /// </summary>
    public static void DetectiveSpecial()
    {
        // By spending five smarts to commence an investigation, the detective is able to nullify a negative 
        // ongoing effect for either 1 to 2 turns (number is randomly assigned).
    }

    /// <summary>
    /// The Feds special, which allows extra stat spendage
    /// Setback: Mafia Presence +3 & Draw Situation w/ no stats
    /// </summary>
    public static void FedSpecial()
    {
        // Once every five turns, can “call in backup”; is allowed to spend up to five stat points, but raises 
        // mafia presence by 3, and draws a situation with no addition to stats.
    }

    /// <summary>
    /// The Informants special, which allows more stat points to be spent
    /// Setback: Draws two Situations w/ no stats
    /// </summary>
    public static void InformantSpecial()
    {
        // Once every five turns, can lower either mafia presence or chaos by 6 points, but requires the drawing
        // of two situation cards with no addition to stats.
    }

    /// <summary>
    /// The Rookies special, which allows extra stats when adding a Situation
    /// </summary>
    public static void RookieSpecial()
    {
        // The Rookie receives 4 points when drawing a Situation card instead of 3.
    }

    /// <summary>
    /// The Power Lusters special, which raises the crime stats
    /// </summary>
    public static void PowerLusterSpecial()
    {
        // If the Power Luster is in play, begin the game at 3 Police Corruption and 3 Mafia Presence.
    }

    /// <summary>
    /// The Old Dogs special, which allows the use of extra stat points
    /// Setback: Chaos + 2
    /// </summary>
    public static void OldDogSpecial()
    {
        // After drawing a situation you can spend 4 points of moxie to half the effects of said situation, 
        // but will also raise chaos by 2 points. This ability has a 3 turn cooldown. 
    }

    /// <summary>
    /// The PIs special, which allows seeing into the future
    /// </summary>
    public static void PISpecial()
    {
        // Once every 3 turns can spend 3 moxie to see what the next situation card is (through his contacts), 
        // following that, can spend another 2 smarts to have that card moved to the bottom of the deck.
    }

    /// <summary>
    /// The Undercovers special, which lowers the crime stats
    /// </summary>
    public static void UndercoverSpecial()
    {
        // If the Under Cover is in play, begin the game at 2 Chaos and 2 Mafia Presence. 
    }

    /// <summary>
    /// The Drivers special, which allows 'free' movement between neighborhoods
    /// </summary>
    public static void DriverSpecial()
    {
        // At the cost of 6 of any stat point, can carry himself and any other willing player to another 
        // neighborhood without the cost of an action point.
    }

    /// <summary>
    /// The Wardens special, which allows eavesdropping
    /// </summary>
    public static void WardenSpecial()
    {
        // By spending 3 smarts point can listen in on conversations, and see what the next situation card is. 
        // Alternatively, can spend 8 moxie to see who the mob boss is, or (if he’s already been revealed) spend 10 
        // moxie and lessen the ongoing effect of said mob boss, both of these actions will increase chaos by 3.
    }

    /// <summary>
    /// The Bookies special, which allows an initiation of a positive ongoing effect
    /// </summary>
    public static void BookieSpecial()
    {
        // Once every three turns can spend up to 3 point of smarts to initiate a random positive ongoing effect, 
        // that lasts a number of turns based on how many points of smarts was used.
    }

    #endregion

    #region Major Crime Specials
    public static void AddStillToRandomNeighborhood()
    {
        //TODO: Add a still to a random neighborhood.
    }
    public static void AddRevenueFromStills()
    {
        //Not entirely sure what this looks like.
    }
    public static void ChangeRevenue(int i)
    {
        //change revenue by some amount as detailed by i
    }
    #endregion
}