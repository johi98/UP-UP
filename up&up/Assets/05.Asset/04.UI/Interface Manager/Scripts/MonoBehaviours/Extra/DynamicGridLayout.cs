using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
[DisallowMultipleComponent]
[AddComponentMenu("UI/Extra/Dynamic Grid Layout")]
public class DynamicGridLayout : MonoBehaviour
{
    public bool gridMode = true;
    public Button viewButton;
    public Image viewIcon;
    public GridLayoutGroup gridLayout;
    [Header("Grid View Settings")]
    public Vector2 gridSize;
    public Vector2 gridSpacing;
    public Sprite gridIcon;
    [Header("List View Settings")]
    public Vector2 listSize;
    public Vector2 listSpacing;
    public Sprite listIcon;
    public OnValueChanged onValueChanged;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        viewButton.onClick.AddListener(() => ToggleView());
    }
    void ToggleView()
    {
        gridMode = !gridMode;
        onValueChanged.Invoke(gridMode);
        if (gridMode)
        {
            gridLayout.cellSize = gridSize;
            gridLayout.spacing = gridSpacing;
            viewIcon.sprite = gridIcon;
        }
        else
        {
            gridLayout.cellSize = listSize;
            gridLayout.spacing = listSpacing;
            viewIcon.sprite = listIcon;
        }
    }
    [System.Serializable]
    public class OnValueChanged : UnityEvent<bool>
    {
    }
}