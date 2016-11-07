using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;

public class UIManager : MonoBehaviour {

    // fields for other manager objects;
    public CrimeSitManager situationManager;
    public PlayerManager playerManager;
    public CurrentPlayerManager currentPlayerManager;
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

        DumbStartupCode();
    }

    public void DumbStartupCode()
    {
        GameObject panel = GameObject.Find("ErrorPrefab");

        drawSituationWindow = Instantiate(panel);
        resolveSituationWindow = Instantiate(panel);
        changeNeighborhoodWindow = Instantiate(panel);
        actionUnavailableWindow = Instantiate(panel);

        Destroy(panel);
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

    public void DrawSituation()
    {
        var panel = Instantiate(drawSituationWindow);
        panel.transform.SetParent(gameObject.transform);
        panel.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void LowerCrime()
    {
        var panel = Instantiate(drawSituationWindow);
        panel.transform.SetParent(gameObject.transform);
        panel.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void SpecialAbility()
    {
        var panel = Instantiate(drawSituationWindow);
        panel.transform.SetParent(gameObject.transform);
        panel.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void ResolveSituation()
    {
        var panel = Instantiate(drawSituationWindow);
        panel.transform.SetParent(gameObject.transform);
        panel.transform.localPosition = new Vector3(0, 0, 0);
    }
}
