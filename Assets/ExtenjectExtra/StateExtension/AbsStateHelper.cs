using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExtenjectExtra.StateExtension
{
    [Serializable]
    public abstract class AbsStateHelper<TStateItem> where TStateItem : IStateItem
    {
        [SerializeField] protected int defaultStateValue;
        [SerializeField] protected List<TStateItem> stateItems;

        private int _stateValue;
        private TStateItem _selectedState;

        protected AbsStateHelper()
        {
            _stateValue = defaultStateValue;
        }

        public TStateItem SelectedState => stateItems.FirstOrDefault(s=>s.StateValue == _stateValue);

        public int StateValue
        {
            get => _stateValue;
            set => _stateValue = value;
        }
        
        
    }
}