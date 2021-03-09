using UnityEngine;
using UnityEngine.UI;
using InterfaceThemeManager;
[CreateAssetMenu(fileName = "New Theme", order = 100, menuName = "UI Theme")]
[ExecuteInEditMode]
public class Theme : ScriptableObject
{
    [Header("Color Palette")]
    public ColorPalette colorPalette;
    [Header("Typography Style")]
    public Typography header;
    public Typography subheader;
    public Typography regular;
    public Typography label;
    public Typography placeholder;
    [Header("Sounds Profile")]
    public SoundProfile sounds;
    void OnValidate()
    {
        if (FindObjectOfType<InterfaceManager>() == null)
        {
            return;
        }
        FindObjectOfType<InterfaceManager>().RefreshTheme();
    }
}
[System.Serializable]
public struct ColorPalette
{
    public Color emphasis;
    [Space]
    public Color background;
    public Color flyout;
    [Space]
    public Color fill;
    public Color outline;
    public Color highlighted;
    [Header("Selectable Colors")]
    public ColorBlock colorBlock;
}
[System.Serializable]
public struct Typography
{
    public Font font;
    public int fontSize;
    public float lineSpacing;
    public Color color;
    public Material material;
}
[System.Serializable]
public struct SoundProfile
{
    public AudioClip clip;
    public AudioClip agree;
    public AudioClip cancel;
    public AudioClip dialog;
}