using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// Script which handles when the game is over
    /// </summary>
    class GameOver : MonoBehaviour
    {
        #region Fields

        // store the buttons
        public GameObject startOverButton;
        public GameObject quitGameButton;

        // UI

        // major crime
        public Text majorCrimeName;
        public Text majorCrimeDescr;
        public Text majorCrimeTier;
        public Text smartsSpent;
        public Text moxieSpent;
        public Text muscleSpent;

        // city
        public Text cityPoliceCorr;
        public Text cityChaos;
        public Text cityMafiaPres;
        public Text sitOpen;
        public Text sitResolved;
        public Text sgStatus;
        public Text sStatus;
        public Text dtStatus;
        public Text tbStatus;
        public Text ptStatus;

        // players
        public Text playerWSmartsAmt;
        public Text playerWMoxieAmt;
        public Text playerWMuscleAmt;
        public Text playerWReputation;
        public Text playerXSmartsAmt;
        public Text playerXMoxieAmt;
        public Text playerXMuscleAmt;
        public Text playerXReputation;
        public Text playerYSmartsAmt;
        public Text playerYMoxieAmt;
        public Text playerYMuscleAmt;
        public Text playerYReputation;
        public Text playerZSmartsAmt;
        public Text playerZMoxieAmt;
        public Text playerZMuscleAmt;
        public Text playerZReputation;

        #endregion

        #region Public Methods

        public void Awake()
        {
            SetMajorCrimeInfo();
            SetCityInfo();
            SetPlayerInfo();
        }

        /// <summary>
        /// Sets the major crime information
        /// </summary>
        public void SetMajorCrimeInfo()
        {
            majorCrimeName.text = GameManager.Instance.majorCrime.Name;
            majorCrimeDescr.text = GameManager.Instance.majorCrime.CrimeTiers[3].TierDescription;
            majorCrimeTier.text = "3";
            smartsSpent.text = "";
            moxieSpent.text = "";
            muscleSpent.text = "";
    }

        /// <summary>
        /// Sets the city information
        /// </summary>
        public void SetCityInfo()
        {
            // set the citys overall info
            cityPoliceCorr.text = GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Corruption.ToString();
            cityChaos.text = GameLibrary.instance.Neighborhoods[Neighborhood.Overall].Chaos.ToString();
            cityMafiaPres.text = GameLibrary.instance.Neighborhoods[Neighborhood.Overall].MafiaPresence.ToString();

            // TODO: store and get the # of situations open & resolved
            sitOpen.text = GameLibrary.instance.SituationList.Count.ToString();
            sitResolved.text = GameManager.Instance.SituationsCleared.ToString();

            // TODO: store and get the status of each neighborhood, dependent on their stats
            sgStatus.text = CheckNeighborHoodStatus(GameLibrary.instance.Neighborhoods[Neighborhood.StonyGate]);
            sStatus.text = CheckNeighborHoodStatus(GameLibrary.instance.Neighborhoods[Neighborhood.Suburbia]);
            dtStatus.text = CheckNeighborHoodStatus(GameLibrary.instance.Neighborhoods[Neighborhood.Downtown]);
            tbStatus.text = CheckNeighborHoodStatus(GameLibrary.instance.Neighborhoods[Neighborhood.TheBoxes]);
            ptStatus.text = CheckNeighborHoodStatus(GameLibrary.instance.Neighborhoods[Neighborhood.Portside]);
        }

        /// <summary>
        /// Sets the players information
        /// </summary>
        public void SetPlayerInfo()
        {
            // player W
            playerWSmartsAmt.text = GameLibrary.instance.Players[Players.Player1].Smarts.ToString();
            playerWMoxieAmt.text = GameLibrary.instance.Players[Players.Player1].Moxie.ToString();
            playerWMuscleAmt.text = GameLibrary.instance.Players[Players.Player1].Muscle.ToString();

            // player X
            playerXSmartsAmt.text = GameLibrary.instance.Players[Players.Player2].Smarts.ToString();
            playerXMoxieAmt.text = GameLibrary.instance.Players[Players.Player2].Moxie.ToString();
            playerXMuscleAmt.text = GameLibrary.instance.Players[Players.Player2].Muscle.ToString();

            // player Y
            playerYSmartsAmt.text = GameLibrary.instance.Players[Players.Player3].Smarts.ToString();
            playerYMoxieAmt.text = GameLibrary.instance.Players[Players.Player3].Moxie.ToString();
            playerYMuscleAmt.text = GameLibrary.instance.Players[Players.Player3].Muscle.ToString();

            // player Z
            playerZSmartsAmt.text = GameLibrary.instance.Players[Players.Player4].Smarts.ToString();
            playerZMoxieAmt.text = GameLibrary.instance.Players[Players.Player4].Moxie.ToString();
            playerZMuscleAmt.text = GameLibrary.instance.Players[Players.Player4].Muscle.ToString();
        }

        public string CheckNeighborHoodStatus(NeighborhoodData data)
        {
            string str;

            int i = (int)(data.Chaos + data.Corruption + data.MafiaPresence);

            if (i <= 0)
                str = "Perfick!";
            else if (i <= 3)
                str = "Pretty Solid!";
            else if (i <= 6)
                str = "Eh...";
            else if (i <= 9)
                str = "I wouldn't move there...";
            else if (i <= 12)
                str = "Gross!";
            else
                str = "Abyssmal.";

            return str;
        }

        /// <summary>
        /// Occurs when the start over button is clicked
        /// </summary>
        public void StartOver()
        { SceneManager.LoadScene(Constants.MAIN_MENU_SCENE); }

        /// <summary>
        /// Occurs when the exit game button is clicked
        /// </summary>
        public void ExitGame()
        { Application.Quit(); }

        #endregion
    }
}