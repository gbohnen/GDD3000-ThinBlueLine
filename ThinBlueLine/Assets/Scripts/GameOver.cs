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

        public Text player1Name;
        public Text player2Name;
        public Text player3Name;
        public Text player4Name;

        public Text player1majorcrimes;
        public Text player1sitdrawn;
        public Text player1sitresolved;
        public Text player1crimelowered;
        public Text player1neighborhoodchanges;

        public Text player2majorcrimes;
        public Text player2sitdrawn;
        public Text player2sitresolved;
        public Text player2crimelowered;
        public Text player2neighborhoodchanges;

        public Text player3majorcrimes;
        public Text player3sitdrawn;
        public Text player3sitresolved;
        public Text player3crimelowered;
        public Text player3neighborhoodchanges;

        public Text player4majorcrimes;
        public Text player4sitdrawn;
        public Text player4sitresolved;
        public Text player4crimelowered;
        public Text player4neighborhoodchanges;

        #endregion

        #region Public Methods

        /// <summary>
        /// Use this for initialization 
        /// </summary>
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
            majorCrimeTier.text = "Tier: 3";
            smartsSpent.text = "000";
            moxieSpent.text = "000";
            muscleSpent.text = "000";
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

            // store and get the # of situations open & resolved
            sitOpen.text = GameLibrary.instance.SituationList.Count.ToString();
            sitResolved.text = StatTracker.ResolvedSituations.ToString();

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

        /// <summary>
        /// Checks the status of the neighborhood
        /// </summary>
        /// <param name="data">the nieghborhood data</param>
        /// <returns></returns>
        public string CheckNeighborHoodStatus(NeighborhoodData data)
        {
            // store string
            string status;

            // store the stats
            int i = (int)(data.Chaos + data.Corruption + data.MafiaPresence);

            // Great
            if (i <= 0)
                status = "Perfick!";
            // Good
            else if (i <= 3)
                status = "Pretty Solid!";
            // Alright
            else if (i <= 6)
                status = "Eh...";
            // Bad
            else if (i <= 9)
                status = "I wouldn't move there...";
            else if (i <= 12)
            // Worse
                status = "Gross!";
            // Horrible
            else
                status = "Abyssmal.";

            // return the status
            return status;
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