using System;
using ExtenjectExtra.StateExtension;
using UnityEngine;

namespace ExtenjectExtra
{
    public class TestObj : MonoBehaviour
    {
        [SerializeField] private GameModeEnumStateHelper intEnumStatesHelper;
    }

    public enum GameMode
    {
        None,
        Play,
        Stop,
        Pause
    }

    
    [Serializable]
    public class GameModeEnumStateHelper : AbsEnumStateHelper<GameMode, GameModeEnumStateFactor>{}
    
    [Serializable]
    public class GameModeEnumStateFactor : EnumStateItem<GameMode, Sprite, string, int, GameObject>{}
    
}