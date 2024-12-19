using OgGorillaTagMenuTemp.Mods;
using Photon.Pun;
using StupidTemplate.Classes;
using StupidTemplate.Mods;
using UnityEngine;
using static StupidTemplate.Settings;

namespace StupidTemplate.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.Settings(), isTogglable = false },
                new ButtonInfo { buttonText = "Room", method =() => SettingsMods.Room(), isTogglable = false },
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.Movement(), isTogglable = false },
                new ButtonInfo { buttonText = "Visual", method =() => SettingsMods.Visual(), isTogglable = false },
                new ButtonInfo { buttonText = "Rig", method =() => SettingsMods.Rig(), isTogglable = false },
                new ButtonInfo { buttonText = "Fun", method =() => SettingsMods.Fun(), isTogglable = false },
                new ButtonInfo { buttonText = "Tag", method =() => SettingsMods.Tag(), isTogglable = false },
            },

            new ButtonInfo[] { // Settings 
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns you to the main page" },
                new ButtonInfo { buttonText = "RightHandMenu", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "DisconnectButton", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Puts a disconnect button on the menu."},
                new ButtonInfo { buttonText = "HomeButton", enableMethod =() => SettingsMods.EnableHomeButton(), disableMethod =() => SettingsMods.DisableHomeButton(), enabled = homeButton, toolTip = "Puts a home button on the menu."},
                new ButtonInfo { buttonText = "PanicButton", enableMethod =() => SettingsMods.EnablePanicButton(), disableMethod =() => SettingsMods.DisablePanicButton(), enabled = PanicButton, toolTip = "Puts a panic button on the menu."},
                new ButtonInfo { buttonText = "ChangeMenuTheme", method =() => Settings.ChangeTheme(), isTogglable = false, toolTip = "Changes the menu theme"},
                new ButtonInfo { buttonText = "NoFallInMenu", method =() => Settings.NoFallinMenu(), isTogglable = true, toolTip = "Makes you not fall when the menu is open" },
                new ButtonInfo { buttonText = "ChangeFlySpeed", method =() => Settings.ChangeFlySpeed(), isTogglable = false, toolTip = "Changes your fly speed." },
                new ButtonInfo { buttonText = "DisableMenuPhysics", enableMethod =() => Settings.DisablePhysicMenu(), disableMethod =() => Settings.EnablePhysicMenu(), isTogglable = true, toolTip = "Disables the menu physics" },
                new ButtonInfo { buttonText = "ChangeButtonSound", method =() => Button.ChangeButtonSound(), isTogglable = false, toolTip = "Changes the menu button sound" },
                new ButtonInfo { buttonText = "FPSCounter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, isTogglable = true, toolTip = "Enables the fps counter" },
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},

            },

            new ButtonInfo[] { // room mods 
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns you to the main page" },
                new ButtonInfo { buttonText = "QuitGTAG", method = Application.Quit, isTogglable = false },
                new ButtonInfo { buttonText = "Disconnect", method = PhotonNetwork.Disconnect, isTogglable = false },
                new ButtonInfo { buttonText = "JoinCode: BOT", method = mods.JoinCodeBOT, isTogglable = false },
                new ButtonInfo { buttonText = "JoinCode: PBBV", method = mods.JoinCodePBBV, isTogglable = false },
                new ButtonInfo { buttonText = "JoinCode: DAISY", method = mods.JoinCodeDAISY, isTogglable = false },
                new ButtonInfo { buttonText = "JoinCode: ECHO", method = mods.JoinCodeECHO, isTogglable = false },
                new ButtonInfo { buttonText = "JoinCode: TTT", method = mods.JoinCodeTTT, isTogglable = false },
            },

            new ButtonInfo[] { // movement mods 
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns you to the main page" },
                new ButtonInfo { buttonText = "WASDFly", method = mods.WASDFly, },
                new ButtonInfo { buttonText = "Platforms", method = mods.Platforms, },
                new ButtonInfo { buttonText = "Invis Platforms", method = mods.InvisPlatforms, },
                new ButtonInfo { buttonText = "Fly [A]", method = mods.Fly },
                new ButtonInfo { buttonText = "VelocityFly [A]", method = mods.VFly },
                new ButtonInfo { buttonText = "NoClipFly [A]", method = mods.NCFly },
                new ButtonInfo { buttonText = "TPGun", method = mods.TPGun },
                new ButtonInfo { buttonText = "NoTagFreeze", method = mods.NoTagFreeze },
                new ButtonInfo { buttonText = "ForceTagFreeze", enableMethod = mods.ForceTagFreeze, disableMethod = mods.NoTagFreeze },
                new ButtonInfo { buttonText = "LongArms", enableMethod = mods.LongArms, disableMethod = mods.NoLongArms },
                new ButtonInfo { buttonText = "NoClip [T]", method = mods.NoClip },
                new ButtonInfo { buttonText = "CheckPoint", method = mods.CheckPoint, disableMethod = mods.NoCheckPoint },
                new ButtonInfo { buttonText = "C4", method = mods.C4, disableMethod = mods.NoCheckPoint },
                new ButtonInfo { buttonText = "SlideControl", method = mods.SlideControl },
                new ButtonInfo { buttonText = "SlingShotFly [A]", method = mods.SlingshotFly },
                new ButtonInfo { buttonText = "ZeroGravitySlingShotFly [A]", method = mods.ZeroGravSlingshotFly },
                new ButtonInfo { buttonText = "No Gravity", method = mods.NoGravity },
                new ButtonInfo { buttonText = "High Gravity", method = mods.HighGravity },
                new ButtonInfo { buttonText = "Zero Gravity", method = mods.ZeroGravity },
                new ButtonInfo { buttonText = "WallWalk [<color=red>IIDK</color>]", method = mods.WallWalk },
            },

            new ButtonInfo[] { // Visual
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns you to the main page" },
                new ButtonInfo { buttonText = "Tracers", method = visual.Tracers, isTogglable = true },
                new ButtonInfo { buttonText = "Chams", method = visual.Chams, disableMethod = visual.ChamsOff, isTogglable = true },
                new ButtonInfo { buttonText = "BreadCrumbs", method = visual.BreadCrums, isTogglable = true },
                new ButtonInfo { buttonText = "BoxESP", method = visual.BoxESP, isTogglable = true },
                new ButtonInfo { buttonText = "HitBoxes", method = visual.HitBoxes, isTogglable = true },
                new ButtonInfo { buttonText = "ChangeTimeOfDay", method = visual.ChangeTimeOfday, isTogglable = false },
            },

            new ButtonInfo[] { // Rig 
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns you to the main page" },
                new ButtonInfo { buttonText = "GhostMonke [B]", method = mods.GhostMonke },
                new ButtonInfo { buttonText = "InvisMonke [A]", method = mods.Invis, },
                new ButtonInfo { buttonText = "GrabRig", method = mods.GrabRig },
                new ButtonInfo { buttonText = "RigGun", method = mods.RigGun },
                new ButtonInfo { buttonText = "JumpScareCheckPoint", method = mods.JumpScareCheckPoint, disableMethod = mods.NoCheckPoint },
                new ButtonInfo { buttonText = "HeadSpinX", method = mods.HeadSpinX,  },
                new ButtonInfo { buttonText = "HeadSpinY", method = mods.HeadSpinY, },
                new ButtonInfo { buttonText = "HeadSpinZ", method = mods.HeadSpinZ, },
                new ButtonInfo { buttonText = "FixHead", method = mods.FixHead },
                new ButtonInfo { buttonText = "NoFingerMovement", method = mods.NoFingerMovement },
            },

            new ButtonInfo[] { // Name 
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns you to the main page" },
                new ButtonInfo { buttonText = "GrabBug", method = mods.GrabBug, isTogglable = true },
                new ButtonInfo { buttonText = "GrabBat", method = mods.GrabBat, isTogglable = true },
                new ButtonInfo { buttonText = "BugGun", method = mods.BugGun, isTogglable = true },
                new ButtonInfo { buttonText = "BatGun", method = mods.BatGun, isTogglable = true },
                new ButtonInfo { buttonText = "Name = [PBBV]", method = mods.PBBVName, isTogglable = false },
                new ButtonInfo { buttonText = "Name = [BOT]", method = mods.BOTName, isTogglable = false },
                new ButtonInfo { buttonText = "Name = [DAISY09]", method = mods.DAISYName, isTogglable = false },
                new ButtonInfo { buttonText = "Name = [TTTPIG]", method = mods.TTTName, isTogglable = false },
            },

            new ButtonInfo[] { // Tag 
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns you to the main page" },
                new ButtonInfo { buttonText = "TagAll", method = tag.TagAll, isTogglable = true },
                new ButtonInfo { buttonText = "TagGun", method = tag.TagGun, isTogglable = true },
                new ButtonInfo { buttonText = "FlickTagGun", method = tag.FlickTagGun, isTogglable = true },
            },

            new ButtonInfo[] { // NEEDED
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false }, // for home button
                new ButtonInfo { buttonText = "Panic", method =() => Global.Panic(), isTogglable = false }, // for panic button
                new ButtonInfo { buttonText = "Boards", method =() => Global.CustomBoards(), enabled = true }, // for panic button
            },
        };
    }
}

// BROKEN MODS
// new ButtonInfo { buttonText = "SpazMonke", method = mods.SpazMonke, disableMethod = mods.FixSpaz },