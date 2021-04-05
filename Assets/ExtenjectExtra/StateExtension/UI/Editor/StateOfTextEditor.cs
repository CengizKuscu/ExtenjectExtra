using UnityEditor;
using UnityEngine.UI;

namespace ExtenjectExtra.StateExtension.UI
{
    [CustomEditor(typeof(StateOfText))]
    public class StateOfTextEditor : Editor
    {
        private SerializedProperty m_textField;
        private SerializedProperty m_useState;
        private SerializedProperty stateHelper;
        
        private void OnEnable()
        {
            m_textField = serializedObject.FindProperty("m_textField");
            m_useState = serializedObject.FindProperty("m_useState");
            stateHelper = serializedObject.FindProperty("stateHelper");
        }

        public override void OnInspectorGUI()
        { 
            base.OnInspectorGUI();
            serializedObject.Update();
            
            StateOfText comp = (StateOfText) target;

            Text txtField = comp.gameObject.GetComponent<Text>();
            m_textField.objectReferenceValue = txtField;

            SerializedProperty defaultIndex = stateHelper.FindPropertyRelative("defaultStateValue");
            
            if (m_useState.boolValue)
            {
                comp.State = defaultIndex.intValue;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}