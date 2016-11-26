using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;
using System;

namespace Assets.Scripts
{
    // class attached the ui that controlls the situationlist
    public class CrimeSitManager : MonoBehaviour
    {
        // gameobject management fields
        public Animator drawerAnimator;
        public Animator buttonAnimator;
        public Animator containerSlide;

        #region Situation Manager Fields

        // situation list fields
        public Transform situationScrollPanel;              // parent that the prefab goes in
        public GameObject situationPrefab;                  // prefab that we want to spawn

        public static Dictionary<string, GameObject> ActiveSituations;

        public GameObject stonyGateContent;
        public GameObject suburbiaContent;
        public GameObject downtownContent;
        public GameObject boxesContent;
        public GameObject docksContent;

        public GameObject stonyGateButton;
        public GameObject suburbiaButton;
        public GameObject downtownButton;
        public GameObject boxesButton;
        public GameObject docksButton;

        public ScrollRect scrollRect;
        public Scrollbar scrollBar;

        public List<GameObject> buttons;

        Dictionary<Neighborhood, GameObject> neighborhoodPanels;

        Color activeButton;
        Color inactiveButton = Color.white;

        #endregion

        #region Major Crime Manager Fields

        public GameObject tierOne;
        public GameObject tierTwo;
        public GameObject tierThree;
        public GameObject tierFour;
        public GameObject tierFive;

        List<GameObject> tierObjectList;

        #endregion

        void Start()
        {
            drawerAnimator = GetComponent<Animator>();

            // set up situations
            ActiveSituations = new Dictionary<string, GameObject>();
            neighborhoodPanels = new Dictionary<Neighborhood, GameObject>();
            buttons = new List<GameObject>();
            buttons.Add(stonyGateButton);
            buttons.Add(suburbiaButton);
            buttons.Add(downtownButton);
            buttons.Add(boxesButton);
            buttons.Add(docksButton);

            neighborhoodPanels.Add(Neighborhood.StonyGate, stonyGateContent);
            neighborhoodPanels.Add(Neighborhood.Suburbia, suburbiaContent);
            neighborhoodPanels.Add(Neighborhood.Downtown, downtownContent);
            neighborhoodPanels.Add(Neighborhood.TheBoxes, boxesContent);
            neighborhoodPanels.Add(Neighborhood.Portside, docksContent);

            activeButton = new Color(1, .1f, .1f, .5f);

            // set up crimes
            tierObjectList.Add(tierOne);
            //tierObjectList.Add(tierTwo);
            //tierObjectList.Add(tierThree);
            //tierObjectList.Add(tierFour);
            //tierObjectList.Add(tierFive);

            UpdateMajorCrimeDisplay();
        }

        // called by gamemanager when we draw a new situation
        public void AddSituation(SituationScript sitch)
        {
            // instantiate a prefab. load the script attached to it
            GameObject newButton = Instantiate(situationPrefab) as GameObject;
            SituationButton button = newButton.GetComponent<SituationButton>();

            ActiveSituations.Add(sitch.Name, newButton);

            // set all ui fields based on the situation we were given
            button.situationName.text = sitch.Name;
            button.cost.text = "Cost:           " + sitch.Cost.ToString();
            button.smartsMod.text = "x " + sitch.SmartsModifier.ToString();
            button.moxieMod.text = "x " + sitch.MoxieModifier.ToString();
            button.musclesMod.text = "x " + sitch.MuscleModifier.ToString();
            button.posResolution.text = sitch.PositiveOutcome;
            button.negResolution.text = sitch.NegativeOutcome;
            button.desc.text = sitch.Description;
            button.immEffect.text = sitch.ImmediateEffect;
            button.ongEffect.text = sitch.OngoingEffect;

            // hand off the situation
            button.situation = sitch;

            // add a switch statement to set to the correct neighborhood
            switch (GameManager.Instance.activeNeighborhood)
            {
                case Neighborhood.StonyGate:
                    newButton.transform.SetParent(stonyGateContent.transform);
                    break;
                case Neighborhood.Suburbia:
                    newButton.transform.SetParent(suburbiaContent.transform);
                    break;
                case Neighborhood.Downtown:
                    newButton.transform.SetParent(downtownContent.transform);
                    break;
                case Neighborhood.TheBoxes:
                    newButton.transform.SetParent(boxesContent.transform);
                    break;
                case Neighborhood.Portside:
                    newButton.transform.SetParent(docksContent.transform);
                    break;
            }
        }

        #region Animation Methods

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

                SetActive(GameManager.Instance.activeNeighborhood.ToString());
            }

            SetCurrentButtonColor();
        }

        public void CloseDrawer()
        {
            drawerAnimator.SetBool("Open", false);
            buttonAnimator.SetBool("Open", false);
        }

        public void OpenDrawer()
        {
            drawerAnimator.SetBool("Open", true);
            buttonAnimator.SetBool("Open", true);

            SetActive(GameManager.Instance.activeNeighborhood.ToString());
        }

        public void SituationClicked()
        {
            if (drawerAnimator.GetBool("Open"))
                CloseDrawer();
            else
                OpenDrawer();

            // set animator to slide to situation
            containerSlide.SetBool("Left", true);
        }

        public void MajorCrimesClicked()
        {
            if (drawerAnimator.GetBool("Open"))
                CloseDrawer();
            else
                OpenDrawer();

            //Set animator to slide to major crimes
            containerSlide.SetBool("Left", false);
        }

        #endregion

        #region Situation Methods

        public void ClearButtons(Button button)
        {
            ReallyClearButtons();

            button.GetComponent<Image>().color = activeButton;

            SetCurrentButtonColor();

            SetActive(button.name);
        }

        public void ReallyClearButtons()
        {
            foreach (GameObject mubutton in buttons)
            {
                mubutton.GetComponent<Image>().color = inactiveButton;
            }
        }

        private void SetCurrentButtonColor()
        {
            ReallyClearButtons();

            switch (GameManager.Instance.activeNeighborhood)
            {
                case Neighborhood.StonyGate:
                    stonyGateButton.GetComponent<Image>().color = Color.cyan;
                    break;
                case Neighborhood.Suburbia:
                    suburbiaButton.GetComponent<Image>().color = Color.cyan;
                    break;
                case Neighborhood.Downtown:
                    downtownButton.GetComponent<Image>().color = Color.cyan;
                    break;
                case Neighborhood.TheBoxes:
                    boxesButton.GetComponent<Image>().color = Color.cyan;
                    break;
                case Neighborhood.Portside:
                    docksButton.GetComponent<Image>().color = Color.cyan;
                    break;
                default:
                    break;
            }
        }

        public void SetActive(string name)
        {
            switch (name)
            {
                case "StonyGate":
                    stonyGateContent.transform.SetAsLastSibling();
                    scrollRect.content = stonyGateContent.GetComponent<RectTransform>();
                    break;
                case "Suburbia":
                    suburbiaContent.transform.SetAsLastSibling();
                    scrollRect.content = suburbiaContent.GetComponent<RectTransform>();
                    break;
                case "Downtown":
                    downtownContent.transform.SetAsLastSibling();
                    scrollRect.content = downtownContent.GetComponent<RectTransform>();
                    break;
                case "TheBoxes":
                    boxesContent.transform.SetAsLastSibling();
                    scrollRect.content = boxesContent.GetComponent<RectTransform>();
                    break;
                case "TheDocks":
                    docksContent.transform.SetAsLastSibling();
                    scrollRect.content = docksContent.GetComponent<RectTransform>();
                    break;
                default:
                    break;
            }

            scrollBar.value = 1;
        }

        #endregion

        #region MajorCrimes Methods

        public void UpdateMajorCrimeDisplay()
        {

        }
        
        public void LoadSituationTier(MajorCrimeTier tier, GameObject button)
        {

        }

        #endregion
    }
}