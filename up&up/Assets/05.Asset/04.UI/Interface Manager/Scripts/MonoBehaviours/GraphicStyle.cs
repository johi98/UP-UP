using UnityEngine;
using UnityEngine.UI;
namespace InterfaceThemeManager
{
    [DisallowMultipleComponent]
    [ExecuteInEditMode]
    [AddComponentMenu("UI/Graphic Style", 1)]
    public class GraphicStyle : MonoBehaviour
    {
        [Tooltip("Typography Style.")]
        public TypographyStyle typography;
        [Tooltip("Establishes text alignment.")]
        public TextAnchor textAnchor = TextAnchor.MiddleLeft;
        [Tooltip("Use the color of the palette in the text.")]
        public bool useColorPalete = false;
        [Tooltip("Palettet Style.")]
        public PaletteStyle palette;
        [Tooltip("Opacity of the current color, if Equal to 1f. apply theme opacity palette.")]
        [Range(0f, 1f)]
        public float opacity = 1f;
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            if (FindObjectOfType<InterfaceManager>() == null)
            {
                return;
            }
            FindObjectOfType<InterfaceManager>().RefreshTheme();
        }
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        void OnEnable()
        {
            if (FindObjectOfType<InterfaceManager>() == null)
            {
                return;
            }
            FindObjectOfType<InterfaceManager>().RefreshTheme();
        }
        /// <summary>
        /// This function is called when the behaviour becomes disabled or inactive.
        /// </summary>
        void OnDisable()
        {
            if (FindObjectOfType<InterfaceManager>() == null)
            {
                return;
            }
            FindObjectOfType<InterfaceManager>().RefreshTheme();
        }
        /// <summary>
        /// Called when the script is loaded or a value is changed in the
        /// inspector (Called in the editor only).
        /// </summary>
        void OnValidate()
        {
            if (FindObjectOfType<InterfaceManager>() == null)
            {
                return;
            }
            FindObjectOfType<InterfaceManager>().RefreshTheme();
        }
        /// <summary>
        /// Get the Graphic component and set the color palette style.
        /// </summary>
        public void SetPalette(Color color)
        {
            if (GetComponent<Graphic>() != null)
            {
                if (opacity != 1f)
                {
                    GetComponent<Graphic>().color = new Vector4(color.r, color.g, color.b, opacity);
                }
                else
                {
                    GetComponent<Graphic>().color = color;
                }
            }
        }
        /// <summary>
        /// Get the Text component and set the typography style.
        /// </summary>
        public void SetTypography(Typography typography)
        {
            if (GetComponent<Text>() != null)
            {
                GetComponent<Text>().font = typography.font;
                GetComponent<Text>().fontSize = typography.fontSize;
                GetComponent<Text>().lineSpacing = typography.lineSpacing;
                GetComponent<Text>().material = typography.material;
                if (!useColorPalete)
                {
                    GetComponent<Text>().color = typography.color;
                }
                GetComponent<Text>().alignment = textAnchor;
            }
        }
    }
    public enum PaletteStyle { Emphasis, Background, Fill, Outline, Flyout }
    public enum TypographyStyle { Header, Subheader, Regular, Label, placeholder }
}