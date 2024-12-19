using StupidTemplate.Classes;
using StupidTemplate.Menu;
using System.Diagnostics;
using System.IO;
using System.Net;
using TMPro;
using UnityEngine;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    internal class Global
    {
        public static void ReturnHome()
        {
            buttonsType = 0;
            pageNumber = 0;
        }

        static bool on = false;
        public static void CustomBoards()
        {
            if (!on)
            {
                GameObject.Find("CodeOfConduct").GetComponent<TMP_Text>().text = "<color=#00FFFF>Icy Menu</color>";
                GameObject.Find("motd (1)").GetComponent<TMP_Text>().text = "<color=#00FFFF>Icy Menu</color>";
                GameObject coctext = GameObject.Find("COC Text");
                coctext.GetComponent<TMP_Text>().richText = true;
                coctext.GetComponent<TMP_Text>().text = "<color=#00FFFF>THANK YOU FOR USING ICY MENU!\n\nTHIS MENU IS AND SHOULD BE FULLY UND.\n\nIF YOU HAVE ANY ISSUES PLEASE REPORT IT TO THE DISCORD. discord.gg/SRsHgwt6Jv\n\n>-------------CREDITS-------------<\n\niiDk - WALL WALK</color>";
                on = true;
            }
        }
        public static void Panic()
        {
            foreach (ButtonInfo[] btn in Buttons.buttons)
            {
                foreach (ButtonInfo bt in btn)
                {
                    if (bt.enabled)
                    {
                        Toggle(bt.buttonText);
                    }
                }
            }
        }
    }
}
