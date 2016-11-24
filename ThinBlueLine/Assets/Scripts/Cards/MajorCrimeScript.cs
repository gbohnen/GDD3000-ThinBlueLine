using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public struct MajorCrimeTier
    {
        public string CrimeEffectText;
        public string CrimeEffectMethod;
        public string OptionOneText;
        public Vector3 OptionOneCosts;
        public string OptionTwoText;
        public Vector3 OptionTwoCosts;
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

        #endregion

        #region Properties

        public List<MajorCrimeTier> CrimeTiers
        {
            get { return tiers; }
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