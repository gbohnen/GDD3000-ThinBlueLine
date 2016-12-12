using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI_Management
{
    /// <summary>
    /// Script which handles lowering neighborhood crime
    /// </summary>
    class LowerNeighborhoodCrime : MonoBehaviour 
    {
        #region Fields

        // UI fields
        public Text smartsText;
        public Text moxieText;
        public Text muscleText;
        public Slider smartsSlider;
        public Slider moxieSlider;
        public Slider muscleSlider;
        public Text policeCorrText;
        public Text chaosText;
        public Text mafiaPresText;

        float totalThreshold = 3.0f;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the sum of the sliders
        /// </summary>
        private float SliderSum
        {
            get { return smartsSlider.value + moxieSlider.value + muscleSlider.value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads the correct data
        /// </summary>
        public void Load()
        {
            // set the players stats
            smartsText.text = GameManager.Instance.CurrentPlayerObj.Smarts.ToString() + Constants.ARROW + GameManager.Instance.CurrentPlayerObj.Smarts.ToString();
            moxieText.text = GameManager.Instance.CurrentPlayerObj.Moxie.ToString() + Constants.ARROW + GameManager.Instance.CurrentPlayerObj.Moxie.ToString();
            muscleText.text = GameManager.Instance.CurrentPlayerObj.Muscle.ToString() + Constants.ARROW + GameManager.Instance.CurrentPlayerObj.Muscle.ToString();

            // set the neighborhood stats
            policeCorrText.text = GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Corruption.ToString() + 
                                  Constants.ARROW + GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Corruption.ToString();
            chaosText.text = GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Chaos.ToString() +
                             Constants.ARROW + GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Chaos.ToString();
            mafiaPresText.text = GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].MafiaPresence.ToString() + 
                                 Constants.ARROW + GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].MafiaPresence.ToString();

            // resets the buttons
            ResetButton();
        }

        /// <summary>
        /// Occurs when the smarts slider changes
        /// </summary>
        public void SmartsSliderChanged()
        {
            // checks for total theshold, player smarts & neighborhood corruption
            if (SliderSum > totalThreshold 
                || GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Corruption < smartsSlider.value
                || GameManager.Instance.CurrentPlayerObj.Smarts < smartsSlider.value)
            { smartsSlider.value--; }

            // resets player & neighborhood stats
            smartsText.text = GameManager.Instance.CurrentPlayerObj.Smarts.ToString() + Constants.ARROW + (GameManager.Instance.CurrentPlayerObj.Smarts - smartsSlider.value).ToString();
            policeCorrText.text = GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Corruption.ToString() + Constants.ARROW + 
                                  (GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Corruption - smartsSlider.value).ToString();
        }

        /// <summary>
        /// Occurs when the moxie slider changes
        /// </summary>
        public void MoxieSliderChanged()
        {
            // checks the total threshold, player moxie & current neighborhood chaos
            if (SliderSum > totalThreshold 
                || GameManager.Instance.CurrentPlayerObj.Moxie < moxieSlider.value 
                || GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Chaos < moxieSlider.value)
            { moxieSlider.value--; }

            // resets player & neighborhood stats
            moxieText.text = GameManager.Instance.CurrentPlayerObj.Moxie.ToString() + Constants.ARROW + (GameManager.Instance.CurrentPlayerObj.Moxie - moxieSlider.value).ToString();
            chaosText.text = GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Chaos.ToString() + Constants.ARROW + 
                             (GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].Chaos - moxieSlider.value).ToString();
        }

        /// <summary>
        /// Occurs when the muscle slider changes
        /// </summary>
        public void MuscleSliderChanged()
        {
            // checks the total threshold, player strength & current neighborhood mafia presence 
            if (SliderSum > totalThreshold 
                || GameManager.Instance.CurrentPlayerObj.Muscle < muscleSlider.value 
                || GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].MafiaPresence < muscleSlider.value)
            { muscleSlider.value--; }

            // resets player & neighborhood stats
            muscleText.text = GameManager.Instance.CurrentPlayerObj.Muscle.ToString() + Constants.ARROW + (GameManager.Instance.CurrentPlayerObj.Muscle - muscleSlider.value).ToString();
            mafiaPresText.text = GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].MafiaPresence.ToString() + Constants.ARROW + 
                                 (GameLibrary.instance.Neighborhoods[GameManager.Instance.CurrentPlayerObj.Neighborhood].MafiaPresence - muscleSlider.value).ToString();
        }

        /// <summary>
        /// Resets the sliders values
        /// </summary>
        public void ResetButton()
        {
            smartsSlider.value = 0;
            moxieSlider.value = 0;
            muscleSlider.value = 0;
        }

        /// <summary>
        /// Commits the changes made by the player
        /// </summary>
        public void CommitChanges()
        {
            // check the slider threshold
            if (SliderSum <= totalThreshold && SliderSum > 0)
            {
                // lower thr crime
                GameManager.Instance.LowerCrime(smartsSlider.value, moxieSlider.value, muscleSlider.value);
                UIManager.instance.CloseWindows();

                GameManager.Instance.LogAction("Lowered Neighborhood Crime");
                StatTracker.TimesLoweredCrime(1);
            }
        }

        #endregion
    }
}