using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// Script which handles the players in the game
    /// </summary>
    public class PlayerScript : CardScript
    {
        #region Fields

        int smarts;
        int moxie;
        int muscles;
        Sprite avat;
        string bio;
        string special;
        Neighborhood activeNeighborhood;

        float randStat = Random.value;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the nieighborhood
        /// </summary>
        public Neighborhood Neighborhood
        {
            get { return activeNeighborhood; }
            set { activeNeighborhood = value; }
        }

        /// <summary>
        /// Gets the players moxie
        /// </summary>
        public int Moxie
        {
            get { return moxie; }
            set { moxie = value; }
        }

        /// <summary>
        /// Gets the players strength
        /// </summary>
        public int Muscle
        {
            get { return muscles; }
            set { muscles = value; }
        }

        /// <summary>
        /// Gets the players smarts
        /// </summary>
        public int Smarts
        {
            get { return smarts; }
            set { smarts = value; }
        }

        /// <summary>
        /// Gets or sets a random stat from the player
        /// </summary>
        public int RandomStat
        {
            get
            {
                // return moxie
                if (randStat < Constants.MOXIE_THRESHOLD)
                { return moxie; }
                // return muscles
                else if (randStat < Constants.MUSCLE_THRESHOLD)
                { return muscles; }
                // return smarts
                else
                { return smarts; }
            }
            set
            {
                // set moxie
                if (randStat < Constants.MOXIE_THRESHOLD)
                { moxie = value; }
                // set muscles
                else if (randStat < Constants.MUSCLE_THRESHOLD)
                { muscles = value; }
                // set smarts
                else
                { smarts = value; }
            }
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

        /// <summary>
        /// Gets the players avatar
        /// </summary>
        public Sprite Avatar
        {
            get { return avat; }
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

            avat = Resources.Load<Sprite>(data.avatPath);
        }

        #endregion
    }
}