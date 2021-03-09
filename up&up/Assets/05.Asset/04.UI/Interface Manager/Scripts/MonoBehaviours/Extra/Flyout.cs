using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CanvasGroup))]
[DisallowMultipleComponent]
[AddComponentMenu("UI/Extra/Flyout Panel")]
public class Flyout : MonoBehaviour
{
    public bool isOpen = false;
    //---------------------------------------------
    public UnityEvent onOpen;
    public UnityEvent onClose;
    public OnValueChanged onValueChanged;
    private Animator m_Animator;
    private CanvasGroup m_CanvasGroup;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_CanvasGroup = GetComponent<CanvasGroup>();
        m_CanvasGroup.interactable = false;
        m_CanvasGroup.blocksRaycasts = false;
        IsVisible(isOpen);
    }
    /// <summary>
    /// Show this Flyout and set interactable blocksRaycasts true
    /// </summary>
    public void IsVisible(bool value)
    {
        onValueChanged.Invoke(value);
        isOpen = value;
        if (value)
        {
            onOpen.Invoke();
        }
        else
        {
            onClose.Invoke();
        }
        m_Animator.SetBool("Show", isOpen);
    }
    [System.Serializable]
    public class OnValueChanged : UnityEvent<bool>
    {
    }
}