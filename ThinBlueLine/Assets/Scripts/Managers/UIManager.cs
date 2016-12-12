using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;
using Assets.Scripts.UI_Management;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour {

    // fields for other manager objects;
    public CrimeSitManager situationManager;
    public PlayerManager playerManager;
    public CurrentPlayerManager currentPlayerManager;
    public NeighborhoodManager neighborhoodManager;
    public CityInfoManager cityInfoManager;
    public ChiefsOrdersManager chiefsOrdersManager;

    // fields for popup window gameobjects
    public GameObject drawSituationWindow;
    public GameObject resolveSituationWindow;
    public GameObject changeNeighborhoodWindow;
    public GameObject useSpecialActionWindow;
    public GameObject lowerCrimeWindow;
    public GameObject chiefsOrdersWindow;
    public GameObject fightMajorCrimeWindow;

    public Image bubble1;
    public Image bubble2;
    public Image bubble3;
    public Image bubble4;

    Color blue = new Color32(0x00, 0x00, 0x8F, 0xFF);

    public Text specialAbilityText;

    // collection of windows
    List<GameObject> modalWindows;

    // singleton Instance
    public static UIManager instance;

    public GameObject currentSituation;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Initialize();
    }

    public void Initialize()
    {
        modalWindows = new List<GameObject>();

        modalWindows.Add(drawSituationWindow);
        modalWindows.Add(resolveSituationWindow);
        modalWindows.Add(changeNeighborhoodWindow);
        modalWindows.Add(useSpecialActionWindow);
        modalWindows.Add(lowerCrimeWindow);
		modalWindows.Add(fightMajorCrimeWindow);
		modalWindows.Add(chiefsOrdersWindow);
    }

    public void UpdateUI()
    {
        CheckOverflow();

        playerManager.UpdateUI();
        playerManager.UpdateIndicator();
        currentPlayerManager.UpdateUI();
        cityInfoManager.UpdateUI();
    }

    private void CheckOverflow()
    {
        foreach (KeyValuePair<Neighborhood, NeighborhoodData> neigh in GameLibrary.instance.Neighborhoods)
        {
            // floor each value
            if (neigh.Value.Chaos < 0)
                neigh.Value.Chaos = 0;
            if (neigh.Value.Corruption < 0)
                neigh.Value.Corruption = 0;
            if (neigh.Value.MafiaPresence < 0)
                neigh.Value.MafiaPresence = 0;

            // ceiling each value
            if (neigh.Key != Neighborhood.Overall)
            {
                if (neigh.Value.Chaos > 5)
                {
                    GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Chaos += neigh.Value.Chaos - 5;
                    neigh.Value.Chaos = 5;
                }
                if (neigh.Value.Corruption > 5)
                {
                    GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Corruption += neigh.Value.Corruption - 5;
                    neigh.Value.Corruption = 5;
                }
                if (neigh.Value.MafiaPresence > 5)
                {
                    GameLibrary.instance.Neighborhoods[Neighborhood.Overall].MafiaPresence += neigh.Value.MafiaPresence - 5;
                    neigh.Value.MafiaPresence = 5;
                }
            }
        }
        

        // check loss condition
        if (GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Chaos + GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Corruption + GameLibrary.instance.Neighborhoods[Neighborhood.Overall].MafiaPresence >= 15)
        {
            SceneManager.LoadScene(Constants.GAME_OVER_SCENE);
        }
    }

    public void AddSituation(SituationScript sitch)
    {
        situationManager.AddSituation(sitch);
    }

    public void DrawSituation(SituationScript sitch)
    {
        AddSituation(sitch);
        drawSituationWindow.GetComponent<DrawSituationCard>().Initialize(sitch);
        drawSituationWindow.SetActive(true);
        drawSituationWindow.transform.SetAsLastSibling();
    }

    public void LowerCrime()
    {
        lowerCrimeWindow.SetActive(true);
        lowerCrimeWindow.GetComponent<LowerNeighborhoodCrime>().Load();
        lowerCrimeWindow.transform.SetAsLastSibling();
    }

    public void SpecialAbility()
    {
        useSpecialActionWindow.SetActive(true);
        useSpecialActionWindow.transform.SetAsLastSibling();

        specialAbilityText.text = GameManager.Instance.CurrentPlayerObj.Special;
    }

    public void ResolveSituation(SituationScript sitch)
    {
        currentSituation = CrimeSitManager.ActiveSituations[sitch.Name];

        resolveSituationWindow.SetActive(true);
        resolveSituationWindow.GetComponent<ResolveSituationCard>().LoadSituation(sitch);
        resolveSituationWindow.transform.SetAsLastSibling();
    }

    public void ChangeNeighborhood(string neighborhood)
    {
        Neighborhood curr = (Neighborhood)Enum.Parse(typeof(Neighborhood), neighborhood);

        if (curr != GameManager.Instance.CurrentPlayerObj.Neighborhood)
        {
            changeNeighborhoodWindow.SetActive(true);
            changeNeighborhoodWindow.GetComponent<NewNeighborhoodCard>().Initialize(curr);
        }
    }

    public void ResolveTier(int level)
    {
        fightMajorCrimeWindow.SetActive(true);
        fightMajorCrimeWindow.transform.SetAsLastSibling();
        fightMajorCrimeWindow.GetComponent<FightMajorCrimeCard>().LoadCard(level);
    }

    public void CloseWindows()
    {
        // set all popup windows to inactive
        foreach (GameObject obj in modalWindows)
        {
            obj.SetActive(false);
        }
    }

    public void ChangeNeighborhoodCommit()
    {
        neighborhoodManager.ChangeNeighborhood(changeNeighborhoodWindow.GetComponent<NewNeighborhoodCard>().CurrentNeighborhood);
        CloseWindows();
    }

    public void ChangeMajorCrimeCommit(Vector3 change)
    {
		CloseWindows();
        situationManager.ReduceCrime(GameManager.Instance.CurrentCrimeTier, change);
		situationManager.UpdateMajorCrimeDisplay ();
		situationManager.CloseDrawer ();
        UpdateUI();
    }

    public void ReduceSituation(float i)
    {
        currentSituation.GetComponent<SituationButton>().UpdateCost(i);
    }

    public void PushPlayerAction(string action)
    {
        currentPlayerManager.UpdateActions(action);
        UpdateUI();
    }

    public void WipeActions()
    {
        currentPlayerManager.WipeActions();
		situationManager.CloseDrawer ();
    }

	public void CloseSituation(string name)
	{
		currentSituation = CrimeSitManager.ActiveSituations[name];
		currentSituation.GetComponent<SituationButton>().UpdateCost(300);
	}

    public void UpdatePlayerIndicator()
    {
        bubble1.color = blue;
        bubble2.color = blue;
        bubble3.color = blue;
        bubble4.color = blue;

        // default order 
        bubble4.gameObject.transform.parent.transform.parent.transform.SetAsLastSibling();
        bubble3.gameObject.transform.parent.transform.parent.transform.SetAsLastSibling();
        bubble2.gameObject.transform.parent.transform.parent.transform.SetAsLastSibling();
        bubble1.gameObject.transform.parent.transform.parent.transform.SetAsLastSibling();

        switch (GameManager.Instance.CurrentPlayer)
        {
            case Players.Player1:
                bubble1.color = Color.Lerp(blue, Color.red, 1f);
                bubble1.gameObject.transform.parent.transform.parent.transform.SetAsLastSibling();
                break;
            case Players.Player2:
                bubble2.color = Color.Lerp(blue, Color.red, 1f);
                bubble2.gameObject.transform.parent.transform.parent.transform.SetAsLastSibling();
                break;
            case Players.Player3:
                bubble3.color = Color.Lerp(blue, Color.red, 1f);
                bubble3.gameObject.transform.parent.transform.parent.transform.SetAsLastSibling();
                break;
            case Players.Player4:
                bubble4.color = Color.Lerp(blue, Color.red, 1f);
                bubble4.gameObject.transform.parent.transform.parent.transform.SetAsLastSibling();
                break;
        }
    }

    public void TriggerChiefsOrder(List<string> list)
    {
        chiefsOrdersWindow.SetActive(true);
        chiefsOrdersWindow.transform.SetAsLastSibling();
        chiefsOrdersManager.Load(list);
    }
}