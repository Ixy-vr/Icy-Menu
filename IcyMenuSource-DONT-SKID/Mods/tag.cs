using ExitGames.Client.Photon;
using GorillaTagScripts;
using Photon.Pun;
using StupidTemplate.Menu;
using StupidTemplate.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace OgGorillaTagMenuTemp.Mods
{
    internal class tag
    {
        public static void TagAll()
        {
            bool t = true;
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
            {
                VRRig vrrig = GorillaGameManager.instance.FindPlayerVRRig(player);
                if (!vrrig.mainSkin.material.name.Contains("fected"))
                {
                    t = false;
                    break;
                }
            }
            if (t)
            {
                Main.GetIndex("TagAll").enabled = false;
                return;
            }
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
            {
                VRRig vrrig = GorillaGameManager.instance.FindPlayerVRRig(player);
                if (!vrrig.mainSkin.material.name.Contains("fected") && !vrrig.mainSkin.material.name.Contains("It"))
                {
                    GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                    GorillaTagger.Instance.offlineVRRig.rightHandTransform.position = vrrig.bodyTransform.position;
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }

        public static void TagGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                RaycastHit raycastHit15;
                Physics.Raycast(
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up,
                    -GorillaLocomotion.Player.Instance.rightControllerTransform.up,
                    out raycastHit15
                );
                GameObject gameObject20 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                gameObject20.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                gameObject20.transform.position = raycastHit15.point;
                gameObject20.GetComponent<Renderer>().material.color = Color.cyan;
                gameObject20.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                UnityEngine.Object.Destroy(gameObject20.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(gameObject20.GetComponent<Collider>());
                UnityEngine.Object.Destroy(gameObject20, Time.deltaTime);

                GameObject lineObject = new GameObject("Line");
                LineRenderer line = lineObject.AddComponent<LineRenderer>();
                line.positionCount = 2;
                line.startWidth = 0.02f;
                line.endWidth = 0.02f;
                line.material = new Material(Shader.Find("GUI/Text Shader"));
                line.startColor = Color.cyan;
                line.endColor = Color.cyan;
                line.SetPosition(0, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                line.SetPosition(1, gameObject20.transform.position);
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
                {
                    VRRig rig = raycastHit15.collider.GetComponentInParent<VRRig>();
                    if (rig != null)
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = raycastHit15.collider.transform.position - new Vector3(0f, 0f, 0f);

                        line.startColor = Color.red;
                        line.endColor = Color.red;
                        gameObject20.GetComponent<Renderer>().material.color = Color.red;
                    }
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
                UnityEngine.Object.Destroy(lineObject, Time.deltaTime);
            }
        }

        public static void FlickTagGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                RaycastHit raycastHit15;
                Physics.Raycast(
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up,
                    -GorillaLocomotion.Player.Instance.rightControllerTransform.up,
                    out raycastHit15
                );
                GameObject gameObject20 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                gameObject20.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                gameObject20.transform.position = raycastHit15.point;
                gameObject20.GetComponent<Renderer>().material.color = Color.cyan;
                gameObject20.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                UnityEngine.Object.Destroy(gameObject20.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(gameObject20.GetComponent<Collider>());
                UnityEngine.Object.Destroy(gameObject20, Time.deltaTime);

                GameObject lineObject = new GameObject("Line");
                LineRenderer line = lineObject.AddComponent<LineRenderer>();
                line.positionCount = 2;
                line.startWidth = 0.02f;
                line.endWidth = 0.02f;
                line.material = new Material(Shader.Find("GUI/Text Shader"));
                line.startColor = Color.cyan;
                line.endColor = Color.cyan;
                line.SetPosition(0, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                line.SetPosition(1, gameObject20.transform.position);
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
                {
                    line.startColor = Color.red;
                    line.endColor = Color.red;
                    gameObject20.GetComponent<Renderer>().material.color = Color.red;
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position = gameObject20.transform.position;
                }
                UnityEngine.Object.Destroy(lineObject, Time.deltaTime);
            }
        }
    }
}
