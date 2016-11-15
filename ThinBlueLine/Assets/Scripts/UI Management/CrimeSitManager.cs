using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;

namespace Assets.Scripts
{
    // class attached the ui that controlls the situationlist
    public class CrimeSitManager : MonoBehaviour
    {
        // gameobject management fields
        public Animator drawerAnimator;
        public Animator buttonAnimator;

        // situation list fields
        public Transform situationScrollPanel;              // parent that the prefab goes in
        public GameObject situationPrefab;                  // prefab that we want to spawn

        public static Dictionary<string, GameObject> ActiveSituations;

        void Start()
        {
            drawerAnimator = GetComponent<Animator>();

            ActiveSituations = new Dictionary<string, GameObject>();
        }

        // called by gamemanager when we draw a new situation
        public void AddSituation(SituationScript sitch)
        {
            // instantiate a prefab. load the script attached to it
            GameObject newButton = Instantiate(situationPrefab) as GameObject;
            SituationButton button = newButton.GetComponent<SituationButton>();

            ActiveSituations.Add(sitch.Name, newButton);

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

        //public void OpenSituations()
        //{
        //    if (drawerAnimator.GetBool("Open"))
        //        CloseDrawer();
        //    else
        //    {
        //        drawerAnimator.SetBool("Open", true);
        //        buttonAnimator.SetBool("Open", true);
        //    }
        //}

        //public void CloseDrawer()
        //{
        //    drawerAnimator.SetBool("Open", false);
        //    buttonAnimator.SetBool("Open", false);
        //}

        public void ToggleDrawer()
        {
            if (drawerAnimator.GetBool("Open"))
            {
                drawerAnimator.SetBool("Open", false);
                buttonAnimator.SetBool("Open", false);
            }
            else
            {
                drawerAnimator.SetBool("Open", true);
                buttonAnimator.SetBool("Open", true);
            }
        }
    }
}
