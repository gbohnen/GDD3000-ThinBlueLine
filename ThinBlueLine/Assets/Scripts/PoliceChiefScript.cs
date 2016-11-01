namespace Assets.Scripts
{
    /// <summary>
    /// Script which handles the police chief
    /// </summary>
    class PoliceChiefScript : CardScript
    {
        #region Fields

        // store the different moods the police chief holds
        float angry;
        float happy;
        float worried;
        float suspicious;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public PoliceChiefScript() : base()
        { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Does nothing, play continues
        /// </summary>
        public void DoNothing()
        { }

        /// <summary>
        /// Reveals a situation to a random neighborhood
        /// </summary>
        public void RevealSituation()
        { }

        /// <summary>
        /// Increases random player(s) reputation within a random neighborhood
        /// </summary>
        public void GrantComm()
        { }

        /// <summary>
        /// Increases each players stats between specified amount (1 and 3)
        /// </summary>
        public void RewardInves()
        { }

        /// <summary>
        /// Investigates a random player, forcing that player to only take 1 Action
        /// </summary>
        public void IntAffairs()
        { }

        /// <summary>
        /// Calculates the mood of the police chief
        /// </summary>
        public void CalculateMood()
        { }
        
        #endregion
    }
}