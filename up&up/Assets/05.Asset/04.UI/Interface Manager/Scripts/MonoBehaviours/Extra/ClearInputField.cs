using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(InputField))]
[AddComponentMenu("UI/Extra/Clear InputField")]
public class ClearInputField : MonoBehaviour
{
    public Button clearButton;
    private InputField m_InputField;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        m_InputField = GetComponent<InputField>();
        if (clearButton != null)
        {
            clearButton.onClick.AddListener(() => ClearText());
        }
    }
    void ClearText()
    {
        m_InputField.text = "";
    }
}
