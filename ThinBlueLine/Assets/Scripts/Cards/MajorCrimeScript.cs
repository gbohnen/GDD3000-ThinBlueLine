using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class MajorCrimeTier
    {
        public string TierName;
        public string TierDescription;
        public string CrimeEffectText;
        public string CrimeEffectMethod;
        public string OptionOneText;
        public string OptionOneResult;
        public Vector3 OptionOneCosts;
        public string OptionOneMethod;
        public string OptionTwoText;
        public string OptionTwoResult;
        public Vector3 OptionTwoCosts;
        public string OptionTwoMethod;
    }

    /// <summary>
    /// Script which handles the major crime
    /// </summary>
    public class MajorCrimeScript : CardScript
    {
        #region Fields

        string crimeName;
        string mobBoss;
        List<MajorCrimeTier> tiers;
        public int currentTier;

        #endregion

        #region Properties

        public List<MajorCrimeTier> CrimeTiers
        {
            get { return tiers; }
            set { tiers = value; }
        }

        public int CurrentTier
        {
            get { return currentTier; }
            set { currentTier = value; }
        }

        public string Name
        {
            get { return crimeName; }
            set { crimeName = value; }
        }

        public string MobBoss
        {
            get { return mobBoss; }
            set { mobBoss = value; }
        }
        
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MajorCrimeScript()
        {
            tiers = new List<MajorCrimeTier>(); 
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Triggers a negative outcome
        /// </summary>
        public void TriggerTierEffect(int i)
        {

        }

        #endregion
    }
}