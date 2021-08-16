using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using System.Reflection;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using MelonLoader;
using VRC.SDKBase;
using UnityEngine;
using UnhollowerRuntimeLib;
using VRC.Management;
using static VRC.Core.ApiPlayerModeration;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;
//using static VRC.Core.ApiModeration;

namespace UniLogger.Harmony
{
    public static class Patches
    {

        private static HarmonyMethod GetLocalPatch(string methodName)
        {
            return new HarmonyMethod(typeof(Patches).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static));
        }

        public static HarmonyLib.Harmony instance;

        public static void ApplyPatches()
        {
            try
            {
                MelonLogger.Msg(ConsoleColor.Blue, "Patching methods.....");


                instance = new HarmonyLib.Harmony("UniLogger");
                //instance.Patch(typeof().GetMethod(""), GetLocalPatch(""));
                instance.Patch(typeof(PhotonNetwork).GetMethod("Method_Private_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0"), GetLocalPatch("PNEvent"));
                instance.Patch(typeof(LoadBalancingClient).GetMethod("Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0"), GetLocalPatch("LBCEvent"));
                instance.Patch(typeof(LoadBalancingPeer).GetMethod("Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0"), GetLocalPatch("LBPEvent"));
                instance.Patch(typeof(VRC.Networking.UdonSync).GetMethod("UdonSyncRunProgramAsRPC"), GetLocalPatch("USRunProgramAsRPC"));
                instance.Patch(typeof(Networking).GetMethod("RPC", new Type[] { typeof(RPC.Destination), typeof(GameObject), typeof(string) }), GetLocalPatch("NetRPC"));
                instance.Patch(typeof(Networking).GetMethod("RPC", new Type[] { typeof(VRCPlayerApi), typeof(GameObject), typeof(string) }), GetLocalPatch("NetRPC2"));
                //instance.Patch(typeof(ModerationManager).GetMethod("Method_Private_Void_String_ModerationType_0"), GetLocalPatch("NewModerate"));
                //instance.Patch(typeof(ModerationManager).GetMethod("Method_Private_Void_String_Byte_Object_0"), GetLocalPatch("NewEvent"));
                instance.Patch(typeof(BestHTTP.HTTPRequest).GetMethod("Send"), GetLocalPatch("WRSend"));


                /* PATCH ALL IN SPECIFIED CLASS
                foreach (MethodInfo mI in typeof(ModerationManager).GetMethods())
                {
                    if (mI.Name.ToLower().Contains("get") || mI.Name.ToLower().Contains("set") || mI.Name.ToLower().Contains("method_public_void_0"))
                        return;

                    instance.Patch(typeof(ModerationManager).GetMethod(mI.Name), GetLocalPatch("ALLPATCH"));
                }
                */

                Main.patched = true;
                MelonLogger.Msg(ConsoleColor.Green, "Patched methods!");
            }
            catch (Exception ex)
            {
                MelonLogger.Msg(ConsoleColor.Red, $"Failed to patch methods with the Exception: {ex.ToString()}");
            }
        }

        public static void UnpatchAll()
        {
            try
            {
                MelonLogger.Msg(ConsoleColor.Blue, "Unpatching methods.....");

                instance.UnpatchAll("UniLogger");
                Main.patched = false;

                MelonLogger.Msg(ConsoleColor.Green, "Unpatched methods!");
            }
            catch (Exception ex)
            {
                MelonLogger.Msg(ConsoleColor.Red, $"Failed to unpatch methods with the Exception: {ex.ToString()}");
            }
        }

        //private static bool ALLPATCH(MethodInfo __originalMethod)
        //{
        //    MelonLogger.Msg($"{__originalMethod.Name} was called");
        //    return true;
        //}

        //private static bool NewModerate(string __0, ModerationType __1, [CallerMemberName] string __state = "")
        //{
        //    MelonLogger.Msg(ConsoleColor.Cyan, $"{__0}, {__1.ToString()}");
        //    MelonLogger.Msg(ConsoleColor.Cyan, __state + " called me");
        //    return true;
        //}

        //private static bool NewEvent(string __0, byte __1, Il2CppSystem.Object __2, string __state = "")
        //{
        //    MelonLogger.Msg(ConsoleColor.Cyan, $"{__0}, {__1.ToString()}, {__2.ToString()}");
        //    return true;
        //}

        private static bool PNEvent(byte __0, Il2CppSystem.Object __1, RaiseEventOptions __2, SendOptions __3)
        {
            switch (__0)
            {
                case 1:
                    if (!Main.event1)
                        return true;

                    LogEventInfo(__0, __1, __2, __3, true, true);

                    break;
                case 3:
                    if (!Main.event3)
                        return true;

                    LogEventInfo(__0, __1, __2, __3, false, false);

                    break;
                case 6:
                    if (!Main.event6)
                        return true;

                    LogEventInfo(__0, __1, __2, __3, true, false);

                    break;
                case 7:
                    if (!Main.event7)
                        return true;
                    break;
                case 8:
                    if (!Main.event8)
                        return true;
                    break;
                case 9:
                    if (!Main.event9)
                        return true;
                    break;
                case 33:
                    if (!Main.event33)
                        return true;



                    break;
                case 202:
                    if (!Main.event202)
                        return true;
                    break;
            }

            MelonLogger.Msg(ConsoleColor.Green, $"[PhotonNetwork] RaiseEvent - {__0}");
            return true;
        }

        private static bool LBCEvent(byte __0, Il2CppSystem.Object __1, RaiseEventOptions __2, SendOptions __3)
        {
            switch (__0)
            {
                case 1:
                    if (!Main.event1)
                        return true;

                    LogEventInfo(__0, __1, __2, __3, true, true);

                    break;
                case 3:
                    if (!Main.event3)
                        return true;

                    LogEventInfo(__0, __1, __2, __3, false, false);

                    break;
                case 6:
                    if (!Main.event6)
                        return true;

                    LogEventInfo(__0, __1, __2, __3, true, false);

                    break;
                case 7:
                    if (!Main.event7)
                        return true;
                    break;
                case 8:
                    if (!Main.event8)
                        return true;
                    break;
                case 9:
                    if (!Main.event9)
                        return true;
                    break;
                case 33:
                    if (!Main.event33)
                        return true;

                    

                    break;
                case 202:
                    if (!Main.event202)
                        return true;
                    break;
            }

            MelonLogger.Msg(ConsoleColor.Green, $"[LoadBalancingClient] RaiseEvent - {__0}");
            return true;
        }

        private static bool LBPEvent(byte __0, object __1, RaiseEventOptions __2, SendOptions __3)
        {
            MelonLogger.Msg(ConsoleColor.Green, $"[LoadBalancingPeer] RaiseEvent - {__0}");
            return true;
        }
        
        private static bool USRunProgramAsRPC(string __0, Player __1)
        {
            MelonLogger.Msg(ConsoleColor.Cyan, $"[UdonSync] RunProgramAsRPC - {__0}, {__1.field_Private_Int32_0} - {(__1.field_Private_String_0 == null ? "null" : __1.field_Private_String_0)}, {(__1.field_Private_String_1 == null ? "null" : __1.field_Private_String_1)}");
            return true;
        }

        private static bool NetRPC(RPC.Destination __0, GameObject __1, string __2)
        {
            MelonLogger.Msg(ConsoleColor.Cyan, $"[Networking] RPC 1 - {__2} - {__0.ToString()}, {(__1.transform.parent == null ? __1.name : $"{__1.transform.parent.name}/{__1.name}")}");
            return true;
        }
        
        private static bool NetRPC2(VRCPlayerApi __0, GameObject __1, string __2)
        {
            MelonLogger.Msg(ConsoleColor.Cyan, $"[Networking] RPC 2 - {__2} - {__0.displayName}, {(__1.transform.parent == null ? __1.name : $"{__1.transform.parent.name}/{__1.name}")}");
            return true;
        }
        
        private static bool WRSend(BestHTTP.HTTPRequest __instance)
        {
            MelonLogger.Msg(ConsoleColor.Yellow, $"[BestHTTP] HTTPRequest Sent - {__instance.MethodType.ToString().ToUpper()} {__instance.Uri.AbsoluteUri}");
            foreach (Il2CppSystem.Collections.Generic.KeyValuePair<string, Il2CppSystem.Collections.Generic.List<string>> kvp in __instance.Headers)
            {
                MelonLogger.Msg(ConsoleColor.Yellow, $"[BestHTTP] Header - {kvp.Key}: ");
                foreach (string str in kvp.Value)
                {
                    MelonLogger.Msg(ConsoleColor.Yellow, str);
                }
            }
            foreach (BestHTTP.Cookies.Cookie c in __instance.Cookies)
            {
                MelonLogger.Msg(ConsoleColor.Yellow, $"Cookie: {c.Value}");
            }

            if (__instance.RawData == null)
                return true;

            MelonLogger.Msg(ConsoleColor.Yellow, $"Raw Data: {System.Text.Encoding.Default.GetString(__instance.RawData)}");

            return true;
        }

        private static void LogEventInfo(byte __0, Il2CppSystem.Object __1, RaiseEventOptions __2, SendOptions __3, bool hasObject = true, bool hasSecondLayer = true)
        {
            MelonLogger.Msg($"- - - - - - - - - - - Event {__0} 1st Layer - - - - - - - - - - -");

            if(hasObject)
            {
                MelonLogger.Msg(__1.ToString());
            }

            MelonLogger.Msg("- - - - - - - - - RaiseEventOptions - - - - - - - - -");
            MelonLogger.Msg("Reciever Group: " + __2.field_Public_ReceiverGroup_0.ToString());
            MelonLogger.Msg("Byte 0: " + __2.field_Public_Byte_0.ToString());
            MelonLogger.Msg("Byte 1: " + __2.field_Public_Byte_1.ToString());
            MelonLogger.Msg("Event Caching: " + __2.field_Public_EventCaching_0.ToString());
            MelonLogger.Msg("WebFlags Boolean 0: " + __2.field_Public_WebFlags_0.prop_Boolean_0.ToString());
            MelonLogger.Msg("WebFlags Boolean 1: " + __2.field_Public_WebFlags_0.prop_Boolean_1.ToString());
            MelonLogger.Msg("WebFlags Boolean 2: " + __2.field_Public_WebFlags_0.prop_Boolean_2.ToString());
            MelonLogger.Msg("WebFlags Boolean 3: " + __2.field_Public_WebFlags_0.prop_Boolean_3.ToString());
            MelonLogger.Msg("WebFlags Byte 0: " + __2.field_Public_WebFlags_0.field_Public_Byte_0.ToString());
            //foreach(int i in __2.field_Public_ArrayOf_Int32_0)
            //{
            //    MelonLogger.Msg(i);
            //}
            MelonLogger.Msg("- - - - - - - - - SendOptions - - - - - - - - -");

            MelonLogger.Msg("Delivery Mode: " + __3.DeliveryMode.ToString());
            MelonLogger.Msg("Reliability: " + __3.Reliability.ToString());
            MelonLogger.Msg("Channel: " + __3.Channel.ToString());
            MelonLogger.Msg("Encrypt: " + __3.Encrypt.ToString());

            if (!hasSecondLayer || !hasObject)
                return;

            MelonLogger.Msg($"- - - - - - - - - - - Event {__0} 2nd Layer - - - - - - - - - - -");

            switch (__0)
            {
                case 1:
                    MelonLogger.Msg("Event 1 byte[] values");
                    foreach (byte b in Serialization.FromIL2CPPToManaged<byte[]>(__1))
                    {
                        MelonLogger.Msg(ConsoleColor.Green, b);
                    }
                    return;
                case 33:
                    MelonLogger.Msg("'byte: object'");
                    foreach (KeyValuePair<byte, object> pair1 in Serialization.FromIL2CPPToManaged<Dictionary<byte, object>>(__1))
                    {
                        MelonLogger.Msg($"{pair1.Key}: {pair1.Value.ToString()}");
                    }
                    return;
            }


            MelonLogger.Msg(__1.ToString());
        }

    }

}
