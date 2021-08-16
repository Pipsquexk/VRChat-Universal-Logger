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

            event1 = GUI.Toggle(new Rect(5, 15, 200, 25), event1, "Event 1");

            event3 = GUI.Toggle(new Rect(5, 40, 200, 25), event3, "Event 3");

            event6 = GUI.Toggle(new Rect(5, 65, 200, 25), event6, "Event 6");

            event7 = GUI.Toggle(new Rect(5, 90, 200, 25), event7, "Event 7");

            event8 = GUI.Toggle(new Rect(5, 115, 200, 25), event8, "Event 8");

            event9 = GUI.Toggle(new Rect(5, 140, 200, 25), event9, "Event 9");

            event33 = GUI.Toggle(new Rect(5, 165, 200, 25), event33, "Event 33");

            event202 = GUI.Toggle(new Rect(5, 190, 200, 25), event202, "Event 202");

            if (GUI.Button(new Rect(5, 215, 200, 40), "UNPATCH"))
            {
                UniLogger.Harmony.Patches.UnpatchAll();
            }

            //if (GUI.Button(new Rect(5, 215, 200, 40), "Mute Dutboot"))
            //{

            //    var reo = new RaiseEventOptions()
            //    {
            //        field_Public_ReceiverGroup_0 = ReceiverGroup.Others,
            //        field_Public_Byte_0 = 0,
            //        field_Public_Byte_1 = 0,
            //        field_Public_EventCaching_0 = EventCaching.DoNotCache,
            //        field_Public_ArrayOf_Int32_0 = null,
            //        field_Public_WebFlags_0 = 
            //        new WebFlags(0) 
            //        { 
            //            field_Public_Byte_0 = 0,
            //            prop_Boolean_0 = false,
            //            prop_Boolean_1 = false,
            //            prop_Boolean_2 = false,
            //            prop_Boolean_3 = false
            //        }

            //    };
            //    var so = new SendOptions()
            //    {
            //        DeliveryMode = DeliveryMode.Reliable,
            //        Reliability = true,
            //        Channel = 0,
            //        Encrypt = true
            //    };
            //    PhotonNetwork.field_Public_Static_LoadBalancingClient_0.Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0(33, Serialization.FromManagedToIL2CPP(new Dictionary<byte, object>() { { 3, true }, { 0, 23 }, { 1, "usr_7e7dd173-e6c5-4e9e-b674-7c8dcb142474" } }), reo, so);
            //    var req = new HTTPRequest(new Il2CppSystem.Uri("https://api.vrchat.cloud/api/1/auth/user/playermoderations?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26&organization=vrchat"), HTTPMethods.Post);
            //    var ctHead = new Il2CppSystem.Collections.Generic.List<string>();
            //    ctHead.Add("application/json");
            //    var headersDic = new Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Collections.Generic.List<string>>();
            //    headersDic.Add("content-type", ctHead);
            //    req.Headers = headersDic;
            //    req.Cookies.Add(new BestHTTP.Cookies.Cookie("Cookie", ApiCredentials.authToken));
            //    req.Cookies.Add(new BestHTTP.Cookies.Cookie("Cookie", ""));
            //    req.RawData = System.Text.Encoding.Default.GetBytes(@"{""type"":""mute"", ""moderated"":""usr_7e7dd173-e6c5-4e9e-b674-7c8dcb142474"", ""created"":""01/01/000100:00:00""}");
            //    req.Send();
            //}

        }
    }
}
