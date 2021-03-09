using UnityEngine;
using UnityEngine.UI;
namespace InterfaceThemeManager
{
    [DisallowMultipleComponent]
    [ExecuteInEditMode]
    [AddComponentMenu("UI/Interface Manager", 0)]
    public class InterfaceManager : MonoBehaviour
    {
        // Instance this Script to globally used
        public static InterfaceManager Instance;
        [Tooltip("Current theme used.")]
        public Theme currentTheme;
        [Tooltip("Dialog")]
        public Dialog dialog;
        public AudioSource UIAudioSource;
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            if (FindObjectsOfType<InterfaceManager>().Length > 1)
            {
                Debug.Log("Only One InterfaceManager by Scene");
                DestroyImmediate(GetComponent<InterfaceManager>());
                return;
            }
            if (Instance == null)
            {
                Instance = this;
                if (Application.isPlaying)
                {
                    DontDestroyOnLoad(this.gameObject);
                }
            }
            if (Instance != this) DestroyImmediate(this.gameObject);
        }
        /// <summary>
        /// Refresh all UI GraphicStyle in scene when this loaded or a value 
        /// is changed in the inspector (Called in the editor only).
        /// </summary>
        void OnValidate()
        {
            if (currentTheme != null)
            {
                RefreshTheme();
            }
        }
        /// <summary>
        /// Applies the changes to all elements of the interface present in the scene.
        /// </summary>
        public void RefreshTheme()
        {
            foreach (var item in FindObjectsOfType<Selectable>())
            {
                item.colors = currentTheme.colorPalette.colorBlock;
            }
            foreach (var item in FindObjectsOfType<InputField>())
            {
                item.selectionColor = currentTheme.colorPalette.emphasis;
            }
            foreach (var item in FindObjectsOfType<GraphicStyle>())
            {
                switch (item.palette)
                {
                    case PaletteStyle.Emphasis:
                        item.SetPalette(currentTheme.colorPalette.emphasis);
                        if (item.GetComponent<Text>() == null)
                        {
                            item.name = "Emphasis";
                        }
                        break;
                    case PaletteStyle.Background:
                        item.SetPalette(currentTheme.colorPalette.background);
                        if (item.GetComponent<Text>() == null)
                        {
                            item.name = "Background";
                        }
                        break;
                    case PaletteStyle.Fill:
                        item.SetPalette(currentTheme.colorPalette.fill);
                        if (item.GetComponent<Text>() == null)
                        {
                            item.name = "Fill";
                        }
                        break;
                    case PaletteStyle.Outline:
                        item.SetPalette(currentTheme.colorPalette.outline);
                        if (item.GetComponent<Text>() == null)
                        {
                            item.name = "Outline";
                        }
                        break;
                    case PaletteStyle.Flyout:
                        item.SetPalette(currentTheme.colorPalette.flyout);
                        if (item.GetComponent<Text>() == null)
                        {
                            item.name = "Flyout";
                        }
                        break;
                }
                switch (item.typography)
                {
                    case TypographyStyle.Header:
                        item.SetTypography(currentTheme.header);
                        if (item.GetComponent<Text>() != null)
                        {
                            item.name = "Header";
                        }
                        break;
                    case TypographyStyle.Subheader:
                        item.SetTypography(currentTheme.subheader);
                        if (item.GetComponent<Text>() != null)
                        {
                            item.name = "Subheader";
                        }
                        break;
                    case TypographyStyle.Regular:
                        item.SetTypography(currentTheme.regular);
                        if (item.GetComponent<Text>() != null)
                        {
                            item.name = "Regular";
                        }
                        break;
                    case TypographyStyle.Label:
                        item.SetTypography(currentTheme.label);
                        if (item.GetComponent<Text>() != null)
                        {
                            item.name = "Label";
                        }
                        break;
                    case TypographyStyle.placeholder:
                        item.SetTypography(currentTheme.placeholder);
                        if (item.GetComponent<Text>() != null)
                        {
                            item.name = "Placeholder";
                        }
                        break;
                }
            }
        }
        public void PlayClip(Sound style)
        {
            switch (style)
            {
                case Sound.Clip:
                    UIAudioSource.PlayOneShot(currentTheme.sounds.clip);
                    break;
                case Sound.Agree:
                    UIAudioSource.PlayOneShot(currentTheme.sounds.agree);
                    break;
                case Sound.Cancel:
                    UIAudioSource.PlayOneShot(currentTheme.sounds.cancel);
                    break;
            }
        }
        public void PlayDialogOpen()
        {
            UIAudioSource.PlayOneShot(currentTheme.sounds.dialog);
        }
    }
}