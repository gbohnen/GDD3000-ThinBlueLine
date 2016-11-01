using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Script which handles timers
    /// </summary>
    public class Timer
    {
        #region Fields

        // store the timer finished event
        TimerFinishedEvent timerFinishedEvent;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets if this timer is running
        /// </summary>
        public bool IsRunning
        { get; set; }

        /// <summary>
        /// Gets or sets the total seconds of the timer
        /// </summary>
        public float TotalSeconds
        { get; set; }

        /// <summary>
        /// Gets or sets the elapsed seconds of the timer
        /// </summary>
        public float ElapsedSeconds
        { get; set; }

        /// <summary>
        /// Gets the amount the timer has run for
        /// </summary>
        public float AmountDone
        { get { return ElapsedSeconds / TotalSeconds; } }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="seconds">the total seconds for the timer</param>
        public Timer(float seconds)
        {
            TotalSeconds = seconds;
            ElapsedSeconds = seconds;
            IsRunning = false;
            timerFinishedEvent = new TimerFinishedEvent();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Updates the timer
        /// </summary>
        public void Update()
        {
            // check if the timer is running
            if (IsRunning)
            {
                // set the elapsed time of the timer
                ElapsedSeconds += Time.deltaTime;

                // if the elapsed seconds are greater or 
                // equal to the total seconds, finish the timer
                if (ElapsedSeconds >= TotalSeconds)
                { FinishTimer(); }
            }
        }

        /// <summary>
        /// Sets the time of the timer
        /// </summary>
        /// <param name="seconds">the total seconds for the timer</param>
        public virtual void SetTimer(float seconds)
        {
            TotalSeconds = seconds;
            ElapsedSeconds = seconds;
        }

        /// <summary>
        /// Starts the timer
        /// </summary>
        public virtual void StartTimer()
        {
            IsRunning = true;
            ElapsedSeconds = 0.0f;
        }

        /// <summary>
        /// Stops the timer
        /// </summary>
        public virtual void StopTimer()
        {
            IsRunning = false;
        }

        /// <summary>
        /// Finishes the timer
        /// </summary>
        public virtual void FinishTimer()
        {
            IsRunning = false;
            timerFinishedEvent.FireEvent();
        }

        #endregion

        #region Event Handling

        /// <summary>
        /// Registers the given event handler
        /// </summary>
        /// <param name="handler">the event handler</param>
        public void Register(TimerFinishedEventHandler handler)
        { timerFinishedEvent.Register(handler); }

        #endregion
    }
}