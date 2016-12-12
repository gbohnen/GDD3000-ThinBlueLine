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

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the stats spent towards major crime
        /// </summary>
        public static int StatsToMajorCrime
        {
            get { return totalSpentTowardCrime; }
            set { totalSpentTowardCrime = value; }
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
            get { return nbrDrawnSit; }
            set { nbrDrawnSit = value; }
        }

        /// <summary>
        /// Gets or sets the number of times lowered crime
        /// </summary>
        public static int TimesLoweredCrime
        {
            get { return nbrLowerCrime; }
            set { nbrLowerCrime = value; }
        }

        /// <summary>
        /// Sets the number of times changed neighborhood
        /// </summary>
        public static int TimesChangedNeigh
        {
            get { return nbrChangeNeigh; }
            set { nbrChangeNeigh = value; }
        }

        #endregion
    }
}