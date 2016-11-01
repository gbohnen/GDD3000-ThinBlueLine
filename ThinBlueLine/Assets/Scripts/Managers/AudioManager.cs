using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Script which handles the audio
    /// </summary>
    public class AudioManager
    {
        #region Fields

        // store the audio clips
        //AudioClip audioClips;

        // store the audio mixers
        AudioMixer backgroundAudioMixer;
        AudioMixer uiAudioMixer;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets if currently in game
        /// </summary>
        public bool InGame
        { get; private set; }

        /// <summary>
        /// Gets or sets the Background Audio Source
        /// </summary>
        public AudioSource BackgroundSource
        { get; private set; }

        /// <summary>
        /// Gets or sets the UI Audio Source
        /// </summary>
        public AudioSource UISource
        { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public AudioManager()
        { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Plays the given sound
        /// </summary>
        public void PlaySound()
        { }

        /// <summary>
        /// Sets the current volume
        /// </summary>
        public void SetVolume()
        { }

        /// <summary>
        /// Gets the current volume
        /// </summary>
        public void GetVolume()
        { }

        #endregion
    }
}