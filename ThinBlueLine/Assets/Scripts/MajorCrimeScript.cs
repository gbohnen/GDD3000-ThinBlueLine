using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    /// <summary>
    /// Script which handles the major crime
    /// </summary>
    class MajorCrimeScript : CardScript
    {
        #region Fields

        // store the list of situations
        List<SituationScript> tiers;

        // store the stats spent and modifiers for crime
        Vector3 statsSpent;
        Vector3 modifiers;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current tier of this crime
        /// </summary>
        public SituationScript CurrentTier
        { get; private set; }

        /// <summary>
        /// Gets or sets the stats spent on this crime
        /// </summary>
        public Vector3 StatsSpent
        { get; private set; }

        /// <summary>
        /// Gets or sets the modifiers on this crime
        /// </summary>
        public Vector3 Modifiers
        { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MajorCrimeScript() : base()
        { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Triggers a negative outcome
        /// </summary>
        public void TriggerNegOutcome()
        { }

        /// <summary>
        /// Triggers a positive outcome
        /// </summary>
        public void TriggerPosOutcome()
        { }

        /// <summary>
        /// Triggers an immediate effect
        /// </summary>
        public void TriggerImmEffect()
        { }

        /// <summary>
        /// Triggers an ongoing effect
        /// </summary>
        public void TriggerOngEffect()
        { }

        #endregion
    }
}