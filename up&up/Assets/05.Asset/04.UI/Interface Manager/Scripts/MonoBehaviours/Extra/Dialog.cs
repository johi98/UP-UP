using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
[RequireComponent(typeof(CanvasGroup))]
[DisallowMultipleComponent]
[AddComponentMenu("UI/Extra/Dialog Box")]
public class Dialog : MonoBehaviour
{
    public bool isOpen = false;
    [Header("Text")]
    public Text titleText;
    public Text contentText;
    public Text confirmButtonText;
    [Header("Button")]
    public Button okButton;
    public Button confirmButton;
    public Button backButton;
    // Events
    public UnityEvent onOpen;
    public UnityEvent onClose;
    // Components
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
        Hide();
    }
    /// <summary>
    /// Create a popup with a message and an Ok button with UnityAction
    /// <param name="okAction">Default is null.</param><para/>
    /// </summary>
    public void Alert(string tittle, string message, UnityAction okAction = null)
    {
        if (!isOpen)
        {
            Show();
            titleText.text = tittle;
            contentText.text = message;
            okButton.gameObject.SetActive(true);
            confirmButton.gameObject.SetActive(false);
            backButton.gameObject.SetActive(false);
            if (okAction != null)
            {
                okButton.onClick.AddListener(() => okAction());
            }
            //Add Close to okButton
            okButton.onClick.AddListener(() => CloseAction());
        }
    }
    /// <summary>
    /// Create a confirm box popup to verify or accept something.
    /// <param name="textButton">Default is "Agree".</param><para/>
    /// </summary>
    public void Confirm(string tittle, string message, UnityAction acceptAction, string textButton = "Agree")
    {
        if (!isOpen)
        {
            Show();
            titleText.text = tittle;
            contentText.text = message;
            if (textButton == "Agree")
            {
                confirmButtonText.text = "Agree";
            }
            else
            {
                confirmButtonText.text = textButton;
            }
            // Switch Buttons
            okButton.gameObject.SetActive(false);
            confirmButton.gameObject.SetActive(true);
            backButton.gameObject.SetActive(true);
            // Set Action
            if (acceptAction != null)
            {
                confirmButton.onClick.AddListener(() => acceptAction());
            }
            confirmButton.onClick.AddListener(() => CloseAction());
            backButton.onClick.AddListener(() => CloseAction());
        }
    }
    //----------------------------------------------------------------------------------------------------
    private void Show()
    {
        isOpen = true;
        m_Animator.SetBool("Show", isOpen);
        onOpen.Invoke();
    }
    private void Hide()
    {
        isOpen = false;
        m_Animator.SetBool("Show", isOpen);
        onClose.Invoke();
    }
    private void CloseAction()
    {
        EventSystem.current.SetSelectedGameObject(null);
        okButton.onClick.RemoveAllListeners();
        confirmButton.onClick.RemoveAllListeners();
        backButton.onClick.RemoveAllListeners();
        Hide();
    }
}