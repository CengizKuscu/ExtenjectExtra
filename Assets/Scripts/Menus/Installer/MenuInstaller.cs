using System.Collections.Generic;
using ExtenjectExtra.MenuSystem;
using ExtenjectExtra.MenuSystem.Installer;
using UnityEngine;

namespace Menus.Installer
{
    [CreateAssetMenu(fileName = "MenuPrefabInstaller", menuName = "Installers/MenuPrefabInstaller")]
    public class MenuInstaller : MenuPrefabsInstaller<MenuInstaller>
    {
        public List<AbsMenu<MenuNames>> menus;

        public override void InstallBindings()
        {
            Container.BindInstance(menus);
            
            menus.ForEach(s =>
            {
                switch (s.menuName)
                {
                    case MenuNames.Main:
                        Container.Bind<GameObject>().FromInstance(s.gameObject)
                            .WhenInjectedInto<MainMenu.Factory>();
                        Container.BindFactory<MainMenu, MainMenu.Factory>().FromFactory<MainMenu.Factory>();
                        break;
                    case MenuNames.Login:
                        Container.Bind<GameObject>().FromInstance(s.gameObject)
                            .WhenInjectedInto<LoginMenu.Factory>();
                        Container.BindFactory<LoginMenu, LoginMenu.Factory>().FromFactory<LoginMenu.Factory>();
                        break;
                }
            });
        }
    }
}