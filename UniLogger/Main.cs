using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using BestHTTP;
using VRC.Core;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;
using VRC.Management;

namespace UniLogger
{
    public class Main : MelonMod
    {

        public static bool event1 = true, event3 = true, event6 = true, event7 = true, event8 = true, event9 = true, event33 = true, event202 = true, event206 = true, event210 = true;

        public static bool patched;
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
        }

        public override void OnGUI()
        {
            base.OnGUI();

            if (!patched)
            {
                if (GUI.Button(new Rect(5, 15, 200, 40), "PATCH"))
                {
                    UniLogger.Harmony.Patches.ApplyPatches();
                }
                return;
            }

            event1 = GUI.Toggle(new Rect(5, 15, 200, 25), event1, "Log Event 1");

            event3 = GUI.Toggle(new Rect(5, 40, 200, 25), event3, "Log Event 3");

            event6 = GUI.Toggle(new Rect(5, 65, 200, 25), event6, "Log Event 6");

            event7 = GUI.Toggle(new Rect(5, 90, 200, 25), event7, "Log Event 7");

            event8 = GUI.Toggle(new Rect(5, 115, 200, 25), event8, "Log Event 8");

            event9 = GUI.Toggle(new Rect(5, 140, 200, 25), event9, "Log Event 9");

            event33 = GUI.Toggle(new Rect(5, 165, 200, 25), event33, "Log Event 33");

            event202 = GUI.Toggle(new Rect(5, 190, 200, 25), event202, "Log Event 202");

            if (GUI.Button(new Rect(5, 215, 200, 40), "UNPATCH"))
            {
                UniLogger.Harmony.Patches.UnpatchAll();
            }

        }
    }
}
