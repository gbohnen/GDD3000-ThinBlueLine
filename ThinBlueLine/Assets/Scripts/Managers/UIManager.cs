﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

    // fields for other manager objects;
    public CrimeSitManager situationManager;
    public PlayerManager playerManager;
    public CurrentPlayerManager currentPlayerManager;
    //public NeighborHoodManager neighborhoodManager;

    // fields for popup window gameobjects
    public GameObject drawSituationWindow;
    public GameObject resolveSituationWindow;
    public GameObject changeNeighborhoodWindow;
    public GameObject useSpecialActionWindow;
    public GameObject lowerCrimeWindow;

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

        DontDestroyOnLoad(gameObject);

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
    }

    public void UpdateUI()
    {
        playerManager.UpdateUI();
        playerManager.UpdateIndicator();
        currentPlayerManager.UpdateUI();
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
        lowerCrimeWindow.transform.SetAsLastSibling();
    }

    public void SpecialAbility()
    {
        useSpecialActionWindow.SetActive(true);
        useSpecialActionWindow.transform.SetAsLastSibling();
    }

    public void ResolveSituation(SituationScript sitch)
    {
        currentSituation = CrimeSitManager.ActiveSituations[sitch.Name];

        resolveSituationWindow.SetActive(true);
        resolveSituationWindow.GetComponent<ResolveSituationCard>().LoadSituation(sitch);
        resolveSituationWindow.transform.SetAsLastSibling();
    }

    public void CloseWindows()
    {
        // set all popup windows to inactive
        foreach (GameObject obj in modalWindows)
        {
            obj.SetActive(false);
        }
    }

    public void ReduceSituation(float i)
    {
        currentSituation.GetComponent<SituationButton>().UpdateCost(i);
    }
}
