using System;
using UnityEngine;

namespace ExtenjectExtra.StateExtension
{
    public interface IStateItem
    {
        int StateValue { get; }
    }
    
    [Serializable]
    public abstract class StateItem : IStateItem
    {
        [SerializeField] private int stateValue;

        public int StateValue => stateValue;
    }

    [Serializable]
    public class StateItem<TState1> : StateItem
    {
        public TState1 stateObj1;
    }

    [Serializable]
    public class StateItem<TState1, TState2> : StateItem<TState1>
    {
        public TState2 stateObj2;
    }
    
    [Serializable]
    public class StateItem<TState1, TState2, TState3> : StateItem<TState1, TState2>
    {
        public TState3 stateObj3;
    }
    
    [Serializable]
    public class StateItem<TState1, TState2, TState3, TState4> : StateItem<TState1, TState2, TState3>
    {
        public TState4 stateObj4;
    }
    
    [Serializable]
    public class StateItem<TState1, TState2, TState3, TState4, TState5> : StateItem<TState1, TState2, TState3, TState4>
    {
        public TState5 stateObj5;
    }
}