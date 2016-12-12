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
            // player 1
            player1Name.text = GameLibrary.instance.Players[Players.Player1].Name;
            player1majorcrimes.text = StatTracker.player1StatsSpentOnMajorCrime.ToString();
            player1sitdrawn.text = StatTracker.player1SituationsDrawn.ToString();
            player1sitresolved.text = StatTracker.player1SituationsClosed.ToString();
            player1crimelowered.text = StatTracker.player1CrimeLowered.ToString();
            player1neighborhoodchanges.text = StatTracker.player1ChangeNeighborhood.ToString();

            // player 2
            player2Name.text = GameLibrary.instance.Players[Players.Player2].Name;
            player2majorcrimes.text = StatTracker.player2StatsSpentOnMajorCrime.ToString();
            player2sitdrawn.text = StatTracker.player2SituationsDrawn.ToString();
            player2sitresolved.text = StatTracker.player2SituationsClosed.ToString();
            player2crimelowered.text = StatTracker.player2CrimeLowered.ToString();
            player2neighborhoodchanges.text = StatTracker.player2ChangeNeighborhood.ToString();

            // player 3
            player3Name.text = GameLibrary.instance.Players[Players.Player3].Name;
            player3majorcrimes.text = StatTracker.player3StatsSpentOnMajorCrime.ToString();
            player3sitdrawn.text = StatTracker.player3SituationsDrawn.ToString();
            player3sitresolved.text = StatTracker.player3SituationsClosed.ToString();
            player3crimelowered.text = StatTracker.player3CrimeLowered.ToString();
            player3neighborhoodchanges.text = StatTracker.player3ChangeNeighborhood.ToString();

            // player 4
            player4Name.text = GameLibrary.instance.Players[Players.Player4].Name;
            player4majorcrimes.text = StatTracker.player4StatsSpentOnMajorCrime.ToString();
            player4sitdrawn.text = StatTracker.player4SituationsDrawn.ToString();
            player4sitresolved.text = StatTracker.player4SituationsClosed.ToString();
            player4crimelowered.text = StatTracker.player4CrimeLowered.ToString();
            player4neighborhoodchanges.text = StatTracker.player4ChangeNeighborhood.ToString();
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