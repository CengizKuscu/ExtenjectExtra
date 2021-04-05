using System;
using UnityEngine;

namespace ExtenjectExtra.MenuSystem
{
    public interface IMenu<TEnum> where TEnum : struct, Enum
    {
        TEnum menuName { get; }
    }
    
    public enum MenuMode
    {
        Single,
        Additive
    }

    public interface IMenuArg
    {
        MenuMode Mode { get; }
    }
    
    public abstract class AbsMenu<TEnum> : MonoBehaviour, IMenu<TEnum> where TEnum : struct,Enum
    {
        [Tooltip("Menu Name"), SerializeField] private TEnum _menuName;
        
        [Tooltip("Destroy the Game Object when menu is closed(reduced memory usage")]
        public bool destroyWhenClosed = false;

        [Tooltip("Defines it as an popup menu.")]
        public bool isPopup = false;

        public TEnum menuName => _menuName;

        protected abstract void OnShowBefore<T>(T e) where T : IMenuArg;
        
        protected abstract void OnShowAfter<T>(T e) where T : IMenuArg;

        protected abstract void OnHideBefore();
        protected abstract void OnHideAfter();
        public abstract void Close();

        public virtual void Open(IMenuArg arg)
        {
        }
    }
}