using StupidTemplate.Classes;
using StupidTemplate.Menu;
using StupidTemplate.Mods;
using UnityEngine;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate
{
    internal class Settings
    {
        public static ExtGradient backgroundColor = new ExtGradient{isRainbow = false};
        public static ExtGradient[] buttonColors = new ExtGradient[]
        {
            new ExtGradient{colors = GetSolidGradient(Color.black) }, // Disabled
            new ExtGradient{colors = GetSolidGradient(Color.red)} // Enabled
        };
        public static Color[] textColors = new Color[]
        {
            Color.white, // Disabled
            Color.white // Enabled
        };

        public static Font currentFont = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);

        public static bool fpsCounter = false;
        public static bool disconnectButton = true;
        public static bool homeButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = true;
        public static bool PanicButton = true;

        public static bool MenuPhysics = true;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 0.8f, 1f); // Depth, Width, Height 0.1f, 1f, 1f
        public static int buttonsPerPage = 8;

        private static int theme = 0;
        private static int flyspeed = 0;

        static Vector3 Vector;
        public static void NoFallinMenu()
        {
            if (menu != null)
            {
                if (Vector == Vector3.zero)
                {
                    Vector = GorillaTagger.Instance.rigidbody.transform.position;
                }
                else
                {
                    GorillaTagger.Instance.rigidbody.transform.position = Vector;
                }
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else
            {
                Vector = Vector3.zero;
            }
        }
        public static void ChangeTheme()
        {
            string[] themes =
            {
                "Default",
                "Red",
                "Green",
                "RGB",
                "MonkeyColor",
                "Blue",
                "Magenta",
            };

            if (themes.Length > 0)
            {
                theme++;
                if (theme >= themes.Length) 
                {
                    theme = 0;
                }
                switch (theme)
                {
                    case 0: // Default
                        backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.cyan) };
                        break;
                    case 1: // Red
                        backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.red) };
                        break;
                    case 2: // Green
                        backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.green) };
                        break;
                    case 3: // RGB
                        backgroundColor = new ExtGradient { isRainbow = true };
                        break;
                    case 4: // MonkeyColor
                        backgroundColor = new ExtGradient { copyRigColors = true };
                        break;
                    case 5: // Blue
                        backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.blue) };
                        break;
                    case 6: // Magenta
                        backgroundColor = new ExtGradient { colors = GetSolidGradient(Color.magenta) };
                        break;
                }
            }

            Main.GetIndex("ChangeMenuTheme").overlapText = "Theme: " + themes[theme];
        }

        public static void EnablePhysicMenu()
        {
            MenuPhysics = true;
        }
        public static void DisablePhysicMenu()
        {
            MenuPhysics = false;
        }

        public static float FlySpeed = 0.2f;
        public static void ChangeFlySpeed()
        {
            string[] flyspeeds =
            {
                "Default",
                "Slow",
                "Fast",
                "VeryFast",
            };

            if (flyspeeds.Length > 0)
            {
                flyspeed++;
                if (flyspeed >= flyspeeds.Length)
                {
                    flyspeed = 0;
                }
                switch (flyspeed)
                {
                    case 0: // Default
                        FlySpeed = 0.2f;
                        break;
                    case 1: // Slow
                        FlySpeed = 0.02f;
                        break;
                    case 2: // Fast
                        FlySpeed = 2f;
                        break;
                    case 3: // VeryFast
                        FlySpeed = 7f;
                        break;
                }
            }

            Main.GetIndex("ChangeFlySpeed").overlapText = "FlySpeed: " + flyspeeds[flyspeed];
        }

    }
}
