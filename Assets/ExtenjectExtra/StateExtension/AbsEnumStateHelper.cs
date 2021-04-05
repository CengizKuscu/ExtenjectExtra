using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExtenjectExtra.StateExtension
{
    
    [Serializable]
    public abstract class AbsEnumStateHelper<TEnum>  where TEnum : struct, Enum
    {
        [SerializeField]private TEnum defaultState;
        
        private TEnum _stateValue;

        protected AbsEnumStateHelper()
        {
            _stateValue = defaultState;
        }
        
        public virtual TEnum StateValue
        {
            get => _stateValue;
            set => _stateValue = value;
        }
    }

    [Serializable]
    public abstract class AbsEnumStateHelper<TEnum, TStateItem> where TStateItem : IEnumStateItem<TEnum> where TEnum : struct, Enum
    {
        [SerializeField] protected TEnum defaultStateValue;
        [SerializeField] protected List<TStateItem> stateItems;

        private TEnum _stateValue;
        private TStateItem _selectedState;

        public TStateItem SelectedState
        {
            get => stateItems.FirstOrDefault(s => s.StateValue.Equals(_stateValue));
        }

        protected AbsEnumStateHelper()
        {
            _stateValue = defaultStateValue;
        }

        public virtual TEnum StateValue
        {
            get => _stateValue;
            set => _stateValue = value;
        }
    }
    
    
    
}