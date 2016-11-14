using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Managers;
using Assets.Scripts;
using System.Collections.Generic;

/// <summary>
/// Singleton class which manages the state of the game
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Fields    

    // store an Instance of the game manager
    public static GameManager Instance;

    // store the players
    Players currentPlayer;

    // store the crimes & situations
    MajorCrimeScript majorCrime;
    List<SituationScript> situations;

    // store the mob boss & police chief
    MobBossScript mobBoss;
    PoliceChiefScript policeChief;

    #region UI

    // player UI fields
    public Text playerWName;
    public Text playerWSma;
    public Text playerWMox;
    public Text playerWMus;

    public Text playerXName;
    public Text playerXSma;
    public Text playerXMox;
    public Text playerXMus;

    public Text playerYName;
    public Text playerYSma;
    public Text playerYMox;
    public Text playerYMus;

    public Text playerZName;
    public Text playerZSma;
    public Text playerZMox;
    public Text playerZMus;

    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets the current player
    /// </summary>
    public PlayerScript CurrentPlayerObj
    { get { return GameLibrary.instance.Players[currentPlayer]; } }


    public Players CurrentPlayer
    { get { return currentPlayer; } }
    #endregion

    #region Public Methods

    /// <summary>
    /// Gets or sets the audio manager
    /// </summary>
    public AudioManager Audio
    { get; private set; }

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

        UIManager.instance.AddSituation(GameLibrary.instance.SituationList[3]);
        UIManager.instance.UpdateUI();
    }

    public void SituationResolved(float smarts, float moxie, float muscle)
    {
        GameLibrary.instance.Players[currentPlayer].Smarts -= (int)smarts;
        GameLibrary.instance.Players[currentPlayer].Moxie -= (int)moxie;
        GameLibrary.instance.Players[currentPlayer].Strength -= (int)muscle;

        UIManager.instance.UpdateUI();
    }

    /// <summary>
    /// Passes the current turn to the next player
    /// </summary>
    public void PassTurn()
    { }

    /// <summary>
    /// Loads the save game, if it exists
    /// </summary>
    public void LoadGame()
    { }

    /// <summary>
    /// Ends the game
    /// </summary>
    public void EndGame()
    { }

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

    #endregion
}