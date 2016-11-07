using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

/// <summary>
/// Handles the situations
/// </summary>
public class SituationSpawnScript : MonoBehaviour
{
    // parent of the prefab object, prefab object
    public Transform situationCardParent;
    public GameObject situationCardPrefab;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="situation"></param>
    public void OpenSituationCard(SituationScript situation)
    {
        // instantiate the prefab, load the script attached to it
        GameObject prefab = Instantiate(situationCardPrefab) as GameObject;
        SituationCardUIScript situationCard = prefab.GetComponent<SituationCardUIScript>();

        // set all UI fields based on the situation
        situationCard.situationName.text = situation.Name;
        situationCard.cost.text = situation.Cost.ToString();
        situationCard.description.text = situation.Description;

        // set the situation
        situationCard.demoSitch = situation;

        // set the parent of the object
        prefab.transform.SetParent(situationCardParent);
    }
}