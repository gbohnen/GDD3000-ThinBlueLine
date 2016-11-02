using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Players { Player1, Player2, Player3, Player4 }

public struct Player
{
    public string name;
    public string desc;
    public int muscle;
    public int smarts;
    public int moxie;
    public string special;
    public string story;
}

public class GameLibrary : MonoBehaviour {

    private static GameLibrary instance;

    private List<Player> avatars;
    //private List<Situation> situationDeck;
    //private List<MajorCrimes> crimeDeck;
    // etc.

    private GameLibrary()
    {
        DontDestroyOnLoad(this);
    }

    public void Initialize()
    {
        avatars = LoadGameData.LoadPlayers();
        //situationDeck = LoadGameData.LoadSituations();
        //Shuffle(situationDeck);
        //crimeDeck = LoadGameData.LoadCrimes();
        //Shuffle(crimeDeck);
    }

    public GameLibrary Instance
    {
        get
        {
            if (instance = null)
                instance = new GameLibrary();

            return instance;
        }
    }

    public List<Player> Avatars
    {
        get { return avatars; }
    }
}
