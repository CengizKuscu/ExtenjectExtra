using ExtenjectExtra.MenuSystem;

namespace Menus
{
    public class MainMenu : Menu<MenuNames, MainMenu, GameMenuManager>
    {
        
    }

    public class MainMenuArg : MenuArg
    {
        public MainMenuArg(MenuMode mode)
        {
            Mode = mode;
        }
    }
}