using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using System.Collections.Generic;
using System;

using random = UnityEngine.Random;

/// <summary>
/// Enumeration for the different neighborhoods
/// </summary>
public enum Neighborhood { StonyGate = 0, Suburbia = 1, Downtown = 2, TheBoxes = 3, Portside = 4, Overall = 5 }

/// <summary>
/// Singleton class which manages the state of the game
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Fields    

    public CanvasGroup canvasBlock;

    // store an Instance of the game manager
    public static GameManager Instance;

    // store the players
    Players currentPlayer;
   
	Dictionary<Neighborhood, NeighborhoodData> neighborhoodData;

    // store the crimes & situations
    public MajorCrimeScript majorCrime;

    //// store the mob boss & police chief
    //MobBossScript mobBoss;
    PoliceChiefScript policeChief;

    // first action flag
    bool firstAction;

    // set the initial crime categories
    public int initPC = 0;
    public int initCH = 0;
    public int initMP = 0;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the current player
    /// </summary>
    public PlayerScript CurrentPlayerObj
    {
        get { return GameLibrary.instance.Players[currentPlayer]; }
    }

    /// <summary>
    /// Gets the current player
    /// </summary>
    public Players CurrentPlayer
    { get { return currentPlayer; } }

    /// <summary>
    /// Gets or sets the current police corruption
    /// </summary>
    public int CurrentPC
    {
        get { return initPC; }
        set { initPC = value; }
    }

    /// <summary>
    /// Gets or sets the current chaos
    /// </summary>
    public int CurrentCH
    {
        get { return initCH; }
        set { initCH = value; }
    }

    /// <summary>
    /// Gets or sets the current mafia presence
    /// </summary>
    public int CurrentMP
    {
        get { return initMP; }
        set { initMP = value; }
    }

    public int CurrentCrimeTier
    { get; set; }

    public Vector3 CurrentCrimeStats
    { get; set; }

    #endregion

    #region Public Methods

    // Use this for initialization
    void Start()
    {
        // check for instance of the GameManager
        if (Instance == null)
        { Instance = this; }
        else
        { Destroy(gameObject); }

        // set current player to the firs player
        currentPlayer = Players.Player1;

        // if there are no players given
        if (GameLibrary.instance.Players.Count == 0)
        {
            // check the player count
            for (int i = 0; i < Constants.MAX_PLAYER_COUNT; i++)
            {
                // add 4 random players to the scene
                GameLibrary.instance.Players.Add((Players)i, GameLibrary.instance.PlayerLib[random.Range(0, 12)]);
            }
        }

        // for each player
        foreach (Players player in GameLibrary.instance.Players.Keys)
        {
            // set the current neighborhood
            GameLibrary.instance.Players[player].Neighborhood = Neighborhood.Downtown;
        }
        
        // set neighborhood indicators
        NeighborhoodManager.instance.indicator1.SetInteger("CurrNeigh", (int)Neighborhood.Downtown + 1);
        NeighborhoodManager.instance.indicator2.SetInteger("CurrNeigh", (int)Neighborhood.Downtown + 1);
        NeighborhoodManager.instance.indicator3.SetInteger("CurrNeigh", (int)Neighborhood.Downtown + 1);
        NeighborhoodManager.instance.indicator4.SetInteger("CurrNeigh", (int)Neighborhood.Downtown + 1);

        // loads the major crimes in
        majorCrime = LoadGameData.LoadMajorCrimes();

        CurrentCrimeTier = 0;
        CurrentCrimeStats = new Vector3(0, 0, 0);

        // set up police chief
        policeChief = new PoliceChiefScript();

        // clear the first action
        firstAction = false;

        // update indicators
        UIManager.instance.UpdatePlayerIndicator();

        // for each neighborhood
        foreach (KeyValuePair<Neighborhood, NeighborhoodData> data in GameLibrary.instance.Neighborhoods)
        {
            data.Value.Chaos += random.Range(0, 4);
            data.Value.Corruption += random.Range(0, 4);
            data.Value.MafiaPresence += random.Range(0, 4);
        }

        // updates the UI
        UIManager.instance.UpdateUI();
    }

    /// <summary>
    /// Handled when a situation is resolved
    /// </summary>
    /// <param name="smarts">smarts amount</param>
    /// <param name="moxie">moxie amount</param>
    /// <param name="muscle">muscle amount</param>
    public void SituationResolved(float smarts, float moxie, float muscle)
    {
        // set the current players stats
        GameLibrary.instance.Players[currentPlayer].Smarts -= (int)smarts;
        GameLibrary.instance.Players[currentPlayer].Moxie -= (int)moxie;
        GameLibrary.instance.Players[currentPlayer].Muscle -= (int)muscle;

        // updates the UI
        UIManager.instance.UpdateUI();
    }

    /// <summary>
    /// Lowers the crime by the given amount
    /// </summary>
    /// <param name="smarts">smarts amount</param>
    /// <param name="moxie">moxie amount</param>
    /// <param name="muscle">muscle amount</param>
    public void LowerCrime(float smarts, float moxie, float muscle)
    {
        // set the curren neighborhoods stats
        GameLibrary.instance.Neighborhoods[CurrentPlayerObj.Neighborhood].Corruption -= (int)smarts;
        GameLibrary.instance.Neighborhoods[CurrentPlayerObj.Neighborhood].Chaos -= (int)moxie;
        GameLibrary.instance.Neighborhoods[CurrentPlayerObj.Neighborhood].MafiaPresence -= (int)muscle;

        // updates the UI
        UIManager.instance.UpdateUI();
    }

    /// <summary>
    /// Handled when the player clicks draw situation
    /// </summary>
    public void ClickDrawSituation()
    { UIManager.instance.DrawSituation(GameLibrary.instance.GetNewSituation()); }

    /// <summary>
    /// Handled when the player clicks lower crime
    /// </summary>
    public void ClickLowerCrime()
    {  UIManager.instance.LowerCrime(); }

    /// <summary>
    /// Handled when the player clicks special ability
    /// </summary>
    public void ClickSpecialAbility()
    { UIManager.instance.SpecialAbility(); }

    /// <summary>
    /// Logs the given action
    /// </summary>
    /// <param name="action"></param>
    public void LogAction(string action)
    {
        // check for no action
		if (action == "No action taken")
			firstAction = true;

        // check for second action
        if (!firstAction)
        {
            UIManager.instance.PushPlayerAction(action);
            UIManager.instance.UpdateUI();
            firstAction = true;
        }
        else
        {
            UIManager.instance.PushPlayerAction(action);
            canvasBlock.blocksRaycasts = true;
            Invoke("ResetTurn", .5f);
        }
    }

    /// <summary>
    /// Handled when a situation is drawn
    /// </summary>
    /// <param name="sma">smarts amount</param>
    /// <param name="mox">moxie amount</param>
    /// <param name="mus">muscle amount</param>
    public void SituationDrawn(float sma, float mox, float mus)
    {
        // set the current players stats
        GameLibrary.instance.Players[currentPlayer].Smarts += (int)sma;
        GameLibrary.instance.Players[currentPlayer].Moxie += (int)mox;
        GameLibrary.instance.Players[currentPlayer].Muscle += (int)mus;

        // updates the UI
        UIManager.instance.UpdateUI();
    }

    /// <summary>
    /// Resets the players turn
    /// </summary>
    public void ResetTurn()
    {
		if (!IsInvoking ()) 
		{

            canvasBlock.blocksRaycasts = false;
            // set next player
            switch (currentPlayer)
            {
                case Players.Player4:
                    currentPlayer = Players.Player1;
                    EndTurnLogic();
                    break;
                default:
                    currentPlayer++;
                    break;
            }
            // updates the UI
			UIManager.instance.UpdateUI ();

            // updates player indicator
            UIManager.instance.UpdatePlayerIndicator();

            // set first action to false
			firstAction = false;

            // wipe player actions
			UIManager.instance.WipeActions ();
        }
    }

	public void ResolveTier (bool option)
	{
		UIManager.instance.TriggerChiefsOrder(policeChief.BuildMajorCrimeReport (option));

		majorCrime.TriggerTierEffect(CurrentCrimeTier, option);

		CurrentCrimeStats = new Vector3 (0, 0, 0);
		CurrentCrimeTier++;


		UIManager.instance.UpdateUI ();

	}


    /// <summary>
    /// Logs the given string
    /// </summary>
    /// <param name="str">the string</param>
    public static void DebugLine(string str)
    { Debug.Log(str); }

    public void EndTurnLogic()
    {
        foreach (KeyValuePair<string, GameObject> sitch in CrimeSitManager.ActiveSituations)
        {
            if (sitch.Value != null)
            {
                sitch.Value.GetComponent<SituationButton>().situation.TriggerOngoing();
            }
        }

        UIManager.instance.TriggerChiefsOrder(policeChief.BuildChiefReport());
    }

    #endregion
}