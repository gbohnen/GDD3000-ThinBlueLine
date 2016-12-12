using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    /// <summary>
    /// Script which handles the situations in the game
    /// </summary>
    public class SituationScript
    {
        #region Fields

        string cardName;
        string description;
        string immEffect;
        string ongEffect;
        float cost;
        float smartsModifier;
        float muscleModifier;
        float moxieModifier;
        string positiveOutcome;
        string negativeOutcome;

		string immEffectMeth;
		string ongEffectMeth;
		string posEffectMeth;
		string negEffectMeth;

        #endregion

        #region Properties

        public string Name
        {
            get { return cardName; }
            set { cardName = value; }
        }

        /// <summary>
        /// Gets the description
        /// </summary>
        public string Description
        {
            get { return description; }
        }

        /// <summary>
        /// Gets the immediate effect
        /// </summary>
        public string ImmediateEffect
        {
            get { return immEffect; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OngoingEffect
        {
            get { return ongEffect; }
        }

        /// <summary>
        /// Gets the costs
        /// </summary>
        public float Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        /// <summary>
        /// Gets the smarts modifier
        /// </summary>
        public float SmartsModifier
        {
            get { return smartsModifier; }
        }

        /// <summary>
        /// Gets the muscle modifier
        /// </summary>
        public float MuscleModifier
        {
            get { return muscleModifier; }
        }

        /// <summary>
        /// Gets the moxie modifier
        /// </summary>
        public float MoxieModifier
        {
            get { return moxieModifier; }
        }

        /// <summary>
        /// Gets the positive outcome
        /// </summary>
        public string PositiveOutcome
        {
            get { return positiveOutcome; }
        }

        /// <summary>
        /// Gets the negative outcome
        /// </summary>
        public string NegativeOutcome
        {
            get { return negativeOutcome; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public SituationScript(LoadGameData.Situation data) 
        {
            cardName = data.name;
            description = data.desc;
            immEffect = data.immEff;
            ongEffect = data.ongEff;

            cost = data.cost;
            smartsModifier = data.smMod;
            muscleModifier = data.musMod;
            moxieModifier = data.moxMod;

            positiveOutcome = data.posOut;
            negativeOutcome = data.negOut;

			immEffectMeth = data.immEffMeth;
			ongEffectMeth = data.ongEffMeth;
			posEffectMeth = data.posEffMeth;
			negEffectMeth = data.negEffMeth;
        }

        #endregion

		#region Methods
		public void TriggerImmediate()
		{
			if (immEffectMeth != null)
				ParseCommand (immEffectMeth);
		}

		public void TriggerOngoing()
		{
			if (ongEffectMeth != null)
				ParseCommand (ongEffectMeth);
		}

		public void TriggerPositive()
		{
			if (posEffectMeth != null)
				ParseCommand (posEffectMeth);
		}

		public void TriggerNegative()
		{
			if (negEffectMeth != null)
				ParseCommand (negEffectMeth);
		}

		private void ParseCommand(string effectString)
		{
			try
            {
                Debug.Log(effectString);

                string[] commands = effectString.Split (new char[] { ';' });

				foreach (string str in commands) 
				{
					string[] command = str.Split (new char[] { ':' });
					MethodInfo method = typeof(CardActions).GetMethod (command [0]);

					if (command.Length > 1)
						method.Invoke (this, new object[]{ Int32.Parse (command [1]) });
					else 
						method.Invoke (this, new object[]{});
				}
			}
			catch (NullReferenceException)
			{
                Debug.Log("Method not found: " + effectString);
			}

            UIManager.instance.UpdateUI();
		}

		#endregion
    }
}