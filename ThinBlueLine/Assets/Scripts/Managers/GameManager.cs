using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Managers;
using Assets.Scripts;
using System.Collections.Generic;

/// <summary>
/// Singleton class which manages the state of the game
/// </summary>
/// 
public enum Neighborhood { StonyGate = 0, Suburbia = 1, Downtown = 2, TheBoxes = 3, Portside = 4, Overall = 5 }

public class GameManager : MonoBehaviour
{
    #region Fields    

    // store an Instance of the game manager
    public static GameManager Instance;

    // store the players
    Players currentPlayer;

    public Neighborhood activeNeighborhood;

	Dictionary<Neighborhood, NeighborhoodData> neighborhoodData;

    // store the crimes & situations
    public MajorCrimeScript majorCrime;

    //List<SituationScript> situations;

    //// store the mob boss & police chief
    //MobBossScript mobBoss;
    //PoliceChiefScript policeChief;

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
    { get { return GameLibrary.instance.Players[currentPlayer]; } }

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

    #endregion

    #region Public Methods

    // Use this for initialization
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        currentPlayer = Players.Player1;

        if (GameLibrary.instance.Players.Count == 0)
        {
            for (int i = 0; i < 4; i++)
            {
                GameLibrary.instance.Players.Add((Players)i, GameLibrary.instance.PlayerLib[Random.Range(0, 12)]);
            }
        }

        activeNeighborhood = (Neighborhood)Random.Range(0, 5);
        NeighborhoodManager.instance.indicator.SetInteger("CurrNeigh", (int)activeNeighborhood + 1);

        majorCrime = LoadGameData.LoadMajorCrimes();

        Debug.Log(majorCrime.Name);
        Debug.Log(majorCrime.MobBoss);
        foreach (MajorCrimeTier tier in majorCrime.CrimeTiers)
        {
            Debug.Log(tier.CrimeEffectText);
        }

        firstAction = false;
        UIManager.instance.UpdateUI();
    }

    public void SituationResolved(float smarts, float moxie, float muscle)
    {
        GameLibrary.instance.Players[currentPlayer].Smarts -= (int)smarts;
        GameLibrary.instance.Players[currentPlayer].Moxie -= (int)moxie;
        GameLibrary.instance.Players[currentPlayer].Muscle -= (int)muscle;

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
        GameLibrary.instance.Neighborhoods[activeNeighborhood].Corruption -= (int)smarts;
        GameLibrary.instance.Neighborhoods[activeNeighborhood].Chaos -= (int)moxie;
        GameLibrary.instance.Neighborhoods[activeNeighborhood].MafiaPresence -= (int)muscle;

        UIManager.instance.UpdateUI();
    }

    public void ClickDrawSituation()
    {
        UIManager.instance.DrawSituation(GameLibrary.instance.GetNewSituation());
    }

    public void ClickLowerCrime()
    {
        UIManager.instance.LowerCrime();
    }

    public void ClickSpecialAbility()
    {
        UIManager.instance.SpecialAbility();
    }

    public void LogAction(string action)
    {
		if (action == "No action taken")
			firstAction = true;

        if (!firstAction)
        {
            UIManager.instance.PushPlayerAction(action);
            UIManager.instance.UpdateUI();
            firstAction = true;
        }
        else
        {
            UIManager.instance.PushPlayerAction(action);

            Invoke("ResetTurn", 1f);
        }
    }

    public void SituationDrawn(float sma, float mox, float mus)
    {
        GameLibrary.instance.Players[currentPlayer].Smarts += (int)sma;
        GameLibrary.instance.Players[currentPlayer].Moxie += (int)mox;
        GameLibrary.instance.Players[currentPlayer].Muscle += (int)mus;

        UIManager.instance.UpdateUI();
    }

    public void ResetTurn()
    {
		if (!IsInvoking ()) 
		{
			// set next player
			switch (currentPlayer) {
			case Players.Player4:
				currentPlayer = Players.Player1;
				break;
			default:
				currentPlayer++;
				break;
			}

			UIManager.instance.UpdateUI ();
			firstAction = false;
			UIManager.instance.WipeActions ();
		}
    }

    #endregion
}