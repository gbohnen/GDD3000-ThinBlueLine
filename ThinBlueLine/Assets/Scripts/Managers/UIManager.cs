using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;

public class UIManager : MonoBehaviour {

    // fields for other manager objects;
    public CrimeSitManager situationManager;
    public PlayerManager playerManager;
    //public ControllerManager controllerManager;
    //public NeighborHoodManager neighborhoodManager;

    // fields for window prefabs
    public GameObject drawSituationWindow;
    public GameObject resolveSituationWindow;
    public GameObject changeNeighborhoodWindow;
    public GameObject actionUnavailableWindow;

    // singleton Instance
    public static UIManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void UpdateUI()
    {
        playerManager.UpdateUI();
        playerManager.UpdateIndicator();
    }

    public void AddSituation(SituationScript sitch)
    {
        situationManager.AddSituation(sitch);
    }
}
