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

    List<PlayerScript> playerLib;

    private Dictionary<Players, PlayerScript> players;

    //private List<Situation> situationDeck;
    //private List<MajorCrimes> crimeDeck;
    // etc.

    private GameLibrary()
    {
        DontDestroyOnLoad(this);
    }

    public void Initialize()
    {
        // load players
        List<Player> avatars = LoadGameData.LoadPlayers();
        foreach (Player play in avatars)
        {
            playerLib.Add(new PlayerScript(play));
        }

        players = new Dictionary<Players, PlayerScript>();

        //situationDeck = LoadGameData.LoadSituations();
        //Shuffle(situationDeck);
        //crimeDeck = LoadGameData.LoadCrimes();
        //Shuffle(crimeDeck);
    }

    public static GameLibrary Instance
    {
        get
        {
            if (instance = null)
                instance = new GameLibrary();

            return instance;
        }
    }

    public List<PlayerScript> GetPlayerChoices()
    {
        List<PlayerScript> choices = new List<PlayerScript>();

        int index;

        for (int i = 0; i < 3; i++)
        {
            do
            {
                index = Random.Range(0, playerLib.Count);

                if (!players.ContainsValue(playerLib[index]))
                {
                    choices.Add(playerLib[index]);
                }
            } while (!choices.Contains(playerLib[index]));
        }

        foreach (PlayerScript p in choices)
        {
            Debug.Log(p.Name);
        }

        return choices;
    }
 
    public List<PlayerScript> PlayerLib
    {
        get { return playerLib; }
    }

    public Dictionary<Players, PlayerScript> Players
    {
        get { return players; }
    }
}
