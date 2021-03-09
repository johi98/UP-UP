using UnityEngine;
using UnityEngine.UI;
using InterfaceThemeManager;
[RequireComponent(typeof(Toggle))]
[DisallowMultipleComponent]
[AddComponentMenu("UI/Extra/Tab")]
public class Tab : MonoBehaviour
{
    public GraphicStyle label;
    public Flyout FlyoutContent;
    private Toggle m_Toggle;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        m_Toggle = GetComponent<Toggle>();
        m_Toggle.onValueChanged.AddListener((value) => onValueChanged(value));
        m_Toggle.onValueChanged.AddListener((value) => FlyoutContent.IsVisible(value));
        onValueChanged(m_Toggle.isOn);
    }
    public void onValueChanged(bool value)
    {
        label.palette = PaletteStyle.Emphasis;
        if (value)
        {
            label.useColorPalete = value;
            label.GetComponent<Text>().color = InterfaceManager.Instance.currentTheme.colorPalette.emphasis;
        }
        else
        {
            label.useColorPalete = false;
            label.GetComponent<Text>().color = InterfaceManager.Instance.currentTheme.label.color;
        }
    }
}