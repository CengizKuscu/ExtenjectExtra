using System;
using UnityEngine;
using UnityEngine.UI;

namespace ExtenjectExtra.StateExtension.UI
{
    [RequireComponent(typeof(Text))]
    public class StateOfText : MonoBehaviour
    {
        [SerializeField] private Text m_textField;

        [SerializeField] private bool m_useState;
        [SerializeField] private TextStateHelper stateHelper;
        
        private int _state;

        private void Awake()
        {
            _state = stateHelper.StateValue;
        }

        public int State
        {
            get => _state;
            set
            {
                _state = value;
                if (m_textField != null && m_useState)
                {
                    stateHelper.StateValue = value;
                    TextStateHelper.TextStateItem item = stateHelper.SelectedState;

                    if (item != null)
                    {
                        m_textField.text = item.stateObj1;
                        m_textField.color = item.stateObj2;
                    }
                }
            }
        }

        [Serializable]
        public class TextStateHelper : AbsStateHelper<TextStateHelper.TextStateItem>
        {
            [Serializable]
            public class TextStateItem : StateItem<string, Color>
            {
            }
        }
    }
}