using Photon.Pun;
using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

namespace OgGorillaTagMenuTemp.Mods
{
    internal class visual
    {
        public static void Tracers()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != GorillaTagger.Instance.offlineVRRig)
                {
                    Transform rightHand = GorillaTagger.Instance.rightHandTransform;
                    GameObject line = new GameObject("line");
                    LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
                    lineRenderer.positionCount = 2;
                    lineRenderer.SetPosition(0, rightHand.position); 
                    lineRenderer.SetPosition(1, rig.transform.position); 
                    lineRenderer.startWidth = 0.01f;
                    lineRenderer.endWidth = 0.01f;
                    Material lineMaterial = new Material(Shader.Find("GUI/Text Shader"));
                    lineRenderer.material = lineMaterial;
                    lineRenderer.startColor = Color.cyan;
                    lineRenderer.endColor = Color.cyan;
                    if (rig.mainSkin.material.name.Contains("fected"))
                    {
                        lineRenderer.startColor = Color.red;
                        lineRenderer.endColor = Color.red;
                    }
                    GameObject.Destroy(line, Time.deltaTime);
                }
            }
        }


        public static void BreadCrums()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject BreadCrum = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    BreadCrum.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    BreadCrum.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    BreadCrum.GetComponent<Collider>().enabled = false;
                    BreadCrum.GetComponent<Renderer>().material.color = Color.cyan;
                    if (rig.mainSkin.material.name.Contains("fected"))
                    {
                        BreadCrum.GetComponent<Renderer>().material.color = Color.red;
                    }
                    BreadCrum.transform.position = rig.transform.position;
                    GameObject.Destroy(BreadCrum, 1f);
                }
            }
        }


        static int time = 0;
        public static void ChangeTimeOfday()
        {
            string[] times =
            {
                "Day",
                "Night",
                "Morning",
                "Evening",
            };
            if (times.Length > 0)
            {
                time++;
                if (time >= times.Length)
                {
                    time = 0;
                }
                switch (time)
                {
                    case 0:
                        BetterDayNightManager.instance.SetTimeOfDay(3);
                        break;
                    case 1:
                        BetterDayNightManager.instance.SetTimeOfDay(0);
                        break;
                    case 2:
                        BetterDayNightManager.instance.SetTimeOfDay(1);
                        break;
                    case 3:
                        BetterDayNightManager.instance.SetTimeOfDay(7);
                        break;
                }

            }
            Main.GetIndex("ChangeTimeOfDay").overlapText = "TimeOfDay: " + times[time];
        }

        public static void HitBoxes()
        {
            GameObject hitbox = new GameObject();
            GameObject hitbox1 = new GameObject();
            hitbox.transform.SetParent(GorillaTagger.Instance.rightHandTransform);
            hitbox1.transform.SetParent(GorillaTagger.Instance.leftHandTransform);

            hitbox = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            hitbox.transform.position = GorillaTagger.Instance.rightHandTransform.position;
            hitbox.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
            hitbox.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            hitbox.GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f, 0.04f);
            hitbox.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            hitbox.GetComponent<Collider>().enabled = false;

            hitbox1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            hitbox1.transform.position = GorillaTagger.Instance.leftHandTransform.position;
            hitbox1.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
            hitbox1.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            hitbox1.GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f, 0.04f);
            hitbox1.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            hitbox1.GetComponent<Collider>().enabled = false;

            GameObject.Destroy(hitbox, Time.deltaTime);
            GameObject.Destroy(hitbox1, Time.deltaTime);
        }
        public static void BoxESP()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    box.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    box.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    box.GetComponent<Renderer>().material.color = Color.cyan;
                    if (rig.mainSkin.material.name.Contains("fected"))
                    {
                        box.GetComponent<Renderer>().material.color = Color.red;
                    }
                    box.GetComponent<Collider>().enabled = false;
                    box.transform.position = rig.transform.position;
                    GameObject.Destroy(box, Time.deltaTime);
                }
            }
        }
        public static void Chams()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != GorillaTagger.Instance.offlineVRRig)
                {
                    Renderer renderer = rig.mainSkin.GetComponent<Renderer>();
                    Shader shader = Shader.Find("GUI/Text Shader");
                    renderer.material.shader = shader;
                    renderer.material.color = Color.cyan;
                    if (rig.mainSkin.material.name.Contains("fected"))
                    {
                        renderer.GetComponent<Renderer>().material.color = Color.red;
                    }
                }
            }
        }


        public static void ChamsOff()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                rig.mainSkin.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
            }
        }
    }
}
