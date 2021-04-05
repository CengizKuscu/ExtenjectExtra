using UnityEditor;
using UnityEngine.UI;

namespace ExtenjectExtra.StateExtension.UI
{
    [CustomEditor(typeof(StateOfImage))]
    public class StateOfImageEditor : Editor
    {
        private SerializedProperty m_image;
        private SerializedProperty m_useState;
        private SerializedProperty stateHelper;

        private void OnEnable()
        {
            m_image = serializedObject.FindProperty("m_image");
            m_useState = serializedObject.FindProperty("m_useState");
            stateHelper = serializedObject.FindProperty("stateHelper");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();

            StateOfImage comp = (StateOfImage) target;

            Image img = comp.GetComponent<Image>();
            m_image.objectReferenceValue = img;

            SerializedProperty defaultIndex = stateHelper.FindPropertyRelative("defaultStateValue");

            if (m_useState.boolValue)
            {
                comp.State = defaultIndex.intValue;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}