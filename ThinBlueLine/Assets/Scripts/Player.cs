namespace Assets.Scripts
{
    /// <summary>
    /// Script which handles the players in the game
    /// </summary>
    class PlayerScript : CardScript
    {
        #region Fields

        // store the special move for this player
        //delegate specialMove;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the players moxie
        /// </summary>
        public int Moxie
        {
            get; private set;
        }

        /// <summary>
        /// Gets or sets the players strength
        /// </summary>
        public int Strength
        {
            get; private set;
        }

        /// <summary>
        /// Gets or sets the players smarts
        /// </summary>
        public int Smarts
        {
            get; private set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public PlayerScript() : base ()
        { }

        #endregion

        #region Public Methodas

        /// <summary>
        /// Switch the neighborhood that this player is in
        /// </summary>
        public void ChangeNeighborhood()
        { }

        /// <summary>
        /// Spend certain amount of stats toward a situation
        /// </summary>
        public void SpendStatsSituation()
        { }

        /// <summary>
        /// Spend certain ampunt of stats toward City Crime Level
        /// </summary>
        public void SpendStatsCrime()
        { }

        /// <summary>
        /// Adds a situation to the current game
        /// </summary>
        public void AddSituation()
        { }

        /// <summary>
        /// Lowers the City Crime Level
        /// </summary>
        public void LowerCrime()
        { }

        /// <summary>
        /// Uses this players special
        /// </summary>
        public void UseSpecial()
        { }

        #endregion
    }
}