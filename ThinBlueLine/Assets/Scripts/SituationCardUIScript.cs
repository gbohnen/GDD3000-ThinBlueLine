using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// 
    /// </summary>
    class SituationCardUIScript : MonoBehaviour
    {
        #region Fields

        // store the situations information
        public Text situationName;
        public Text cost;
        public Text description;


        //public Text smartsCost;
        //public Text moxieCost;
        //public Text strengthCost;

        // store the demo situation
        public SituationScript demoSitch;

        #endregion

        #region Public Methods

        // Use this for initilization
        void Start()
        {
            //demoSitch = new SituationScript(LoadGameData.LoadSituations()[0]);
            //UpdateFields();
        }

        /// <summary>
        /// Updates the information for the situation card
        /// </summary>
        public void UpdateFields()
        {
            situationName.text = demoSitch.Name;
            cost.text = demoSitch.Cost.ToString();
            description.text = demoSitch.Description;
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        public void Close()
        { Destroy(this); }

        #endregion
    }
}