using ExtenjectExtra.MenuSystem;

namespace Menus
{
    public class PopupArg : IMenuArg
    {
        public MenuMode Mode { get;}

        public PopupArg()
        {
            Mode = MenuMode.Additive;
        }
    }
}