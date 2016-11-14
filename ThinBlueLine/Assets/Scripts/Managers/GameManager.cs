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

    bool firstAction;

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

        firstAction = false;
        UIManager.instance.UpdateUI();
    }

    public void SituationResolved(float smarts, float moxie, float muscle)
    {
        GameLibrary.instance.Players[currentPlayer].Smarts -= (int)smarts;
        GameLibrary.instance.Players[currentPlayer].Moxie -= (int)moxie;
        GameLibrary.instance.Players[currentPlayer].Strength -= (int)muscle;

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

    public void ResetTurn()
    {
        // set next player
        switch (currentPlayer)
        {
            case Players.Player4:
                currentPlayer = Players.Player1;
                break;
            default:
                currentPlayer++;
                break;
        }

        UIManager.instance.UpdateUI();
        firstAction = false;
        UIManager.instance.WipeActions();
    }

    #endregion
}