using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// Script which handles the players in the game
    /// </summary>
    public class PlayerScript : CardScript
    {
        #region Fields

        // store the special move for this player
        //delegate specialMove;

        int smarts;
        int moxie;
        int muscles;
        Image avat;
        string bio;
        string special;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the players moxie
        /// </summary>
        public int Moxie
        {
            get { return moxie; }
        }

        /// <summary>
        /// Gets the players strength
        /// </summary>
        public int Strength
        {
            get { return muscles; }
        }

        /// <summary>
        /// Gets the players smarts
        /// </summary>
        public int Smarts
        {
            get { return smarts; }
        }

        /// <summary>
        /// Gets the players special
        /// </summary>
        public string Special
        {
            get { return special; }
        }

        /// <summary>
        /// Gets the players bio
        /// </summary>
        public string Bio
        {
            get { return bio; }
        }


        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public PlayerScript(LoadGameData.Player data) : base()
        {
            cardName = data.name;

            smarts = data.smarts;
            moxie = data.moxie;
            muscles = data.muscle;

            bio = data.story;
            special = data.special;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Switch the current neighborhood that this player is in
        /// </summary>
        public void SwitchNeighborhood()
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