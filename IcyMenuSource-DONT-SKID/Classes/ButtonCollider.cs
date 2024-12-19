using Photon.Pun;
using StupidTemplate.Menu;
using UnityEngine;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;

namespace StupidTemplate.Classes
{
	internal class Button : MonoBehaviour
	{
		public string relatedText;

		public static float buttonCooldown = 0f;
		public void OnTriggerEnter(Collider collider)
		{
            if (Time.time > buttonCooldown && collider == buttonCollider && menu != null)
			{
                buttonCooldown = Time.time + 0.2f;
                GorillaTagger.Instance.StartVibration(rightHanded, GorillaTagger.Instance.tagHapticStrength / 2f, GorillaTagger.Instance.tagHapticDuration / 2f);
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(btnsound, rightHanded, 3f);
				Toggle(this.relatedText);
            }
		}
        static int sound = 0;
        static int btnsound = 67;
        public static void ChangeButtonSound()
        {
            string[] sounds =
            {
                "Button",
                "Keyboard",
                "Bark",
                "Glass",
            };
            if (sounds.Length > 0)
            {
                sound++;
                if (sound >= sounds.Length)
                {
                    sound = 0;
                }
                switch (sound)
                {
                    case 0: // button
                        btnsound = 67;
                        break;
                    case 1: // keyboard
                        btnsound = 66;
                        break;
                    case 2: // bark
                        btnsound = 8;
                        break;
                    case 3: // glass
                        btnsound = 29;
                        break;
                }

            }
            Main.GetIndex("ChangeButtonSound").overlapText = "ButtonSound: " + sounds[sound];
        }
    }
}
