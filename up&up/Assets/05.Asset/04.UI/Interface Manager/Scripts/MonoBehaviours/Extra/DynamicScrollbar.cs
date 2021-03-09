using UnityEngine;
[RequireComponent(typeof(Animator))]
[DisallowMultipleComponent]
[AddComponentMenu("UI/Extra/Dynamic Scrollbar")]
public class DynamicScrollbar : MonoBehaviour
{
    private Animator m_Animator;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }
    public void Show()
    {
        m_Animator.SetBool("Show", true);
    }
    public void Hide()
    {
        m_Animator.SetBool("Show", false);
    }
}