using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class which handles slider input
/// </summary>
public class SliderInput : MonoBehaviour
{
    #region Fields

    // store the slider
    public Slider slider;

    // store the min and max values
    public float minValue;
    public float maxValue;
    public float value;

    // store the values changes delegates
    public delegate void ValueChanged(float newValue);
    public event ValueChanged OnValueChanged;

    #endregion

    #region Public Methods

    // Use this for initialization
    void Start()
    {
        // initialize the values of the slider
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.value = value;

        // updates the range of the slider
        UpdateRange(minValue, maxValue);
    }

    /// <summary>
    /// Handle the slider changing
    /// </summary>
    /// <param name="newValue">the new value</param>
    public void OnSliderChanged(float newValue)
    {
        // set the value
        value = newValue;

        // check for a value change
        if (OnValueChanged != null)
        { OnValueChanged(value); }
    }

    /// <summary>
    /// Updates the sliders range
    /// </summary>
    /// <param name="newMin">the new min value</param>
    /// <param name="newMax">the new max value</param>
    public void UpdateRange(float newMin, float newMax)
    {
        // set the min and max
        minValue = newMin;
        maxValue = newMax;

        // set the sliders min and max
        slider.minValue = newMin;
        slider.maxValue = newMax;

        // set the Min and Max value text below the slider
        transform.FindChild("MinValue").gameObject.GetComponent<Text>().text = newMin.ToString();
        transform.FindChild("MaxValue").gameObject.GetComponent<Text>().text = newMax.ToString();

        // check for changed value
        OnSliderChanged(value);
    }

    #endregion
}