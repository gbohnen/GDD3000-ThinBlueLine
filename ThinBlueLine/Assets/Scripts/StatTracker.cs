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

        static int totalSpentTowardCrime = 0;
        static int nbrUnresolvedSit = 0;
        static int nbrResolvedSit = 0;
        static int nbrDrawnSit = 0;
        static int nbrLowerCrime = 0;
        static int nbrChangeNeigh = 0;

        static int player1SituationsDrawn;
        static int player1SituationsClosed;
        static int player1CrimeLowered;
        static int player1ChangeNeighborhood;
        static int player1StatsSpentOnMajorCrime;

        static int player2SituationsDrawn;
        static int player2SituationsClosed;
        static int player2CrimeLowered;
        static int player2ChangeNeighborhood;
        static int player2StatsSpentOnMajorCrime;

        static int player3SituationsDrawn;
        static int player3SituationsClosed;
        static int player3CrimeLowered;
        static int player3ChangeNeighborhood;
        static int player3StatsSpentOnMajorCrime;

        static int player4SituationsDrawn;
        static int player4SituationsClosed;
        static int player4CrimeLowered;
        static int player4ChangeNeighborhood;
        static int player4StatsSpentOnMajorCrime;
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