using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Base class script which handles the cards in the game
    /// </summary>
    public abstract class CardScript : MonoBehaviour
    {
        #region Fields

        // store the name and description of object
        protected string cardName;
        protected string description;

        // store the sprite and game object
        Texture2D sprite;
        GameObject target;

        // store the objects stats
        Vector3 stats;

        // store the objects tool tip
        //ToolTipScript toolTip;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the object
        /// </summary>
        public string Name
        {
            get { return cardName; }
        }

        /// <summary>
        /// Gets or sets the description of the object
        /// </summary>
        public string Description
        { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public CardScript()
        { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads the card
        /// </summary>
        /// <param name="gameObject">the game object</param>
        public void LoadCard(GameObject gameObject)
        {
            gameObject = Resources.Load<GameObject>(Constants.CARD_FOLDER_NAME);
        }

        public void ParseMethod(string command)
        {
            do
            {
                int cIndex = command.IndexOf(';');
                string method;

                // grab first method
                if (cIndex > 0)
                {
                    method = command.Substring(0, cIndex);
                    command.Remove(0, cIndex);
                }
                // other wise just grab base method
                else
                    method = command;

                // parse out parameters
                do
                {
                    int pIndex = method.IndexOf(':');






                } while (method.IndexOf(':') > 0);



            } while (command.IndexOf(';') > 0);
        }

        // TODO: Animation

        #endregion
    }
}