using BepInEx;
using Cinemachine.Utility;
using GorillaNetworking;
using Photon.Pun;
using StupidTemplate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

namespace OgGorillaTagMenuTemp.Mods
{
    internal class mods
    {
        private static GameObject Point;

        public static float flySpeed = 5f;
        public static float t = 0f;

        public static float mouseposx = -1f;
        public static float mouseposy = -1f;
        public static void WASDFly()
        {
            Vector3 rot = Vector3.zero;
            mouse = Mouse.current;
            if (mouse.rightButton.isPressed)
            {
                float mouseX = mouse.delta.x.ReadValue() * 3f;
                float mouseY = mouse.delta.y.ReadValue() * 3f;
                rot.x -= mouseY;
                rot.y += mouseX;
                rot.x = Mathf.Clamp(rot.x, -90f, 90f);
                Quaternion targetRotation = Quaternion.Euler(rot.x, rot.y, 0f);
                GorillaLocomotion.Player.Instance.rightControllerTransform.parent.localRotation = targetRotation;
            }
            GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            current = Keyboard.current;
            if (current.wKey.isPressed)
            {
                GorillaTagger.Instance.rigidbody.transform.position += GorillaLocomotion.Player.Instance.bodyCollider.transform.parent.forward * flySpeed * Time.deltaTime;
            }
            if (current.sKey.isPressed)
            {
                GorillaTagger.Instance.rigidbody.transform.position += GorillaLocomotion.Player.Instance.bodyCollider.transform.parent.forward * -flySpeed * Time.deltaTime;
            }
            if (current.dKey.isPressed)
            {
                GorillaTagger.Instance.rigidbody.transform.position += GorillaLocomotion.Player.Instance.bodyCollider.transform.parent.right * flySpeed * Time.deltaTime;
            }
            if (current.aKey.isPressed)
            {
                GorillaTagger.Instance.rigidbody.transform.position += GorillaLocomotion.Player.Instance.bodyCollider.transform.parent.right * -flySpeed * Time.deltaTime;
            }

            if (current.spaceKey.isPressed)
            {
                GorillaTagger.Instance.rigidbody.transform.position += GorillaLocomotion.Player.Instance.bodyCollider.transform.parent.up * flySpeed * Time.deltaTime;
            }
            if (current.leftCtrlKey.isPressed)
            {
                GorillaTagger.Instance.rigidbody.transform.position += GorillaLocomotion.Player.Instance.bodyCollider.transform.parent.up * -flySpeed * Time.deltaTime;
            }

            if (current.leftShiftKey.isPressed)
            {
                flySpeed = 10f;
            }
        }

        // fun mods
        static GameObject bug = GameObject.Find("Floating Bug Holdable");
        static GameObject bat = GameObject.Find("Cave Bat Holdable");
        static GameObject ball = GameObject.Find("Beach Ball");
        public static void GrabBug()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                bug.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
            }
        }
        public static void BugGun()
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
                    bug.transform.position = gameObject20.transform.position;
                }
                UnityEngine.Object.Destroy(lineObject, Time.deltaTime);
            }
        }


        public static void GrabBat()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                bat.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
            }
        }
        public static void BatGun()
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
                    bat.transform.position = gameObject20.transform.position;
                }
                UnityEngine.Object.Destroy(lineObject, Time.deltaTime);
            }
        }
        public static void JoinCodeBOT()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("BOT", JoinType.Solo);
        }
        public static void JoinCodePBBV()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("PBBV", JoinType.Solo);
        }
        public static void JoinCodeDAISY()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("DAISY", JoinType.Solo);
        }
        public static void JoinCodeECHO()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("ECHO", JoinType.Solo);
        }
        public static void JoinCodeTTT()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("TTT", JoinType.Solo);
        }


        public static void NoCheckPoint()
        {
            GameObject.Destroy(Point);
        }
        public static void DAISYName()
        {
            ChangeName("DAISY09");
        }
        public static void TTTName()
        {
            ChangeName("TTTPIG");
        }
        public static void PBBVName()
        {
            ChangeName("PBBV");
        }
        public static void BOTName()
        {
            ChangeName("BOT");
        }
        private static void ChangeName(string name)
        {
            GorillaComputer.instance.savedName = name;
            GorillaComputer.instance.currentName = name;
            PhotonNetwork.LocalPlayer.NickName = name;
            GorillaComputer.instance.offlineVRRigNametagText.text = name;
            PlayerPrefs.Save();
        }

        public static void NoGravity()
        {
            GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().useGravity = false;
        }
        public static void HighGravity()
        {
            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.down * (7f), ForceMode.Acceleration);
        }
        public static void ZeroGravity()
        {
            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (7f), ForceMode.Acceleration);
        }

        static Vector3 walkPos;
        static Vector3 walkNormal;
        public static void WallWalk() // CREDITS TO iiDk
        {
            if (GorillaLocomotion.Player.Instance.wasLeftHandTouching || GorillaLocomotion.Player.Instance.wasRightHandTouching)
            {
                FieldInfo fieldInfo = typeof(GorillaLocomotion.Player).GetField("lastHitInfoHand", BindingFlags.NonPublic | BindingFlags.Instance);
                RaycastHit ray = (RaycastHit)fieldInfo.GetValue(GorillaLocomotion.Player.Instance);
                walkPos = ray.point;
                walkNormal = ray.normal;
            }

            if (walkPos != Vector3.zero && ControllerInputPoller.instance.rightGrab)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(walkNormal * -9f, ForceMode.Acceleration);
                ZeroGravity();
            }
        }
        public static void SlingshotFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * (4.5f * 3);
            }
        }
        public static void ZeroGravSlingshotFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (7f), ForceMode.Acceleration);
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * (4.5f * 3);
            }
        }
        public static void HeadSpinX()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x += 15f;
        }

        public static void HeadSpinY()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y += 15f;
        }

        public static void HeadSpinZ()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z += 15f;
        }

        
        public static void NoFingerMovement()
        {
            ControllerInputPoller.instance.rightGrab = false;
            ControllerInputPoller.instance.rightGrabRelease = false;
            ControllerInputPoller.instance.leftGrabRelease = false;
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftGrab = false;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexTouch = 0f;
            ControllerInputPoller.instance.leftControllerIndexTouch = 0f;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.leftControllerSecondaryButtonTouch = false;
        }
        public static void FixHead()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset = new Vector3(0f, 0f, 0f);
        }
        public static void SlideControl()
        {
            GorillaLocomotion.Player.Instance.slideControl = 2f;
        }
        public static void CheckPoint()
        {
            if (Point == null)
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    Point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Point.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    Point.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    Point.GetComponent<Renderer>().material.color = Color.white;
                    Point.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    Point.AddComponent<Collider>().enabled = false;
                }
            }

            if (Point != null)
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    Point.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    Point.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    Point.AddComponent<Collider>().enabled = false;
                }
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
                {
                    GorillaLocomotion.Player.Instance.transform.position = Point.transform.position;
                    Point.GetComponent<Renderer>().material.color = Color.red;
                    Point.AddComponent<Collider>().enabled = false;
                    foreach (MeshCollider m in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                    {
                        m.enabled = false;
                    }
                    GameObject.Destroy(Point, Time.deltaTime);
                }
                else
                {
                    Point.GetComponent<Renderer>().material.color = Color.white;
                    Point.AddComponent<Collider>().enabled = false;
                    foreach (MeshCollider m in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                    {
                        m.enabled = true;
                    }
                }
            }
        }

        static Keyboard current;
        static Mouse mouse;
        public static void JumpScareCheckPoint()
        {
            current = Keyboard.current;
            if (Point == null)
            {
                if (ControllerInputPoller.instance.rightGrab || current.hKey.wasPressedThisFrame) 
                {
                    Point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Point.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    Point.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    Point.GetComponent<Renderer>().material.color = Color.white;
                    Point.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    Point.GetComponent<Collider>().enabled = false;
                }
            }

            if (Point != null)
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    Point.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    Point.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    Point.GetComponent<Collider>().enabled = false;
                    Point.GetComponent<Renderer>().material.color = Color.white;
                }
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f || current.tKey.isPressed)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = Point.transform.position;
                    Point.GetComponent<Renderer>().material.color = Color.red;
                    Point.GetComponent<Collider>().enabled = false;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }

        public static void C4()
        {
            if (Point == null)
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    Point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Point.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    Point.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    Point.GetComponent<Renderer>().material.color = Color.white;
                    Point.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    Point.AddComponent<Collider>().enabled = false;
                }
            }

            if (Point != null)
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    Point.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    Point.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    Point.AddComponent<Collider>().enabled = false;
                    Point.GetComponent<Renderer>().material.color = Color.white;
                }
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
                {
                    Vector3 vector = (GorillaTagger.Instance.bodyCollider.transform.position - Point.transform.position);
                    vector.Normalize();
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += 3f * vector;
                    Point.GetComponent<Renderer>().material.color = Color.red;
                    Point.AddComponent<Collider>().enabled = false;
                    GameObject.Destroy(Point, Time.deltaTime);
                }
            }
        }
        public static void NoTagFreeze()
        {
            GorillaLocomotion.Player.Instance.disableMovement = false;
        }
        public static void ForceTagFreeze()
        {
            GorillaLocomotion.Player.Instance.disableMovement = true;
        }
        private static bool GhostMonk = false;
        private static bool off = false;
        public static void GhostMonke()
        {
            bool on = ControllerInputPoller.instance.rightControllerSecondaryButton;

            if (on && !off)
            {
                GhostMonk = !GhostMonk;
                GorillaTagger.Instance.offlineVRRig.enabled = !GhostMonk;
            }
            off = on;
        }

        public static void GrabRig()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
        public static void RigGun()
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
                gameObject20.GetComponent<Collider>().enabled = false;
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
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = gameObject20.transform.position;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
                UnityEngine.Object.Destroy(lineObject, Time.deltaTime);
            }
        }

        private static bool invisMonk = false;
        private static bool off1 = false;
        public static void Invis()
        {
            bool on2 = ControllerInputPoller.instance.rightControllerPrimaryButton;

            if (on2 && !off1)
            {
                invisMonk = !invisMonk;
                GorillaTagger.Instance.offlineVRRig.enabled = !invisMonk;
                GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(45454f, 343434f, 434f);
            }
            off1 = on2;
        }
        public static void NoClip()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
            {
                foreach (MeshCollider m in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                {
                    m.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider m in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                {
                    m.enabled = true;
                }
            }
        }
        public static void LongArms()
        {
            GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        public static void NoLongArms()
        {
            GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        static bool ar = false;
        public static void TPGun()
        {
            mouse = Mouse.current;
            if (ControllerInputPoller.instance.rightGrab || mouse.rightButton.isPressed)
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

                Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
                if (Physics.Raycast(ray, out raycastHit15))
                {
                    gameObject20.transform.position = raycastHit15.point;
                }


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
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f || mouse.leftButton.isPressed)
                {
                    line.startColor = Color.red;
                    line.endColor = Color.red;
                    gameObject20.GetComponent<Renderer>().material.color = Color.red;
                    if (!ar)
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                        GorillaLocomotion.Player.Instance.transform.position = gameObject20.transform.position;
                        ar = true;
                    }
                }
                else
                {
                    ar = false;
                }
                UnityEngine.Object.Destroy(lineObject, Time.deltaTime);
            }
        }


        public static GameObject plat1;
        public static GameObject plat2;

        public static void Platforms()
        {
            if (plat1 == null)
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    plat1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    plat1.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    plat1.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation * Quaternion.Euler(0, 0, 90);
                    plat1.GetComponent<Renderer>().material.color = Color.cyan;
                    plat1.transform.localScale = new Vector3(0.3f, 0.03f, 0.3f);
                }
            }
            else
            {
                if (!ControllerInputPoller.instance.rightGrab)
                {
                    GameObject.Destroy(plat1, Time.deltaTime);
                }
            }
            if (plat2 == null)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    plat2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    plat2.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                    plat2.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation * Quaternion.Euler(0, 0, 90);
                    plat2.GetComponent<Renderer>().material.color = Color.cyan;
                    plat2.transform.localScale = new Vector3(0.3f, 0.03f, 0.3f);
                }
            }
            else
            {
                if (!ControllerInputPoller.instance.leftGrab)
                {
                    GameObject.Destroy(plat2, Time.deltaTime);
                }
            }
        }

        public static void InvisPlatforms()
        {
            if (plat1 == null)
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    plat1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    plat1.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    plat1.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation * Quaternion.Euler(0, 0, 90);
                    plat1.GetComponent<Renderer>().enabled = false;
                    plat1.transform.localScale = new Vector3(0.3f, 0.03f, 0.3f);
                }
            }
            if (plat1 != null)
            {
                if (!ControllerInputPoller.instance.rightGrab)
                {
                    GameObject.Destroy(plat1, Time.deltaTime);
                }
            }

            if (plat2 == null)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    plat2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    plat2.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                    plat2.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation * Quaternion.Euler(0, 0, 90);
                    plat2.GetComponent<Renderer>().enabled = false;
                    plat2.transform.localScale = new Vector3(0.3f, 0.03f, 0.3f);
                }
            }
            if (plat2 != null)
            {
                if (!ControllerInputPoller.instance.leftGrab)
                {
                    GameObject.Destroy(plat2, Time.deltaTime);
                }
            }
        }
        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Settings.FlySpeed;
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity = Vector3.zero;
            }
        }
        public static void VFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Settings.FlySpeed;
            }
        }
        public static void NCFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                foreach (MeshCollider m in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                {
                    m.enabled = false;
                }
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Settings.FlySpeed;
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity = Vector3.zero;
            }
            else
            {
                foreach (MeshCollider m in UnityEngine.Object.FindObjectsOfType<MeshCollider>())
                {
                    m.enabled = true;
                }
            }
        }
    }
}
