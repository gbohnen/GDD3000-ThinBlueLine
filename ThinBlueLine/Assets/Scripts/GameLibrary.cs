using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;

public enum Players { Player1 = 0, Player2 = 1, Player3 = 2, Player4 = 3 }

public class NeighborhoodData
{
    float chaos;
    float corruption;
    float mafiaPresence;
    public Dictionary<Players, float> Reputations;

    float randCrimeCat = Random.value;

    public float Chaos
    {
        get { return chaos; }
        set { chaos = value; }
    }

    public float Corruption
    {
        get { return corruption; }
        set { corruption = value; }
    }

    public float MafiaPresence
    {
        get { return mafiaPresence; }
        set { mafiaPresence = value; }
    }

    /// <summary>
    /// Gets or sets a random crime category
    /// </summary>
    public float RandomCrimeCategory
    {
        get
        {
            // return chaos
            if (randCrimeCat < Constants.CHAOS_THESHOLD)
            { return chaos; }
            // return corruption
            else if (randCrimeCat < Constants.CORRUPTION_THRESHOLD)
            { return corruption; }
            // return mafia presence
            else
            { return mafiaPresence; }
        }
        set
        {
            // set chaos
            if (randCrimeCat < Constants.CHAOS_THESHOLD)
            { chaos = value; }
            // set corruption
            else if (randCrimeCat < Constants.CORRUPTION_THRESHOLD)
            { corruption = value; }
            // set mafia presence
            else
            { mafiaPresence = value; }
        }
    }
}

public class GameLibrary : MonoBehaviour {

	public static GameLibrary instance;

	List<PlayerScript> playerLib = new List<PlayerScript>();
	List<SituationScript> situationLib = new List<SituationScript>();
	List<MobBossScript> mobBossLib = new List<MobBossScript>();
	private Dictionary<Neighborhood, NeighborhoodData> neighborhoods = new Dictionary<Neighborhood, NeighborhoodData>();

	private Dictionary<Players, PlayerScript> players = new Dictionary<Players, PlayerScript>();

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

        Initialize();
    }

	public void Initialize()
	{
		// load players
		List<LoadGameData.Player> avatars = LoadGameData.LoadPlayers();
		foreach (LoadGameData.Player play in avatars)
		{
			playerLib.Add(new PlayerScript(play));
		}

		List<LoadGameData.Situation> situations = LoadGameData.LoadSituations();
		foreach (LoadGameData.Situation sit in situations)
		{
			situationLib.Add(new SituationScript(sit));
		}

		List<LoadGameData.MobBoss> mobBosses = LoadGameData.LoadMobBosses();
		foreach (LoadGameData.MobBoss mobBoss in mobBosses)
		{
			mobBossLib.Add(new MobBossScript(mobBoss));
		}

		neighborhoods = new Dictionary<Neighborhood, NeighborhoodData>();

		InitNeighborhoods();
	}

	public void InitNeighborhoods()
	{
		for (int i = 0; i < 6; i++)
		{
			NeighborhoodData data = new NeighborhoodData();
			data.Chaos = 0;
			data.Corruption = 0;
			data.MafiaPresence = 0;
			data.Reputations = new Dictionary<Players, float>();

			for (int j = 0; j < 4; j++)
			{
				data.Reputations.Add((Players)j, 0);
			}

			neighborhoods.Add((Neighborhood)i, data);
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
			} while (choices.Contains(playerLib[index]) || players.ContainsValue(playerLib[index]));

			choices.Add(playerLib[index]);
		}

		return choices;
	}

	public SituationScript GetNewSituation()
	{
		int i = Random.Range(0, situationLib.Count);
		SituationScript sitch = situationLib[i];
		situationLib.RemoveAt(i);

		return sitch;
	}

	public List<PlayerScript> PlayerLib
	{
		get { return playerLib; }
	}

	public Dictionary<Players, PlayerScript> Players
	{
		get { return players; }
	}

	public Dictionary<Neighborhood, NeighborhoodData> Neighborhoods
	{
		get { return neighborhoods; }
	}

	public List<SituationScript> SituationList
	{
		get { return situationLib; }
	}
}