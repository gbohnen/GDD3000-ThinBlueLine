using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Script which handles the mob boss
    /// </summary>
    public class MobBossScript : CardScript
    {
        #region Fields

        // store the revealed & loss conditons flag
        bool isRevealed = false;
        bool lossConditionMet = false;

        // store the stats spent and modifiers for crime
        Vector3 statsSpent;
        Vector3 modifiers;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets if the mob boss is active
        /// </summary>
        public bool IsActive
        { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MobBossScript(LoadGameData.MobBoss data) : base()
        {

        }

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

        /// <summary>
        /// Reveals this boss in the game
        /// </summary>
        public void RevealSelf()
        { }

        /// <summary>
        /// Checks the loss condition of this boss
        /// </summary>
        public void CheckLossCondition()
        { }

        #endregion
    }
}