using StupidTemplate.Classes;
using StupidTemplate.Menu;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;

namespace StupidTemplate.Mods
{
    internal class SettingsMods
    {
        public static void Settings()
        {
            buttonsType = 1;
        }
        public static void Room()
        {
            buttonsType = 2;
        }
        public static void Movement()
        {
            buttonsType = 3;
        }
        public static void Visual()
        {
            buttonsType = 4;
        }
        public static void Rig()
        {
            buttonsType = 5;
        }
        public static void Fun()
        {
            buttonsType = 6;
        }
        public static void Tag()
        {
            buttonsType = 7;
        }

        public static void Testing()
        {
            buttonsType = 8;
        }
        public static void RightHand()
        {
            rightHanded = true;
        }

        public static void LeftHand()
        {
            rightHanded = false;
        }

        public static void EnableFPSCounter()
        {
            fpsCounter = true;
        }

        public static void DisableFPSCounter()
        {
            fpsCounter = false;
        }

        public static void EnableNotifications()
        {
            disableNotifications = false;
        }

        public static void DisableNotifications()
        {
            disableNotifications = true;
        }

        public static void EnableDisconnectButton()
        {
            disconnectButton = true;
        }

        public static void DisableDisconnectButton()
        {
            disconnectButton = false;
        }

        public static void EnableHomeButton()
        {
            homeButton = true;
        }

        public static void DisableHomeButton()
        {
            homeButton = false;
        }

        public static void EnablePanicButton()
        {
            PanicButton = true;
        }

        public static void DisablePanicButton()
        {
            PanicButton = false;
        }
    }
}
