using System;
using UnityEngine;
using Zenject;

namespace ExtenjectExtra.MenuSystem
{
    public class Menu<TEnum, T, TManager> : AbsMenu<TEnum> 
        where TEnum : struct, Enum
        where T : Menu<TEnum, T, TManager>
        where TManager : MenuManager<TEnum, TManager>
    {
        private TManager _menuManager;
        
        private IMenuArg _menuArg;
        
        protected virtual TManager menuManager => _menuManager;
        public static T Instance { get; private set; }

        [Inject]
        public void Init(TManager menuManager)
        {
            if (string.IsNullOrEmpty(menuName.ToString()))
                throw new Exception("menuName is not defined from " + gameObject.name);
            /*Instance = (T) this;*/
            gameObject.SetActive(false);
            _menuManager = menuManager;
        }

        private void Awake()
        {
            Instance = (T) this;
        }


        public override void Open(IMenuArg e)
        {
            _menuArg = e;
            _menuManager.Open(this, _menuArg);
            gameObject.SetActive(false);
            OnShowBefore(_menuArg);
            gameObject.SetActive(true);
            OnShowAfter(_menuArg);
        }
        
        public override void Close()
        {
            _menuManager.UpdateMenuLinkedList(Instance);
            OnHideBefore();
            gameObject.SetActive(false);
            OnHideAfter();

            if (destroyWhenClosed)
                Destroy(gameObject);
        }

        protected override void OnShowBefore<TMenuArg>(TMenuArg e)
        {
        }

        protected override void OnShowAfter<TMenuArg>(TMenuArg e)
        {
        }

        protected override void OnHideBefore()
        {
        }

        protected override void OnHideAfter()
        {
        }

        public class Factory : PlaceholderFactory<T>
        {
            private DiContainer _container;
            private GameObject _prefab;
            private IMenuManager<TEnum> _menuManager;

            public Factory(DiContainer container, GameObject prefab, IMenuManager<TEnum> menuManager)
            {
                _container = container;
                _prefab = prefab;
                _menuManager = menuManager;
            }

            public override T Create()
            {
                AbsMenu<TEnum> absMenu = _prefab.GetComponent<Menu<TEnum, T, TManager>>();
                Transform menuTransform = !absMenu.isPopup ? _menuManager.MenuContainer : _menuManager.PopupContainer;
                
                if (Instance == null)
                {
                    //AppLog.Info(this, "In customMenuFactory, return new prefab : {0}", _prefab.name);
                    return _container.InstantiatePrefab(_prefab, menuTransform).GetComponent<T>();
                }
                else
                {
                    //AppLog.Info(this,"In CustormMenuFactory, return existing Instance : {0}", Instance.name);
                    return Instance;
                }
            }
            
            public override void Validate()
            {
                GameObject instance = _container.InstantiatePrefab(_prefab);
                instance.GetComponent<T>();
            }
        }
    }
}