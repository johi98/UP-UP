using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
namespace InterfaceThemeManager
{
    [InitializeOnLoad]
    public class TemplateMenu : MonoBehaviour
    {
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Typography/Header", false, 2)]
        static void Header()
        {
            CreateText(TypographyStyle.Header, "Header", 256, 32, "Header");
        }
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Typography/Subheader", false, 2)]
        static void Subheader()
        {
            CreateText(TypographyStyle.Subheader, "Subheader", 256, 32, "Subheader");
        }
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Typography/Regular", false, 2)]
        static void Regular()
        {
            CreateText(TypographyStyle.Regular, "Regular text", 256, 128, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris");
        }
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Typography/Label", false, 2)]
        static void Label()
        {
            CreateText(TypographyStyle.Label, "Label", 128, 24, "Label");
        }
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Button/Button Rectangle", false, 100)]
        static void Button()
        {
            InstantiatePrefab("Template/Button Rectangle");
        }
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Button/Button Rounded", false, 100)]
        static void ButtonRounded()
        {
            InstantiatePrefab("Template/Button Rounded");
        }
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Button/Button Flat", false, 100)]
        static void ButtonFlat()
        {
            InstantiatePrefab("Template/Button Flat");
        }
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Selection/CheckBox Rectangle", false, 100)]
        static void Checkbox()
        {
            InstantiatePrefab("Template/Checkbox Rectangle");
        }
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Selection/Checkbox Circle", false, 100)]
        static void CheckboxCircle()
        {
            InstantiatePrefab("Template/Checkbox Circle");
        }
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Selection/Radio Group", false, 100)]
        static void RadioGroup()
        {
            InstantiatePrefab("Template/Radio Group");
        }
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Selection/Toggle Button", false, 100)]
        static void ToggleButton()
        {
            InstantiatePrefab("Template/Toggle Button");
        }
        [MenuItem("UI Template/Selection/Slider", false, 100)]
        static void Slider()
        {
            InstantiatePrefab("Template/Slider");
        }
        [MenuItem("UI Template/Selection/Scroll Bar", false, 100)]
        static void ScrollBar()
        {
            InstantiatePrefab("Template/Scroll Bar");
        }
        [MenuItem("UI Template/Selection/Progress Bar", false, 100)]
        static void ProgressBar()
        {
            InstantiatePrefab("Template/Progress Bar");
        }
        [MenuItem("UI Template/Selection/Dropdown", false, 100)]
        static void Dropdown()
        {
            InstantiatePrefab("Template/Dropdown");
        }
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Text/Input Field", false, 100)]
        static void InputfieldLine()
        {
            InstantiatePrefab("Template/InputField");
        }
        [MenuItem("UI Template/Text/Text Box", false, 100)]
        static void TextBlock()
        {
            InstantiatePrefab("Template/TextBox");
        }
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Flyout/Scroll View", false, 100)]
        static void ScrollView()
        {
            InstantiatePrefab("Template/Scroll View");
        }
        [MenuItem("UI Template/Flyout/Flyout Panel", false, 100)]
        static void FlyoutPanel()
        {
            InstantiatePrefab("Template/Flyout Panel");
        }
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Layout/Background", false, 100)]
        static void Background()
        {
            InstantiatePrefab("Template/Background");
        }
        [MenuItem("UI Template/Layout/Sidenav Layout", false, 100)]
        static void SidenavLayout()
        {
            InstantiatePrefab("Template/Sidenav Layout");
        }
        [MenuItem("UI Template/Layout/Dynamic Grid Layout Group", false, 100)]
        static void GridLayout()
        {
            InstantiatePrefab("Template/Dynamic Grid Layout Group");
        }
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        [MenuItem("UI Template/Interface Manager", false, 1000)]
        static void CreateIM()
        {
            if (FindObjectOfType<InterfaceManager>() == null)
            {
                GameObject m_object;
                m_object = UnityEditor.PrefabUtility.InstantiatePrefab(Resources.Load("Template/Interface Manager", typeof(GameObject))) as GameObject;
                m_object.name = Resources.Load("Template/Interface Manager", typeof(GameObject)).name;
            }
            else
            {
                Debug.Log("Only One InterfaceManager by Scene");
            }
        }
        //-------------------------------------------------------------------------
        static void CreateFirstCanvas()
        {
            if (FindObjectOfType<Canvas>() == null && FindObjectOfType<Canvas>().name != "Dialog Canvas")
            {
                GameObject m_object;
                m_object = UnityEditor.PrefabUtility.InstantiatePrefab(Resources.Load("Template/Canvas", typeof(GameObject))) as GameObject;
                m_object.name = Resources.Load("Template/Canvas", typeof(GameObject)).name;
            }
        }
        private static void InstantiatePrefab(string resourcesPatch)
        {
            if (FindObjectOfType<InterfaceManager>() == null)
            {
                CreateIM();
            }
            CreateFirstCanvas();
            GameObject m_object;
            m_object = UnityEditor.PrefabUtility.InstantiatePrefab(Resources.Load(resourcesPatch, typeof(GameObject))) as GameObject;
            m_object.layer = 5;
            m_object.name = Resources.Load(resourcesPatch, typeof(GameObject)).name;
            if (MonoBehaviour.FindObjectOfType<Canvas>() == null)
            {
            }
            m_object.transform.SetParent(MonoBehaviour.FindObjectOfType<Canvas>().transform);
            m_object.transform.localScale = new Vector3(1, 1, 1);
            m_object.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            m_object.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            GameObject m_sizeOrigin;
            m_sizeOrigin = Resources.Load(resourcesPatch, typeof(GameObject)) as GameObject;
            m_object.GetComponent<RectTransform>().sizeDelta = m_sizeOrigin.GetComponent<RectTransform>().sizeDelta;
        }
        static void CreateText(TypographyStyle style, string name, int with, int height, string content)
        {
            if (FindObjectOfType<InterfaceManager>() == null)
            {
                CreateIM();
            }
            CreateFirstCanvas();
            GameObject m_newTextType;
            m_newTextType = new GameObject(name, typeof(RectTransform));
            m_newTextType.layer = 5;
            m_newTextType.transform.SetParent(MonoBehaviour.FindObjectOfType<Canvas>().transform);
            m_newTextType.transform.localScale = new Vector3(1, 1, 1);
            m_newTextType.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            m_newTextType.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            m_newTextType.GetComponent<RectTransform>().sizeDelta = new Vector2(with, height);
            m_newTextType.AddComponent<Text>();
            m_newTextType.GetComponent<Text>().text = content;
            m_newTextType.GetComponent<Text>().supportRichText = false;
            m_newTextType.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
            m_newTextType.AddComponent<GraphicStyle>();
            m_newTextType.GetComponent<GraphicStyle>().typography = style;
        }
    }
}