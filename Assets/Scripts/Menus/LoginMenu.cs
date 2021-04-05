using ExtenjectExtra.MenuSystem;

namespace Menus
{
    public class LoginMenu : Menu<MenuNames, LoginMenu, GameMenuManager>
    {
        public void OnClick_MainMenuBtn()
        {
            menuManager.OpenMenu(MenuNames.Main, new MainMenuArg(MenuMode.Single));
        }
    }

    public class LoginMenuArg : MenuArg
    {
        public LoginMenuArg(MenuMode mode)
        {
            Mode = mode;
        }
    }
}