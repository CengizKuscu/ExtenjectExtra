using System.Linq;
using ExtenjectExtra.MenuSystem;
using Zenject;

namespace Menus
{
    public class GameMenuManager : MenuManager<MenuNames, GameMenuManager>
    {
        [Inject] private MainMenu.Factory _mainMenuFactory;
        [Inject] private LoginMenu.Factory _loginMenuFactory;
        
        [Inject]
        public void Construct()
        {
            Init();
        }

        public override void Init()
        {
            OpenMenu(MenuNames.Login, new LoginMenuArg(MenuMode.Single));
        }
        
        public override void OpenMenu(MenuNames menuName, IMenuArg arg)
        {
            AbsMenu<MenuNames> absMenu = menuLinkedList.FirstOrDefault(s => s.menuName == menuName);
            if (absMenu != null)
            {
                if (!absMenu.gameObject.activeSelf)
                {
                    absMenu.Open(arg);
                }
                else
                {
                    absMenu.Open(arg);
                }

                return;
            }

            switch (menuName)
            {
                case MenuNames.Main:
                    _mainMenuFactory.Create().Open(arg);
                    break;
                case MenuNames.Login:
                    _loginMenuFactory.Create().Open(arg);
                    break;
            }
        }
    }
}