using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Toggle))]
[RequireComponent(typeof(Animator))]
[DisallowMultipleComponent]
[AddComponentMenu("UI/Extra/Radio button")]
public class RadioButton : MonoBehaviour
{
    private Toggle m_Toggle;
    private Animator m_Animator;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        m_Toggle = GetComponent<Toggle>();
        m_Animator = GetComponent<Animator>();
        m_Toggle.onValueChanged.AddListener((value) => onValueChanged(value));
        onValueChanged(m_Toggle.isOn);
    }
    void onValueChanged(bool value)
    {
        m_Animator.SetBool("Show", value);
    }
}