using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;

namespace Assets.Scripts
{
    // class attached the ui that controlls the situationlist
    public class CrimeSitManager : MonoBehaviour
    {
        // gameobject management fields
        public Animator drawerAnimator;


        // situation list fields
        public Transform situationScrollPanel;              // parent that the prefab goes in
        public GameObject situationPrefab;                  // prefab that we want to spawn
        
        void Start()
        {
            drawerAnimator = GetComponent<Animator>();
        }

        // called by gamemanager when we draw a new situation
        public void AddSituation(SituationScript sitch)
        {
            // instantiate a prefab. load the script attached to it
            GameObject newButton = Instantiate(situationPrefab) as GameObject;
            SituationButton button = newButton.GetComponent<SituationButton>();

            // set all ui fields based on the situation we were given
            button.situationName.text   = sitch.Name;
            button.cost.text            = "Cost:           " + sitch.Cost.ToString();
            button.smartsMod.text       = "x " + sitch.SmartsModifier.ToString();
            button.moxieMod.text        = "x " + sitch.MoxieModifier.ToString();
            button.musclesMod.text      = "x " + sitch.MuscleModifier.ToString();
            button.posResolution.text   = sitch.PositiveOutcome;
            button.negResolution.text   = sitch.NegativeOutcome;
            button.desc.text            = sitch.Description;
            button.immEffect.text       = sitch.ImmediateEffect;
            button.ongEffect.text       = sitch.OngoingEffect;

            // hand off the situation
            button.situation = sitch;

            // set the parent transform. in this case, this is the scrollable list of sitchs
            newButton.transform.SetParent(situationScrollPanel);
        }

        public void OpenSituations()
        {
            drawerAnimator.SetBool("Open", true);
        }

        public void CloseDrawer()
        {
            drawerAnimator.SetBool("Open", false);
        }
    }
}
