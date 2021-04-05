using System;
using UnityEngine;
using UnityEngine.UI;

namespace ExtenjectExtra.StateExtension.UI
{
    [RequireComponent(typeof(Image))]
    public class StateOfImage : MonoBehaviour
    {
        [SerializeField] private Image m_image;
        [SerializeField] private bool m_useState;
        [SerializeField] private ImageStateHelper stateHelper;

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
                if (m_image != null && m_useState)
                {
                    stateHelper.StateValue = value;
                    ImageStateHelper.ImageStateItem item = stateHelper.SelectedState;

                    if (item != null)
                    {
                        m_image.color = item.stateObj1;
                        m_image.sprite = item.stateObj2;
                    }
                }
            }
        }


        [Serializable]
        public class ImageStateHelper : AbsStateHelper<ImageStateHelper.ImageStateItem>
        {
            
            [Serializable]
            public class ImageStateItem : StateItem<Color, Sprite>
            {}
        }
        
        
        
    }
}