using System;
using UnityEngine;

namespace ExtenjectExtra.StateExtension
{

    public interface IEnumStateItem<TEnum> where TEnum : struct, Enum
    {
        TEnum StateValue { get; }
    }
    [Serializable]
    public abstract class EnumStateItem<TEnum> : IEnumStateItem<TEnum> where TEnum : struct, Enum
    {
        [SerializeField]private TEnum stateValue;

        public TEnum StateValue => stateValue;
    }
    
    [Serializable]
    public class EnumStateItem<TEnum, TState> : EnumStateItem<TEnum> where TEnum : struct, Enum
    {
        public TState stateObj;
    }

    [Serializable]
    public class EnumStateItem<TEnum, TState1, TState2> : EnumStateItem<TEnum> where TEnum : struct, Enum
    {
        public TState1 stateObj1;
        public TState2 stateObj2;
    }
    
    [Serializable]
    public class EnumStateItem<TEnum, TState1, TState2, TState3> : EnumStateItem<TEnum, TState1, TState2> where TEnum : struct, Enum
    {
        public TState3 stateObj3;
    }
    
    [Serializable]
    public class EnumStateItem<TEnum, TState1, TState2, TState3, TState4> : EnumStateItem<TEnum, TState1, TState2, TState3> where TEnum : struct, Enum
    {
        public TState4 stateObj4;
    }
    
    [Serializable]
    public class EnumStateItem<TEnum, TState1, TState2, TState3, TState4, TState5> : EnumStateItem<TEnum, TState1, TState2, TState3, TState4> where TEnum : struct, Enum
    {
        public TState5 stateObj5;
    }
}