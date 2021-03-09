using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(EventTrigger))]
[DisallowMultipleComponent]
[AddComponentMenu("UI/Extra/Slider With Flyout")]
public class SliderWithFlyout : MonoBehaviour
{
    public Flyout flyout;
    public Text valueLabel;
    public bool showPrecentage = false;
    private Slider m_Slider;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        m_Slider = GetComponent<Slider>();
        m_Slider.onValueChanged.AddListener(onValueChanged);
        onValueChanged(m_Slider.value);
        flyout.IsVisible(false);
    }
    /// <summary>
    /// Called when the slider value changed.
    /// </summary>
    void onValueChanged(float value)
    {
        flyout.IsVisible(true);
        if (showPrecentage)
        {
            valueLabel.text = System.Math.Round(value, 2) + "%";
        }
        else
        {
            valueLabel.text = System.Math.Round(value, 2).ToString();
        }
    }
    /// <summary>
    /// Show th flyout with the slider value.
    /// </summary>
    public void SetFlyoutVisible(bool value)
    {
        flyout.IsVisible(value);
    }
}