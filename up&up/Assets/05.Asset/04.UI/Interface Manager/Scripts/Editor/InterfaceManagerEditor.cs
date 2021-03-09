using UnityEditor;
namespace InterfaceThemeManager
{
    [CustomEditor(typeof(InterfaceManager))]
    public class InterfaceManagerEditor : Editor
    {
        private static readonly string[] _dontIncludeMe = new string[] { "m_Script" };
        public override void OnInspectorGUI()
        {
            // Hidden Script Field
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject, _dontIncludeMe);
            serializedObject.ApplyModifiedProperties();
        }
    }
}