using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExtenjectExtra.MenuSystem
{
    public interface IMenuManager<TEnum> where TEnum : struct, Enum
    {
        Transform MenuContainer { get; }

        Transform PopupContainer { get; }

        void Init();

        void Open(AbsMenu<TEnum> instance, IMenuArg menuArg);

        void OpenMenu(TEnum menuName, IMenuArg arg);

        void CloseMenu(TEnum menuName);
    }
    
    public class AbsMenuManager<TEnum> : MonoBehaviour, IMenuManager<TEnum> where TEnum : struct, Enum
    {
        public Transform menuContainer;
        public Transform popupContainer;
        public GameObject menuLoadingAnim;
        
        protected LinkedList<AbsMenu<TEnum>> menuLinkedList = new LinkedList<AbsMenu<TEnum>>();

        public Transform MenuContainer => menuContainer;
        public Transform PopupContainer => popupContainer;
        
        public virtual void Init()
        {
            menuLoadingAnim.SetActive(false);

            foreach (Transform val in menuContainer.transform)
            {
                val.gameObject.SetActive(false);
            }

            foreach (Transform val in popupContainer.transform)
            {
                val.gameObject.SetActive(false);
            }
        }

        public void Open(AbsMenu<TEnum> instance, IMenuArg menuArg)
        {
            menuLoadingAnim.SetActive(true);

            if (menuArg.Mode == MenuMode.Single)
                CloseOthers(instance);

            if (menuLinkedList.Find(instance) != null)
            {
                menuLoadingAnim.SetActive(false);
                return;
            }

            RectTransform rectTransform = instance.GetComponent<RectTransform>();
            
            if (menuLinkedList.Count == 0)
            {
                menuLinkedList.AddLast(instance);
            }
            else
            {
                menuLinkedList.AddFirst(instance);
            }

            if (rectTransform != null)
                rectTransform.SetAsLastSibling();

            menuLoadingAnim.SetActive(false);
        }

        public virtual void OpenMenu(TEnum menuName, IMenuArg arg)
        {
            throw new NotImplementedException();
        }

        public void CloseMenu(TEnum menuName)
        {
            AbsMenu<TEnum> node = menuLinkedList.FirstOrDefault(s => s.menuName.Equals(menuName));
            
            if (node != null)
            {
                Close(node);
            }
        }
        
        private void CloseOthers(AbsMenu<TEnum> instance)
        {
            if (menuLinkedList.Count == 0)
                return;

            foreach (var menu in menuLinkedList.ToList())
            {
                if (menu != instance)
                {
                    Close(menu);
                }
            }
        }
        
        private void Close(AbsMenu<TEnum> instance)
        {
            if (instance == null) return;
            
            instance.Close();
        }
        
        public void UpdateMenuLinkedList(AbsMenu<TEnum> instance)
        {
            if (menuLinkedList.Count == 0)
            {
                Debug.LogErrorFormat(instance, "{0} cannot be closed because menu linked list is empty",
                    instance.GetType());
                return;
            }

            LinkedListNode<AbsMenu<TEnum>> node = menuLinkedList.Find(instance);
            if (node == null)
            {
                Debug.LogErrorFormat(instance, "{0} cannot be closed because it is not in the linked list",
                    instance.GetType());
                
            }
            else
            {
                //node = node.Previous;
                if (instance.destroyWhenClosed)
                    menuLinkedList.Remove(node);
            }
        }
    }

    public class MenuManager<TEnum, T> : AbsMenuManager<TEnum>
        where T : MenuManager<TEnum, T> where TEnum : struct, Enum
    {
        
    }
}