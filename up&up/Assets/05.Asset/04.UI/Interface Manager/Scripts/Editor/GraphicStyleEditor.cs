using UnityEditor;
using UnityEngine.UI;
namespace InterfaceThemeManager
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(GraphicStyle))]
    public class GraphicStyleEditor : Editor
    {
        private static readonly string[] _hideTypo = new string[] { "m_Script", "typography", "useColorPalete", "textAnchor" };
        private static readonly string[] _hideScriptField = new string[] { "m_Script" };
        private static readonly string[] _hideGraphic = new string[] { "m_Script", "palette" };
        public override void OnInspectorGUI()
        {
            GraphicStyle targetScript = (GraphicStyle)target;
            // Hidden Script Field
            serializedObject.Update();
            if (targetScript.GetComponent<Graphic>() != null)
            {
                if (targetScript.GetComponent<Text>() != null)
                {
                    if (!targetScript.useColorPalete)
                    {
                        DrawPropertiesExcluding(serializedObject, _hideGraphic);
                    }
                    else
                    {
                        DrawPropertiesExcluding(serializedObject, _hideScriptField);
                    }
                }
                else
                {
                    DrawPropertiesExcluding(serializedObject, _hideTypo);
                }
            }
            else
            {
                EditorGUILayout.HelpBox("This component requires an Image or Text component to work", MessageType.Warning);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}