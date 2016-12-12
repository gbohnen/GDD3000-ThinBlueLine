using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    /// <summary>
    /// Class which handles all of the stats in the game
    /// </summary>
    static class StatTracker
    {
        #region Fields

        public static int crimeSmartsSpent = 0;
        public static int crimeMoxieSpent = 0;
        public static int crimeStrengthSpent = 0;

        static int totalSpentTowardCrime = 0;
        static int nbrUnresolvedSit = 0;
        static int nbrResolvedSit = 0;
        static int nbrDrawnSit = 0;
        static int nbrLowerCrime = 0;
        static int nbrChangeNeigh = 0;

        public static int player1SituationsDrawn = 0;
        public static int player1SituationsClosed = 0;
        public static int player1CrimeLowered = 0;
        public static int player1ChangeNeighborhood = 0;
        public static int player1StatsSpentOnMajorCrime = 0;

        public static int player2SituationsDrawn = 0;
        public static int player2SituationsClosed = 0;
        public static int player2CrimeLowered = 0;
        public static int player2ChangeNeighborhood = 0;
        public static int player2StatsSpentOnMajorCrime = 0;

        public static int player3SituationsDrawn = 0;
        public static int player3SituationsClosed = 0;
        public static int player3CrimeLowered = 0;
        public static int player3ChangeNeighborhood = 0;
        public static int player3StatsSpentOnMajorCrime = 0;

        public static int player4SituationsDrawn = 0;
        public static int player4SituationsClosed = 0;
        public static int player4CrimeLowered = 0;
        public static int player4ChangeNeighborhood = 0;
        public static int player4StatsSpentOnMajorCrime = 0;
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the stats spent towards major crime
        /// </summary>
        public static int StatsToMajorCrime
        {
            get { return player1StatsSpentOnMajorCrime + player2StatsSpentOnMajorCrime + player3StatsSpentOnMajorCrime + player4StatsSpentOnMajorCrime; }
            set
            {
                switch (GameManager.Instance.CurrentPlayer)
                {
                    case Players.Player1:
                        player1StatsSpentOnMajorCrime = value;
                        break;
                    case Players.Player2:
                        player2StatsSpentOnMajorCrime = value;
                        break;
                    case Players.Player3:
                        player3StatsSpentOnMajorCrime = value;
                        break;
                    case Players.Player4:
                        player4StatsSpentOnMajorCrime = value;
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or sets the number or unresolved situations
        /// </summary>
        public static int UnresolvedSituations
        {
            get { return nbrUnresolvedSit; }
            set { nbrUnresolvedSit = value; }
        }

        /// <summary>
        /// Gets or sets the number of resolved situations
        /// </summary>
        public static int ResolvedSituations
        {
            get { return nbrResolvedSit; }
            set { nbrResolvedSit = value; }
        }

        /// <summary>
        /// Gets or sets the number of drawn situations
        /// </summary>
        public static int DrawnSituations
        {
            get { return player1SituationsDrawn + player2SituationsDrawn + player3SituationsDrawn + player4SituationsDrawn; }
            set
            {
                switch (GameManager.Instance.CurrentPlayer)
                {
                    case Players.Player1:
                        player1SituationsDrawn = value;
                        break;
                    case Players.Player2:
                        player2SituationsDrawn = value;
                        break;
                    case Players.Player3:
                        player3SituationsDrawn = value;
                        break;
                    case Players.Player4:
                        player4SituationsDrawn = value;
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or sets the number of times lowered crime
        /// </summary>
        public static int TimesLoweredCrime
        {
            get { return player1CrimeLowered + player2CrimeLowered + player3CrimeLowered + player4CrimeLowered; }
            set
            {
                switch (GameManager.Instance.CurrentPlayer)
                {
                    case Players.Player1:
                        player1CrimeLowered = value;
                        break;
                    case Players.Player2:
                        player2CrimeLowered = value;
                        break;
                    case Players.Player3:
                        player3CrimeLowered = value;
                        break;
                    case Players.Player4:
                        player4CrimeLowered = value;
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the number of times changed neighborhood
        /// </summary>
        public static int TimesChangedNeighborhood
        {
            get { return player1ChangeNeighborhood + player2ChangeNeighborhood + player3ChangeNeighborhood + player4ChangeNeighborhood; }
            set
            {
                switch (GameManager.Instance.CurrentPlayer)
                {
                    case Players.Player1:
                        player1ChangeNeighborhood = value;
                        break;
                    case Players.Player2:
                        player2ChangeNeighborhood = value;
                        break;
                    case Players.Player3:
                        player3ChangeNeighborhood = value;
                        break;
                    case Players.Player4:
                        player4ChangeNeighborhood = value;
                        break;
                }
            }
        }

        #endregion
    }
}