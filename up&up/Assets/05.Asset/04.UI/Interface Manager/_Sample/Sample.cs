using UnityEngine;
using InterfaceThemeManager;
public class Sample : MonoBehaviour
{
    public void ShowAlert()
    {
        // This code creates an alert message
        InterfaceManager.Instance.dialog.Alert("Hello World", "I'm a Alert box!");
    }
    public void ShowConfirm()
    {
        // This code creates a confirmation message
        InterfaceManager.Instance.dialog.Confirm("Hello World", "Is this extension amazing?", null);
    }
    public void ChangeTheme(Theme theme)
    {
        if (theme && InterfaceManager.Instance)
        {
            InterfaceManager.Instance.currentTheme = theme;
            InterfaceManager.Instance.RefreshTheme();
        }
    }
}